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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + " Marka - " + car.ColorName + " Renk - " + car.ModelYear + " Model - Günlük " + car.DailyPrice + " TL - " + car.Description);
            }

            brandManager.Add(new Brand { BrandName = "Vay" });

            colorManager.Add(new Color { ColorName = "Kırmızı" });

            colorManager.Add(new Color { ColorName = "Pembe" });

        }

        // Liste
        private static void GetCarsByColorIdTest(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.ModelYear + " Model - Günlük " + car.DailyPrice + " TL - " + car.Description);
            }
        }

        // Marka ID'si 2 olan arabaları getirir.
        private static void GetCarsByBrandIdTest(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.ModelYear + " Model - Günlük " + car.DailyPrice + " TL - " + car.Description);
            }
        }

        // Sisteme Araba Ekleme
        private static void AddTest(CarManager carManager)
        {
            carManager.Add(new Car { BrandId = 2, ColorId = 2, ModelYear = 2015, DailyPrice = 275, Description = "Reno" });
        }

        // Renk ID'si 2 olan arabaları getirir.
        private static void GetAllTest(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model - Günlük " + car.DailyPrice + " TL - " + car.Description);
            }
        }
    }
}
