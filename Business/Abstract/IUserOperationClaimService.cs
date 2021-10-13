using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<List<UserOperationClaim>> GetAll();
        IResult Add(UserOperationClaim entity);
        IResult Update(UserOperationClaim entity);
        IResult Delete(UserOperationClaim entity);
        IDataResult<UserOperationClaim> GetById(int id);
        IDataResult<List<UserOperationClaim>> GetByUserId(int id);
        IDataResult<List<UserOperationClaim>> GetByOperationClaimId(int id);
        IDataResult<List<ClaimDto>> GetAllDetail();
        IDataResult<List<ClaimDto>> GetDetailByUserId(int id);
        IDataResult<List<ClaimDto>> GetDetailOperationClaimId(int id);
        IDataResult<List<UserClaimListDto>> GetAllClaimsForAllUser();




    }
}
