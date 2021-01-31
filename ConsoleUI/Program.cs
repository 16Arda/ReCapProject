using System;
using System.Collections.Generic;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // GetAll TEST
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model - Günlük " + car.DailyPrice + " TL - " + car.Description);
            }

            Console.WriteLine("==========");

            // GetById TEST
            Console.WriteLine((carManager.GetById(1)).Description);

            Console.WriteLine("==========");

            // Add TEST
            Car car1 = new Car() { Id = 6, BrandId = 4, ColorId = 3, ModelYear = 2018, DailyPrice = 425, Description = "Uçak gibi araba." };
            carManager.Add(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model - Günlük " + car.DailyPrice + " TL - " + car.Description);
            }

            Console.WriteLine("==========");

            // Update TEST
            carManager.Update(car1);

            Console.WriteLine("==========");

            // Delete TEST
            carManager.Delete(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model - Günlük " + car.DailyPrice + " TL - " + car.Description);
            }
        }
    }
}
