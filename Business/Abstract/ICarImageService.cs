using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IResult Add(CarImage entity, IFormFile file);
        IResult Update(CarImage entity, IFormFile file);
        IResult Delete(CarImage entity);
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetByCarId(int id);
    }
}
