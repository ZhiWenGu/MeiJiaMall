using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace DAL
{
    public class BaseSql
    {
        protected string sqlconnstr = ConfigurationManager.ConnectionStrings["loginsql"].ConnectionString;
        public int ExecuteScalar(string sql)
        {
            //sql = ClearSql(sql);
            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    try
                    {
                        conn.Open();
                        return (int)cmd.ExecuteScalar();
                    }
                    catch (Exception)
                    {
                        return 0;
                        throw;
                    }
                }
            }
        }

        protected string ClearParams(string Params)
        {
            if (Params.Contains("'") || Params.Contains("*") || Params.Contains("."))
                return "";
            else
                return Params;
        }

        protected T GetQuerySingle<T>(string sql)
        {
            using (IDbConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                return conn.Query<T>(sql).SingleOrDefault();
            }
        }
    }
}
