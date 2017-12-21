using QikCMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QikCMS.Data.EF
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IDataContext dataContext;
        public Repository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public T Create(T model)
        {
            
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
