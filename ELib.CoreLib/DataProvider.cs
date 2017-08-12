using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELib.LibCore
{
    public abstract class DataProvider
    {
        private static DataProvider instance = null;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new SqlDataProvider();
                return instance;
            }
        }
        public abstract object ExecuteNonQueryWithOutput(string outputParam, string spName, params object[] parameterValues);
        public abstract int ExecuteNonQuery(string spName, params object[] parameterValues);
        public abstract DataSet ExecuteDataset(string spName, params object[] parameterValues);
        public abstract IDataReader ExecuteReader(string spName, params object[] parameterValues);
        public abstract object ExecuteScalar(String spName, params object[] parameterValues);

    }
}
