using QikCMS.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QikCMS.Core.Data
{
    public interface IDataContext
    {
        IRepository<T> Repository<T>() where T : BaseModel;
        
    }
}
