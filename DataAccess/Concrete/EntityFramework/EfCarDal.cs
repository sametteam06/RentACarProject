﻿using Core.DataAccess.EntityFramework;
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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join d in context.Displacements
                             on c.DisplacementId equals d.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailDto { CarId = c.Id,ModelYear=c.ModelYear, CarName = c.Description, BrandName = b.BrandName, EngineDisplacement = d.EngineDisplacement, DailyPrice = c.DailyPrice,MinFindexPoint=c.MinFindexPoint};
                return result.ToList();
            }
        }
    }
}
