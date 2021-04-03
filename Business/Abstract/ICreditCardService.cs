using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICreditCardService:IBaseService<CreditCard>
    {
        IResult Buy(BuyDto buyDto);
        IResult Refund(BuyDto buyDto);
        IDataResult<List<CreditCard>>GetCreditCardsByCustomerId(int id);
    }
}
