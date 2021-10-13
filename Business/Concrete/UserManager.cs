using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Helper.HashingHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<User> ChangeEmail(UserEmailChangeModel userEmailChangeModel)
        {
            var currentUser = GetById(userEmailChangeModel.UserId);
            var user = new User();
            if (currentUser.Data.Email == userEmailChangeModel.Email)
            {
                user.Email = userEmailChangeModel.Email;
            }else
            {
                if (!UserExists(userEmailChangeModel.Email).Success)
                {
                    return new ErrorDataResult<User>(GetById(userEmailChangeModel.UserId).Data, Messages.UserAlreadyExists);
                }
                else
                {
                    user.Email = userEmailChangeModel.Email;
                }
            };
            
            {
                user.Id = currentUser.Data.Id;
                user.FirstName = currentUser.Data.FirstName;
                user.LastName = currentUser.Data.LastName;
                user.PasswordHash = currentUser.Data.PasswordHash;
                user.PasswordSalt = currentUser.Data.PasswordSalt;
                user.Status = true;
                user.FindexPoint = currentUser.Data.FindexPoint;
                Update(user);
                return new SuccessDataResult<User>(GetById(user.Id).Data, Messages.Success);
            }
        }

        public IDataResult<User> ChangeName(UserNameChangeModel userNameChangeModel)
        {
            var currentUser = GetById(userNameChangeModel.UserId);
            var user = new User
            {
                Id = currentUser.Data.Id,
                Email = currentUser.Data.Email,
                FirstName = userNameChangeModel.FirstName,
                LastName = userNameChangeModel.LastName,
                PasswordHash = currentUser.Data.PasswordHash,
                PasswordSalt = currentUser.Data.PasswordSalt,
                FindexPoint = currentUser.Data.FindexPoint,
                Status = true
            };
            Update(user);
            return new SuccessDataResult<User>(GetById(user.Id).Data, Messages.Success);
        }

        public IDataResult<User> ChangePw(UserPwChangeModel userPwChangeModel)
        {
            if(userPwChangeModel.Password != userPwChangeModel.PasswordCheck)
            {
                return new ErrorDataResult<User>(GetById(userPwChangeModel.UserId).Data, Messages.PasswordError);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHast(userPwChangeModel.Password, out passwordHash, out passwordSalt);
            var currentUser = GetById(userPwChangeModel.UserId);
            var user = new User
            {
                Id = currentUser.Data.Id,
                Email = currentUser.Data.Email,
                FirstName = currentUser.Data.FirstName,
                LastName = currentUser.Data.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FindexPoint = currentUser.Data.FindexPoint,
                Status = true
            };
            Update(user);
            return new SuccessDataResult<User>(GetById(user.Id).Data, Messages.Success);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<User>> GetAll()
        {
            
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Success);
            
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Messages.Success);
        }

        public IDataResult<User> GetByMail(string mail)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == mail), Messages.Success);
        }

        public IDataResult<List<UserOperationClaimDto>> GetClaims(User user)
        {
            return new SuccessDataResult<List<UserOperationClaimDto>>(_userDal.GetClaims(user), Messages.Success);
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.Success);
        }

        public IResult UserExists(string email)
        {
            if (GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
        
    }

}
