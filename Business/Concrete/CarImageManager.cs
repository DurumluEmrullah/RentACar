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
            IResult result = BusinessRules.Run(CheckCarImageCount(entity.CarId), SaveIMageToDirectory(entity));
            if (result != null)
            {
                return result;
            }


            _carImageDal.Add(entity);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(CarImageValidation))]
        public IResult Delete(CarImage entity)
        {
            IResult result = BusinessRules.Run(DeleteImageToDirectory(entity));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(entity);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidation))]
        public IResult Update(CarImage entity)
        {
            entity.Date=DateTime.Now;
            IResult result = BusinessRules.Run(CheckCarImageCount(entity.CarId),SaveIMageToDirectory(entity));
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
            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.MaxCarImage);
            }

            return new SuccessResult();
        }
        
        private IResult SaveIMageToDirectory(CarImage carImage)
        {

            string fileName = System.IO.Path.GetFileName(carImage.ImagePath);
            string newFileName = Guid.NewGuid().ToString() + fileName.Substring(fileName.LastIndexOf("."));
            string destinationFilePath = System.IO.Path.Combine(Directories.ImageDirectoryPath, fileName);
            System.IO.File.Copy(carImage.ImagePath, destinationFilePath, true);
            System.IO.File.Move(Directories.ImageDirectoryPath + fileName, Directories.ImageDirectoryPath + newFileName);
            carImage.ImagePath = newFileName;

            return new SuccessResult();
        }

        private IResult DeleteImageToDirectory(CarImage carImage)
        {
            System.IO.File.Delete(carImage.ImagePath);

            return new SuccessResult();
        }
    }
}
