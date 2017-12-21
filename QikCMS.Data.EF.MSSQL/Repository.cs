using QikCMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QikCMS.Data.EF.MSSQL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> dbSet;
        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        public T Create(T model)
        {
            this.dbSet.Add(model);
            this.dbContext.SaveChanges();
            return model;
        }

        public IQueryable<T> GetAll()
        {
            return this.dbSet;
        }

        public void Update(T model)
        {
            //dbSet.Attach(model);
            //dbSet.Update(model);
            dbContext.SaveChanges();
        }
    }
}
