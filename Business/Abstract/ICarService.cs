using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;

namespace Business.Abstract
{
    public interface ICarService: IBaseService<Car>
    {
  
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();


        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int id);

        IDataResult<CarDetailDto> GetCarDetailsByCarId(int id);
        IDataResult<List<CarDetailDto>> GetCarsByFilter(int colorId, int brandId);
    }
}
