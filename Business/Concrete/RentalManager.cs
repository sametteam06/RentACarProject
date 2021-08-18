using Business.Abstract;
using Business.Constants;
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

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            if (Rentalable(entity)) {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.Success);
            }else
            {
                return new ErrorResult(Messages.Failed);
            }
            
        }
        private bool Rentalable(Rental entity)
        {
            bool result = false;
            ICarDal _carDal = new EfCarDal();
            ICustomerDal _customerDal = new EfCustomerDal();

            foreach (var item1 in _carDal.GetAll())
            {
                foreach (var item2 in _customerDal.GetAll())
                {
                    if (entity.CustomerId == item2.Id && entity.CarId == item1.Id)
                    {
                        result = true;
                    }
                }
            }
            
            return result;
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Success);
            }
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
