using QikCMS.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QikCMS.Core.Service
{
    public interface IBlogService: IBaseService<Post>
    {
        Post FindBySlug(string slug);
    }
}
