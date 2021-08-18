using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental();
            rental.CarId = 5;
            rental.CustomerId = 40;
            rental.RentDate = DateTime.Now;
            var result = rentalManager.Add(rental);
            Console.WriteLine(result.Message);
        }
    }
}
