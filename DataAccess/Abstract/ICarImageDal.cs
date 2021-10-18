using Core.DataAcceess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarImageDal:IEntityRepository<CarImage>
    {
        public CarImage GetCarsFirstImage(Expression<Func<CarImage, bool>> filter = null);
    }
}
