using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELib.BLL.Repositories
{
   public interface IGenericRepository<T> where T:IEntity
    {
        int Count();
        T Single(object id);
        List<T> GetAll();
        List<T> Find(string keyword);
        List<T> Paging(int pageIndex, int pageSize, out int howManyPages);
        bool Add(T item);
        bool Update(T item);
        bool Delete(object id);
        bool DeleteMany(params object[] ids);
    }
}
