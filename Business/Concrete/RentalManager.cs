using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        ICustomerService _customerService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService)
        {
            _customerService = customerService;
            _carService = carService;
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            IResult result = BusinessRules.Run(CarCheck(entity), CustomerCheck(entity));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.Success);
        }
        private IResult CarCheck(Rental entity)
        {
            var cars = _carService.GetAll().Data;
            foreach (var car in cars)
            {
                if (car.Id == entity.CarId)
                {
                    return new SuccessResult();
                }
            }
            return new ErrorResult(Messages.CarInvalid);
        }
        private IResult CustomerCheck(Rental entity)
        {
            var customers = _customerService.GetAll().Data;
            foreach (var customer in customers)
            {
                if(customer.Id == entity.CustomerId)
                {
                    return new SuccessResult();
                }
            }
            return new ErrorResult(Messages.CustomerInvalid);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Rental>> GetAll()
        {
           
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Success);
            
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id), Messages.Success);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.Success);
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.Success);
        }
    }
}
