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
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //Console.WriteLine(colorManager.GetById(1).ColorName);
            //Console.WriteLine(brandManager.GetById(1).BrandName);
            Color color = new Color() { ColorName = "Siyah", Id = 1002 };
            Brand brand = new Brand() { BrandName = "Mercedes", Id = 1002 };
            Car car = new Car() { Description = "yeniaçıklamason" };

            Car car3 = new Car()
            {
                Id=2005,
                Description = "sonaçıklama2222",
                BrandId = 2,
                DailyPrice = 50,
                ColorId = 3,
                ModelYear = 2011
            };
            //colorManager.Add(color);
            //brandManager.Add(brand);
            //carManager.Add(car3);
            //carManager.Delete(car3);
            //brandManager.Delete(brand);
            //colorManager.Delete(color);
            //foreach (var c in colorManager.GetAll())
            //{
            //    Console.WriteLine(c.ColorName);
            //}
            //foreach (var c in brandManager.GetAll())
            //{
            //    Console.WriteLine(c.BrandName);
            //}
            foreach (var c in carManager.GetCarDetails())
            {
                Console.WriteLine(c.BrandName + "   "+ c.CarName + "   " + c.ColorName + "   "+c.DailyPrice);
            }
            
            //Console.WriteLine(carManager.GetById(3).Description);

            //carManager.Update(car);
            //foreach (var c in carManager.GetAll())
            //{
            //    Console.WriteLine(c.Description);
            //}

        }
      
    }
}
