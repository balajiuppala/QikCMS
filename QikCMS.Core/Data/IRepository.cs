using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QikCMS.Core.Data
{
    public interface IRepository<T> where T: class
    {
        T Create(T model);
        void Update(T model);
        IQueryable<T> GetAll();
    }
}
