using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        private ICarImageService _carImageService;
        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Success);
        }
        [SecuredOperation("admin")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Success);
        }
        //[SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        { 
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByDisplacementId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DisplacementId == id));
        }
        [SecuredOperation("admin")]
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
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.Success);
        }

        public IDataResult<CarDetailDto> GetCarDetailById(int id)
        {
            var cars = _carDal.GetCarDetails();
            foreach (var car in cars)
            {
                if(car.CarId == id)
                {
                    return new SuccessDataResult<CarDetailDto>(car, Messages.Success);
                }
            }
            return new ErrorDataResult<CarDetailDto>(Messages.CarInvalid);
            
        }

        public IDataResult<List<CarMainPageDto>> GetCarsForMainPage()
        {
            var details = GetCarDetails();
            List<CarMainPageDto> result = new List<CarMainPageDto>();
            foreach (var car in details.Data)
            {
                CarMainPageDto model = new CarMainPageDto();
                model.BrandName = car.BrandName;
                model.CarId = car.CarId;
                model.CarName = car.CarName;
                model.DailyPrice = car.DailyPrice;
                model.EngineDisplacement = car.EngineDisplacement;
                model.MinFindexPoint = car.MinFindexPoint;
                model.ModelYear = car.ModelYear;
                model.ImagePath = _carImageService.GetCarsFirstImage(model.CarId).Data.ImagePath;
                result.Add(model);
            }
            return new SuccessDataResult<List<CarMainPageDto>>(result, Messages.Success);
        }

        public IDataResult<List<CarMainPageDto>> GetCarsForMainPageByBrandId(int id)
        {
            var details = GetCarDetailsByBrandId(id);
            List<CarMainPageDto> result = new List<CarMainPageDto>();
            foreach (var car in details.Data)
            {
                CarMainPageDto model = new CarMainPageDto();
                model.BrandName = car.BrandName;
                model.CarId = car.CarId;
                model.CarName = car.CarName;
                model.DailyPrice = car.DailyPrice;
                model.EngineDisplacement = car.EngineDisplacement;
                model.MinFindexPoint = car.MinFindexPoint;
                model.ModelYear = car.ModelYear;
                model.ImagePath = _carImageService.GetCarsFirstImage(model.CarId).Data.ImagePath;
                result.Add(model);
            }
            return new SuccessDataResult<List<CarMainPageDto>>(result, Messages.Success);
        }

        public IDataResult<List<CarMainPageDto>> GetCarsForMainPageByDisplacementId(int id)
        {
            var details = GetCarDetailsByDisplacementId(id);
            List<CarMainPageDto> result = new List<CarMainPageDto>();
            foreach (var car in details.Data)
            {
                CarMainPageDto model = new CarMainPageDto();
                model.BrandName = car.BrandName;
                model.CarId = car.CarId;
                model.CarName = car.CarName;
                model.DailyPrice = car.DailyPrice;
                model.EngineDisplacement = car.EngineDisplacement;
                model.MinFindexPoint = car.MinFindexPoint;
                model.ModelYear = car.ModelYear;
                model.ImagePath = _carImageService.GetCarsFirstImage(model.CarId).Data.ImagePath;
                result.Add(model);
            }
            return new SuccessDataResult<List<CarMainPageDto>>(result, Messages.Success);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=>c.BrandId == id), Messages.Success);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByDisplacementId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=>c.DisplacementId == id), Messages.Success);
        }
    }
}
