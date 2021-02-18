using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DataBaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using(DataBaseContext context = new DataBaseContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join b in context.Brands
                             on p.BrandId equals b.BrandId
                             select new CarDetailDto { CarName = p.CarName, BrandName = b.BrandName, ColorName = c.ColorName, DailyPrice = p.DailyPrice };
                return result.ToList();
            }
        }
    }
}
