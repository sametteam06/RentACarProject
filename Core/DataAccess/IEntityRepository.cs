using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAcceess
{
    //T:class ===>> T sadece referans tip olabilir.
    //IEntity ===>> Sadece IEntity türünde referans olabilir.
    //new() ===>> new() yapılabilen (soyut olmayan) türde olabilir.
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T,bool>> filter = null);
    }
}
