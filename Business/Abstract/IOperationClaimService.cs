using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IDataResult<List<OperationClaim>> GetAll();
        IResult Add(OperationClaim entity);
        IResult Update(OperationClaim entity);
        IResult Delete(OperationClaim entity);
        IDataResult<OperationClaim> GetById(int id);
    }
}
