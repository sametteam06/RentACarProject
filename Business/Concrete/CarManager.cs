using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length >= 2)
            {   
                _carDal.Add(car);
                return new SuccessResult(Messages.Success);
            }           
            return new ErrorResult(Messages.Failed);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Car>> GetAll()
        { 
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Success);
        }
        public IDataResult<Car> GetById(int id)
        {
            if (DateTime.Now.Hour == 12)
            {
                return new ErrorDataResult<Car>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id),Messages.Success);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            } return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.Success);
        }
    }
}
