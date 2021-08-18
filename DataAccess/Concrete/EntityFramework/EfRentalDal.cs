using Core.DataAccess.EntityFramework;
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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join car in context.Cars
                             on r.CarId equals car.Id
                             join customer in context.Customers
                             on r.CustomerId equals customer.Id
                             select new RentalDetailDto { CarName = car.Description,  CustomerName= customer.CompanyName, RentDate = r.RentDate, ReturnDate = (DateTime)r.ReturnDate};
                return result.ToList();
            }
        }
    }
}
