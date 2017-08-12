using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elib.LibCore
{
    public class SqlDataProvider : DataProvider
    {
        private string connectionString;
        public SqlDataProvider():this("DefaultConnection")
        {

        }
        public SqlDataProvider(string connectionStringName)
        {
            this.connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }
        public override DataSet ExecuteDataset(string spName, params object[] parameterValues)
        {
            return SqlHelper.ExecuteDataset(connectionString, spName, parameterValues);
        }

        public override int ExecuteNonQuery(string spName, params object[] parameterValues)
        {
            return SqlHelper.ExecuteNonQuery(connectionString, spName, parameterValues);
        }

        public override object ExecuteNonQueryWithOutput(string outputParam, string spName, params object[] parameterValues)
        {
            if (string.IsNullOrEmpty(outputParam))
                throw new ArgumentException("OutputParam is null or empty");
            SqlParameter[] parameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
            SqlParameter sqlParameter = null;
            foreach (SqlParameter item in parameters)
            {
                if(String.Compare(item.ParameterName, outputParam, true)==0)
                {
                    sqlParameter = item;
                    break;
                }
            }
            if (sqlParameter == null)
                throw new Exception("Parameter not found");

            AssignParameterValues(parameters, parameterValues);
            int rs = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, parameters);
            return (rs > 0) ? sqlParameter.Value : null;

        }

        private void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
                return;
            if (commandParameters.Length != parameterValues.Length)
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            for (int i = 0,j=commandParameters.Length; i <j ; i++)
            {
                commandParameters[i].Value = parameterValues[i];
            }
        }

        public override IDataReader ExecuteReader(string spName, params object[] parameterValues)
        {
            return SqlHelper.ExecuteReader(connectionString, spName, parameterValues);
        }

        public override object ExecuteScalar(string spName, params object[] parameterValues)
        {
            return SqlHelper.ExecuteScalar(connectionString, spName, parameterValues);
        }
    }
}
