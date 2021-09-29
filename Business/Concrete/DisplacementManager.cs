using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class DisplacementManager : IDisplacementService
    {
        IDisplacementDal _displacementDal;

        public DisplacementManager(IDisplacementDal displacementDal)
        {
            _displacementDal = displacementDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(Displacement entity)
        {
            _displacementDal.Add(entity);
            return new SuccessResult(Messages.DisplacementAdded);
        }
        [SecuredOperation("admin")]
        public IResult Delete(Displacement entity)
        {
            _displacementDal.Delete(entity);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Displacement>> GetAll()
        {
            return new SuccessDataResult<List<Displacement>>(_displacementDal.GetAll(),Messages.Success);
        }

        public IDataResult<Displacement> GetById(int id)
        {
            return new SuccessDataResult<Displacement>(_displacementDal.Get(d => d.Id == id), Messages.Success);
        }
        [SecuredOperation("admin")]
        public IResult Update(Displacement entity)
        {
            _displacementDal.Update(entity);
            return new SuccessResult(Messages.Success);
        }
    }
}
