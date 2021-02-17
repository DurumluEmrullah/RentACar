using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            List<Car> cars = new List<Car>();

            //  carManager.AddCar(new Car { Id = 1, BrandId = 2, ColorId = 3, CarName = "Mercedes", DailyPrice = 100, ModelYear = 2005, Description = "Saatte 150 km hız" });
            //  carManager.AddCar(new Car { Id = 2, BrandId = 2, ColorId = 5, CarName = "Opel", DailyPrice = 1, ModelYear = 2005, Description = "Saatte 150 km hız" });
            cars = carManager.GetAll();
            foreach (var car in cars)
            {

                Console.WriteLine(car.ModelYear);
            }


        }
    }
}
