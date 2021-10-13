using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserImageService
    {
        IDataResult<List<UserImage>> GetAll();
        IResult Add(UserImage entity, IFormFile file);
        IResult Update(UserImage entity, IFormFile file);
        IResult Delete(UserImage entity);
        IDataResult<UserImage> GetById(int id);
        IDataResult<UserImage> GetByUserId(int id);
    }
}
