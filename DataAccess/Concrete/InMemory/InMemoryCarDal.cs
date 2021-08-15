using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=1, BrandId = 1, ColorId = 1, DailyPrice = 100, Description = "Açıklama1", ModelYear = 2010},
                new Car {Id=2, BrandId = 1, ColorId = 1, DailyPrice = 100, Description = "Açıklama2", ModelYear = 2010},
                new Car {Id=3, BrandId = 2, ColorId = 1, DailyPrice = 100, Description = "Açıklama3", ModelYear = 2010},
                new Car {Id=4, BrandId = 2, ColorId = 1, DailyPrice = 100, Description = "Açıklama4", ModelYear = 2010},
                new Car {Id=5, BrandId = 3, ColorId = 1, DailyPrice = 100, Description = "Açıklama5", ModelYear = 2010},
                new Car {Id=6, BrandId = 4, ColorId = 1, DailyPrice = 100, Description = "Açıklama6", ModelYear = 2010},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car toDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(toDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GeyByBrandId(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car toUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            toUpdate.BrandId = car.BrandId;
            toUpdate.ColorId = car.ColorId;
            toUpdate.DailyPrice = car.DailyPrice;
            toUpdate.Description = car.Description;
            toUpdate.ModelYear = car.ModelYear;
        }
    }
}
