﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2000, DailyPrice = 250, Description = "Az yakar çok kaçar."},
                new Car{Id = 2, BrandId = 2, ColorId = 3, ModelYear = 2005, DailyPrice = 325, Description = "Yeni gibi."},
                new Car{Id = 3, BrandId = 3, ColorId = 2, ModelYear = 2010, DailyPrice = 375, Description = "Cip gibi araba."},
                new Car{Id = 4, BrandId = 2, ColorId = 5, ModelYear = 2019, DailyPrice = 450, Description = "Tertemiz, hatasız araba."},
                new Car{Id = 5, BrandId = 1, ColorId = 4, ModelYear = 2020, DailyPrice = 500, Description = "Sıfır araba."}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
