using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _imageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal imageDal, IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
            _imageDal = imageDal;
        }
        public IResult Add(CarImage image, IFormFile file)
        {
            //Logic Code Control
            var result = BusinessRules.Run(CheckImageLimitExceeded(image.CarId));
            if (result != null)
            {
                return result;
            }
            var imageResult = IsImageUploaded(file);
            //var imageResult = _fileHelper.Upload(file);
            //if (!imageResult.Success)
            //{
            //    return new ErrorResult(imageResult.Message);
            //}
            image.Date = DateTime.Now;
            image.ImagePath = imageResult.Data.Data;
            _imageDal.Add(image);

            return new SuccessResult(Messages.CarImageAdded);

        }

        public IResult Delete(CarImage image)
        {
            var result = _imageDal.Get(i => i.Id == image.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.ImagesNotFound);
            }
            _fileHelper.Delete(image.ImagePath);
            _imageDal.Delete(image);
            return new SuccessResult(Messages.CarImageDeleted);

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _imageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result);
        }
        public IDataResult<CarImage> GetById(int id)
        {
            var result = _imageDal.Get(i => i.Id == id);
            return new SuccessDataResult<CarImage>(result);
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            var result = _imageDal.GetAll(i => i.CarId == id);
            if (result != null)
                return new SuccessDataResult<List<CarImage>>(result);
            return new ErrorDataResult<List<CarImage>>(Messages.ImagesNotFound);
        }

        public IResult Update(CarImage image, IFormFile file)
        {
            var result = _imageDal.Get(i => i.Id == image.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.ImagesNotFound);
            }
            var UpdatedFile = _fileHelper.Update(file, image.ImagePath);
            image.ImagePath = UpdatedFile.Data;
            image.Date = result.Date;
            _imageDal.Update(image);
            return new SuccessResult(Messages.CarImageUpdated);

        }
        //private IResult IsImageExist(int id)
        //{
        //    var result = _imageDal.Get(i => i.Id == id);
        //    if (result != null)
        //    {
        //        return new SuccessResult();
        //    }
        //    return new ErrorResult(Messages.ImagesNotFound);
        //}
        private IResult CheckImageLimitExceeded(int id)
        {
            var imagesCount = _imageDal.GetAll(i => i.CarId == id).Count;
            if (imagesCount >= 5)
            {
                return new ErrorResult(Messages.CarPictureNumberExceded);
            }
            return new SuccessResult();
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
