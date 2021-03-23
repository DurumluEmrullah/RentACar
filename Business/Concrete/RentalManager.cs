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
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }


        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {

            var carState = _rentalDal.Get(c => c.CarId == rental.CarId);
            if (carState == null)
            {
               
                    if (DateTime.Compare(rental.ReturnDate, rental.RentDate) > 0)
                    {
                        rental.RentDate = DateTime.Now;
                        _rentalDal.Add(rental);
                        return new SuccessResult();
                    }

             
            }

            return new ErrorResult(Messages.AlreadyRented);

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IDataResult<List<RentalDetailDto>> GetDetailRentals()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
    }
}
