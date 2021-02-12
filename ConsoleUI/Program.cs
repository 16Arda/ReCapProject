using System;
using System.Collections.Generic;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
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
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " Marka - " + car.ColorName + " Renk - " + car.ModelYear + " Model - Günlük " + car.DailyPrice + " TL - " + car.Description);
                }
            }

            var result2 = brandManager.Add(new Brand { BrandName = "ABC" });
            if (result2.Success == true)
            {
                Console.WriteLine(result2.Message);
            }

            carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 50, Description = "ABC", ModelYear = 2015 });

            var tarih = DateTime.Now;
            rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = tarih, ReturnDate = tarih });

            colorManager.Add(new Color { ColorName = "Kırmızı" });

            colorManager.Add(new Color { ColorName = "Pembe" });

            var result3 = userManager.Add(new User { FirstName = "Arda", LastName = "A", Email = "asdasd", Password = "asdasd" });
            if (result3.Success == true)
            {
                Console.WriteLine(result3.Message);
            }
        }
    }
}
