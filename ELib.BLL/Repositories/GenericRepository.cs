using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELib.LibCore;
using ELib.Utilities;
namespace ELib.BLL.Repositories
{
    public class GenericRepository<T> :IGenericRepository<T> where T:class, IEntity, new()
    {
        private string typeName;
        public GenericRepository()
        {
            typeName = typeof(T).Name;
        }

        public bool Add(T item)
        {
            try
            {
                var id = DataProvider.Instance.ExecuteNonQueryWithOutput("@MaSo", typeName + "_Add", item.GetInsertUpdateValues());
                if (id == null)
                    return false;
                item.MaSo = id.To<int>();
                return item.MaSo > 0;
            }
            catch
            {
                return false;
            }
        }

        public int Count()
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar(typeName + "_Count").To<int>();

            }
            catch 
            {
                return 0;
            }
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMany(params object[] ids)
        {
            throw new NotImplementedException();
        }

        public List<T> Find(string keyword)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<T> Paging(int pageIndex, int pageSize, out int howManyPages)
        {
            throw new NotImplementedException();
        }

        public T Single(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
