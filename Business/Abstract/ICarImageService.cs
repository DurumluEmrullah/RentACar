using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService:IBaseService<CarImage>
    {
        IDataResult<CarImage> GetCarImage(int carId);
    }
}
