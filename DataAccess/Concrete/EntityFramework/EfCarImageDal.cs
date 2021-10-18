using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RentACarContext>, ICarImageDal
    {
        public CarImage GetCarsFirstImage(Expression<Func<CarImage, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<CarImage>().FirstOrDefault(filter);
            }
        }
    }
}
