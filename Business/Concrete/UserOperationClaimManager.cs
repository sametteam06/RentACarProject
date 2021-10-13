using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;
        IUserService _userService;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IUserService userService)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _userService = userService;
        }

        public IResult Add(UserOperationClaim entity)
        {
            _userOperationClaimDal.Add(entity);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(UserOperationClaim entity)
        {
            _userOperationClaimDal.Delete(entity);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(), Messages.Success);
        }

        public IDataResult<List<UserClaimListDto>> GetAllClaimsForAllUser()
        {
            List<UserClaimListDto> result = new List<UserClaimListDto>();
            
            var users = _userService.GetAll();
            var getClaims = GetAllDetail();
            foreach (var user in users.Data)
            {
                List<string> names = new List<string>();
                List<int> ids = new List<int>();
                foreach (var claim in getClaims.Data)
                {
                    if (claim.UserId == user.Id)
                    {
                        names.Add(claim.OperationClaimName);
                        ids.Add(claim.OperationClaimId);
                    }
                }
                result.Add(new UserClaimListDto { UserId = user.Id, UserEmail = user.Email, OperationClaimId = ids, OperationClaimName=names });
            }
            
            return new SuccessDataResult<List<UserClaimListDto>>(result, Messages.Success);
        }

        public IDataResult<List<ClaimDto>> GetAllDetail()
        {
            return new SuccessDataResult<List<ClaimDto>>(_userOperationClaimDal.GetDetails(), Messages.Success);
        }

        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(u => u.Id == id), Messages.Success);
        }

        public IDataResult<List<UserOperationClaim>> GetByOperationClaimId(int id)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(u=>u.OperationClaimId == id), Messages.Success);
        }

        public IDataResult<List<UserOperationClaim>> GetByUserId(int id)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(u=>u.UserId == id), Messages.Success);
        }

        public IDataResult<List<ClaimDto>> GetDetailByUserId(int id)
        {
            List<ClaimDto> list = new List<ClaimDto>();
            var result = _userOperationClaimDal.GetDetails();
            foreach (var item in result)
            {
                if(item.UserId == id)
                {
                    list.Add(item);
                }
            }
            return new SuccessDataResult<List<ClaimDto>>(list, Messages.Success);
        }

        public IDataResult<List<ClaimDto>> GetDetailOperationClaimId(int id)
        {
            List<ClaimDto> list = new List<ClaimDto>();
            var result = _userOperationClaimDal.GetDetails();
            foreach (var item in result)
            {
                if(item.OperationClaimId == id)
                {
                    list.Add(item);
                }
            }
            return new SuccessDataResult<List<ClaimDto>>(list, Messages.Success);
        }

        public IResult Update(UserOperationClaim entity)
        {
            _userOperationClaimDal.Update(entity);
            return new SuccessResult(Messages.Success);
        }
    }
}
