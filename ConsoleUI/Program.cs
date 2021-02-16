using Business.Concrete;
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
            CarManager carManager = new CarManager(new InMemoryCarDal());
            List<Car> cars = new List<Car>();

            cars = carManager.GetAll();

            foreach(var car in cars)
            {

                Console.WriteLine(car.ModelYear);
            }


        }
    }
}
