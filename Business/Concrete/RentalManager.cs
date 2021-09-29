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
        IUserService _userService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, IUserService customerService)
        {
            _userService = customerService;
            _carService = carService;
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            IResult result = BusinessRules.Run(CarCheck(entity), UserCheck(entity),DateCheck(entity), FindexCheck(entity));
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
        private IResult UserCheck(Rental entity)
        {
            var users = _userService.GetAll().Data;
            foreach (var user in users)
            {
                if(user.Id == entity.UserId)
                {
                    return new SuccessResult();
                }
            }
            return new ErrorResult(Messages.CustomerInvalid);
        }
        private IResult DateCheck(Rental entity)
        {
            var rentalalbe = this.GetAll();
            foreach (var rental in rentalalbe.Data)
            {
                if (rental.CarId == entity.CarId)
                {
                    if (entity.RentDate>=rental.RentDate && entity.RentDate<=rental.ReturnDate)
                    {
                        return new ErrorResult(Messages.InvalidDate);
                    }else if(entity.ReturnDate >= rental.RentDate && entity.ReturnDate <= rental.ReturnDate)
                    {
                        return new ErrorResult(Messages.InvalidDate);
                    }
                }
            }
            return new SuccessResult();
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

        public IResult Rentalable(Rental entity)
        {
            IResult result = BusinessRules.Run(CarCheck(entity), UserCheck(entity), DateCheck(entity), FindexCheck(entity));
            if (result != null)
            {
                return result;
            }
            return new SuccessResult(Messages.Success);
        }
        private IResult FindexCheck(Rental entity)
        {
            var minFindex = _carService.GetById(entity.CarId).Data.MinFindexPoint;
            var userFindex = _userService.GetById(entity.UserId).Data.FindexPoint;
            if (minFindex <= userFindex)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.InsufficientFindex);
        }
    }
}
