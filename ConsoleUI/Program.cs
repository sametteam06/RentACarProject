using Business.Concrete;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Entities.Concrete;
using Core.Utilities.Helper.FileHelper;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //UserManager userManager = new UserManager(new EfUserDal());
            //User user = new User() { Id = 2, Email = "samet2@gamze.com", FirstName = "Samet", LastName = "Gamze"};
            //var result = userManager.GetClaims(user);
            //foreach (var claim in result.Data)
            //{
            //    Console.WriteLine(claim.OperationClaimName);
            //}
            //Console.WriteLine("--------");



            //CarImageManager carImageManager = new CarImageManager(new EfCarImageDal(), new ImageFileHelper());
            //CarManager carManager = new CarManager(new EfCarDal(), carImageManager);
            //CarDetailDto car = new CarDetailDto();
            //Console.WriteLine(carManager.GetDetailById(3).Data.Images + "   " + carManager.GetDetailById(3).Data.CarName);
            //car = carManager.GetDetailById(3).Data;
            //CarImage image = new CarImage();
            
            //Console.WriteLine(car.CarName + "   /" + car.Images+"/");

        }
    }
}
