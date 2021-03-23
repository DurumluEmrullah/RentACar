using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICreditCardDal:IEntityRepository<CreditCard>
    {
        IResult Buy(BuyDto buyDto);
        bool Refund(BuyDto buyDto);
    }
}
