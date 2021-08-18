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
            //CarManager carManager = new CarManager(new EfCarDal());
            //var result = carManager.GetCarDetails();
            //if (result.Success == true)
            //{
            //    foreach (var c in result.Data)
            //    {
            //        Console.WriteLine(c.CarName + "   /   "+ c.BrandName);
            //    }
            //    Console.WriteLine(result.Message);
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //Brand brand = new Brand() { BrandName = "Ferrari" };
            //var result2 = brandManager.Add(brand);
            //Console.WriteLine(result2.Message);
            //var result = brandManager.GetAll();
            //if(result.Success == true)
            //{
            //    foreach (var b in result.Data)
            //    {
            //        Console.WriteLine(b.BrandName);
            //    }
            //    Console.WriteLine(result.Message) ;
            //}
            //else Console.WriteLine(result.Message);
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            foreach (var c in result.Data)
            {
                Console.WriteLine(c.ColorName);
            }
            Console.WriteLine(result.Message);


        }
      
    }
}
