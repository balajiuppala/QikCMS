using QikCMS.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using QikCMS.Core.Model;
using QikCMS.Core.Data;
using System.Linq;

namespace QlikCMS.Services
{
    public class BlogService : IBlogService
    {
        private readonly IDataContext dataContext;
        private readonly IRepository<Post> blogRepository;
        public BlogService (IDataContext dataContext)
        {
            this.dataContext = dataContext;
            blogRepository = this.dataContext.Repository<Post>();
        }
        public Post Create(Post model)
        {
            GenerateUniqueSlug(model);
            var newBlog = blogRepository.Create(model);
            //var result = dataContext.Repository<Blog>().GetAll().ToList();
            return newBlog;
        }

        private void GenerateUniqueSlug(Post blog)
        {
            var duplicatesCount = AvailbleDuplicateSlugs(blog);
            if (duplicatesCount > 0)
            {
                blog.Slug = blog.Slug.Length > 120 ? (blog.Slug.Substring(0, blog.Slug.Length - 4) + "-" + (duplicatesCount + 1)): blog.Slug;
            }
        }

        private int AvailbleDuplicateSlugs(Post blog)
        {
            return blogRepository.GetAll().Count(b => b.Slug.Equals(blog.Slug) && !b.Id.Equals(blog));
        }

        public IEnumerable<Post> GetAll()
        {
            return blogRepository.GetAll();
        }

        public void Update(Post model)
        {
            var existingBlog = blogRepository.GetAll().FirstOrDefault(b => b.Id.Equals(model.Id));
            if (existingBlog == null)
                throw new Exception(@"Record not found");
            existingBlog.Content = model.Content;
            existingBlog.Title = model.Title;
            existingBlog.IsArchived = model.IsArchived;
            existingBlog.IsFeatured = model.IsFeatured;
            existingBlog.IsPublished = model.IsPublished;
            existingBlog.PublishedDate = model.PublishedDate;
            existingBlog.LastModifiedOn = DateTime.UtcNow;
            existingBlog.MetaDescription = model.MetaDescription;
            existingBlog.Slug = model.Slug;

            existingBlog.Tags.Clear();
            existingBlog.Tags.AddRange(model.Tags);
            //blogRepository.Update(existingBlog);
            blogRepository.Update(existingBlog);
        }

        public Post FindBySlug(string slug)
        { 
            var blog = blogRepository.GetAll().FirstOrDefault(b => b.IsPublished && b.Slug.Equals(slug));
            if(blog == null)
            {
                throw new Exception("Blog Not Found");
            }
            return blog;
        }
    }
}
