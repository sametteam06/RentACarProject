using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car entity);
        IResult Update(Car entity);
        IResult Delete(Car entity);
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByDisplacementId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<CarDetailDto> GetCarDetailById(int id);
        IDataResult<List<CarMainPageDto>> GetCarsForMainPage();
        IDataResult<List<CarMainPageDto>> GetCarsForMainPageByBrandId(int id);
        IDataResult<List<CarMainPageDto>> GetCarsForMainPageByDisplacementId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByDisplacementId(int id);


    }
}
