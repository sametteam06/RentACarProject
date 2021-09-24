using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDisplacementService
    {
        IDataResult<List<Displacement>> GetAll();
        IResult Add(Displacement entity);
        IResult Update(Displacement entity);
        IResult Delete(Displacement entity);
        IDataResult<Displacement> GetById(int id);
    }
}
