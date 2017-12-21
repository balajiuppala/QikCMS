using Microsoft.EntityFrameworkCore;
using QikCMS.Core.Data;
using QikCMS.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QikCMS.Data.EF.MSSQL
{
    public class DataContext : DbContext, IDataContext
    {
        private readonly string connectionString;
        public DataContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasIndex(b => b.Slug);
            modelBuilder.Entity<Post>().Property(b => b.LastModifiedOn).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<PostTag>().HasKey(bt => new { bt.BlogId, bt.Name });
            modelBuilder.Entity<PostComment>().Property(b => b.PostedOn).HasDefaultValueSql("getdate()");
        }

        public IRepository<T> Repository<T>() where T : BaseModel
        {
            return repositories.ContainsKey(typeof(T)) ? (IRepository<T>)repositories[typeof(T)] : GenerateRepository<T>();
        }

        private IRepository<T> GenerateRepository<T>() where T: BaseModel
        {
            repositories.Add(typeof(T), new Repository<T>(this));
            return (IRepository <T>)repositories[typeof(T)];
        }

        IDictionary<Type, object> repositories = new Dictionary<Type, object>();
    
    }
}
