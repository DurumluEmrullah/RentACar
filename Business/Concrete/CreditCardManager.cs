using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CreditCardManager:ICreditCardService
    {
        private ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Add(CreditCard entity)
        {
            _creditCardDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(CreditCard entity)
        {
            _creditCardDal.Delete(entity);
            return new SuccessResult();
        }

        public IResult Update(CreditCard entity)
        {
            _creditCardDal.Update(entity);
            return new SuccessResult();
        }
        
        public IResult Buy(BuyDto buyDto)
        {
           var result= _creditCardDal.Buy(buyDto);
           if (result.Success)
           {
               return new SuccessResult();
           }
           else
           {
               return new ErrorResult(result.Message);
           }
        }

        public IResult Refund(BuyDto buyDto)
        {
            _creditCardDal.Refund(buyDto);
            return new SuccessResult();
        }
    }
}
