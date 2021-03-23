using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, DataBaseContext>, ICreditCardDal
    {
        public IResult Buy(BuyDto buyDto)
        {
            using (DataBaseContext contex = new DataBaseContext())
            {

                var creditCard = contex.Set<CreditCard>().SingleOrDefault(c => c.CardNumber == buyDto.CreditCardNumber
                && c.SecurityNumber==buyDto.SecurityNumber 
                && c.MounthOfExpirationDate == buyDto.MounthOfExpirationDate 
                && c.YearOfExpirationDate ==buyDto.YearOfExpirationDate);
                if (creditCard != null)
                {
                    if (creditCard.Balance >= buyDto.Amount)
                    {
                        creditCard.Balance -= buyDto.Amount;
                        var updateCreditCard = contex.Entry(creditCard);
                        updateCreditCard.State = EntityState.Modified;
                        contex.SaveChanges();
                        return new SuccessResult();
                    }
                    return new ErrorResult("Yetersiz Bakiye.");

                }
                else
                {
                    return new ErrorResult("Kart Bilgileri Hatalı.");
                }



            }
        }

        public bool Refund(BuyDto buyDto)
        {
            using (DataBaseContext contex = new DataBaseContext())
            {
                var creditCard = contex.Set<CreditCard>().SingleOrDefault(c => c.CardNumber == buyDto.CreditCardNumber);
                creditCard.Balance += buyDto.Amount;
                var updateCreditCard = contex.Entry(creditCard);
                updateCreditCard.State = EntityState.Modified;
                contex.SaveChanges();
                return true;
            }
        }
    }
}
