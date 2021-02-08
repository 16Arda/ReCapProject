﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var table = from c in context.Cars
                            join b in context.Brands
                            on c.BrandId equals b.BrandId
                            join co in context.Colors
                            on c.ColorId equals co.ColorId
                            select new CarDetailDto
                            {
                                CarId = c.CarId,
                                BrandName = b.BrandName,
                                ColorName = co.ColorName,
                                ModelYear = c.ModelYear,
                                DailyPrice = c.DailyPrice,
                                Description = c.Description
                            };
                return table.ToList();
            }
        }
    }
}
