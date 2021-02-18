using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            List<CarDetailDto> cars = new List<CarDetailDto>();
            // CRUD(carManager, brandManager, colorManager);
            //carManager.AddCar(new Car { BrandId = 3, ColorId = 1, CarName = "Mercedes", DailyPrice = 100, ModelYear = 2005, Description = "Saatte 150 km hız" });
            cars = carManager.GetCarDetails();
            foreach (var car in cars)
            {

                Console.WriteLine(car.CarName+"/"+car.ColorName+"/"+car.BrandName+"/"+car.DailyPrice);
            }


        }

        private static void CRUD(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            brandManager.AddBrand(new Brand { BrandName = "Mercedes" });
            brandManager.AddBrand(new Brand { BrandName = "Fiat" });
            brandManager.AddBrand(new Brand { BrandName = "Renault" });
            brandManager.AddBrand(new Brand { BrandName = "Opel" });
            brandManager.AddBrand(new Brand { BrandName = "Mitsubishi" });

            colorManager.AddColor(new Color { ColorName = "Kırmızı" });
            colorManager.AddColor(new Color { ColorName = "Beyaz" });
            colorManager.AddColor(new Color { ColorName = "Mavi" });
            colorManager.AddColor(new Color { ColorName = "Yeşil" });
            colorManager.AddColor(new Color { ColorName = "Turuncu" });
            carManager.AddCar(new Car { Id = 1, BrandId = 2, ColorId = 3, CarName = "Mercedes", DailyPrice = 100, ModelYear = 2005, Description = "Saatte 150 km hız" });
            carManager.AddCar(new Car { BrandId = 2, ColorId = 5, CarName = "Opel", DailyPrice = 1, ModelYear = 2005, Description = "Saatte 150 km hız" });
            carManager.DeleteCar(new Car { Id = 2, BrandId = 2, ColorId = 5, CarName = "Mercedes", DailyPrice = 500, ModelYear = 2019, Description = "Saatte 150 km hız" });
        }
    }
}
