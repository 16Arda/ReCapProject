using System;
using System.Collections.Generic;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            // Liste
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model - Günlük " + car.DailyPrice + " TL - " + car.Description);
            }

            Console.WriteLine("====================");

            // Sisteme Araba Ekleme
            carManager.Add(new Car { CarId = 6, BrandId = 2, ColorId = 2, ModelYear = 2015, DailyPrice = 275, Description = "Reno" });

            Console.WriteLine("====================");

            // Yeni Liste
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model - Günlük " + car.DailyPrice + " TL - " + car.Description);
            }

            Console.WriteLine("====================");

            // Marka ID'si 2 olan arabaları getirir.
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.ModelYear + " Model - Günlük " + car.DailyPrice + " TL - " + car.Description);
            }

            Console.WriteLine("====================");

            // Renk ID'si 2 olan arabaları getirir.
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.ModelYear + " Model - Günlük " + car.DailyPrice + " TL - " + car.Description);
            }
        }
    }
}
