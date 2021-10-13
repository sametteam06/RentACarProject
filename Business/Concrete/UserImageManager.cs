using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Helper.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserImageManager : IUserImageService
    {
        IUserImageDal _userImageDal;
        private IFileHelper _fileHelper;


        public UserImageManager(IUserImageDal userImageDal, IFileHelper fileHelper)
        {
            _userImageDal = userImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(UserImage entity, IFormFile file)
        {
            var result = _userImageDal.Get(i => i.UserId == entity.UserId);
            if (result == null)
            {
                var imageResult = IsImageUploaded(file);
                entity.Date = DateTime.Now;
                entity.ImagePath = imageResult.Data.Data;
                _userImageDal.Add(entity);
                return new SuccessResult(Messages.ImageAdded);
            }
            Update(result, file);
            return new SuccessResult(Messages.Success);
            
        }
        
        public IResult Delete(UserImage entity)
        {
            var result = _userImageDal.Get(i => i.Id == entity.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.ImagesNotFound);
            }
            _fileHelper.Delete(entity.ImagePath);
            entity.UserId = result.UserId;
            _userImageDal.Delete(entity);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<UserImage>> GetAll()
        {
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll(), Messages.Success);
        }

        public IDataResult<UserImage> GetByUserId(int id)
        {
            var result = _userImageDal.Get(i => i.UserId == id);
            if(result == null)
            {
                UserImage image = new UserImage();
                image.ImagePath = "/images/default-image.jpg";
                return new SuccessDataResult<UserImage>(image, Messages.Success);
            }
            return new SuccessDataResult<UserImage>(_userImageDal.Get(i => i.UserId == id), Messages.Success);
        }

        public IDataResult<UserImage> GetById(int id)
        {
            return new SuccessDataResult<UserImage>(_userImageDal.Get(i => i.Id == id), Messages.Success);
        }

        public IResult Update(UserImage entity, IFormFile file)
        {
            var result = _userImageDal.Get(i => i.Id == entity.Id);
            var UpdatedFile = _fileHelper.Update(file, entity.ImagePath);
            entity.ImagePath = UpdatedFile.Data;
            entity.UserId = result.UserId;
            entity.Date = result.Date;
            _userImageDal.Update(entity);
            return new SuccessResult(Messages.Success);
        }
        private IDataResult<IDataResult<string>> IsImageUploaded(IFormFile file)
        {
            var imageResult = _fileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorDataResult<IDataResult<string>>(imageResult.Message);
            }
            return new SuccessDataResult<IDataResult<string>>(data: imageResult);
        }
    }
}
