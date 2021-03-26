using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspect.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
       // [SecuredOperation("Admin")]
      //  [CacheRemoveAspect("ICarService.Get")]
       [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            //return new ErrorResult();
        }
    //    [CacheRemoveAspect("IBaseService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
       // [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetailsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandId(id), Messages.CarDetailsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByColorId(id), Messages.CarDetailsListed);
        }

        public IDataResult<CarDetailDto> GetCarDetailsByCarId(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsByCarId(id), Messages.CarDetailsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByFilter(int colorId, int brandId)
        {
            
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsByFilter(colorId, brandId));
        }


        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }
       // [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<Car> GetById(int id)
        {
           return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id==id));
        }
    }
}
