using QikCMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace QikCMS.Core.Service
{
    public interface IBaseService<T> where T: class
    {
        IEnumerable<T> GetAll();
        T Create(T model);
        void Update(T model);

    }
}
