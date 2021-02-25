using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
           return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [ValidationAspect(typeof(CarImageValidation))]
        public IResult Add(CarImage entity)
        {
            entity.Date=DateTime.Now;
            IResult result = BusinessRules.Run(CheckCarImageCount(entity.CarId),RenameIMagePath(entity));
            if (result != null)
            {
                return result;
            }


            _carImageDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(CarImage entity)
        {
            _carImageDal.Delete(entity);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidation))]
        public IResult Update(CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckCarImageCount(entity.CarId));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetCarImage(int carId)
        {
           return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }


        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count > 5)
            {
                return new ErrorResult(Messages.MaxCarImage);
            }

            return new SuccessResult();
        }
        // referans tip olduğu için direk carImage nesnesini gönderdim 
        private IResult RenameIMagePath(CarImage carImage)
        {

            Random random = new Random();
            carImage.ImagePath = carImage.ImagePath.Replace(" ", "-");
            carImage.ImagePath = carImage.ImagePath.Substring(carImage.ImagePath.Length - carImage.ImagePath.Length / 2) + "" +
                               random.Next();


            return new SuccessResult();
        }
    }
}
