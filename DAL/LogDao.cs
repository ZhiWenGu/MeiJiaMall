using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class LogDao
    {
        static string sqlconnstr = ConfigurationManager.ConnectionStrings["loginsql"].ConnectionString;
        public  void InfoLog(string type,string classname,string content)
        {
            string sql =string.Format("insert into logtab(type,createtime,classname,content) values('{0}','{1}','{2}','{3}')",type,DateTime.Now,classname,content);
            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                try
                {

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }

                
            }
        }
    }
}
