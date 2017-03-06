using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 首页开发.business
{
    public class SqlServer
    {
        public const string connStr = "server=115.159.119.182;database=onlinemail;uid=sa;pwd=ZHIwen1995";
        public static bool IsContain(string name)
        {
            string sql = "select count(*) from character where name = '" + name + "'";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    int k = (int)cmd.ExecuteScalar();
                    if (k == 1)
                        return true;
                    else
                        return false;
                }
            }

        }

        public static int Add(string name, int[] value)
        {
            try
            {
                string sql = string.Format("insert into character values('{0}',{1},{2},{3},{4},{5},{6},{7},{8},{9})", name, value[0], value[1], value[2], value[3], value[4], value[5], value[6], value[7], value[8]);
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                return -1;

            }
        }

        public static int[] Search(string name)
        {
            int[] list = new int[9];
            string sql = "select value1,value2,value3,value4,value5,value6,value7,value8,value9 from character where name = '" + name + "'";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int i = 0; i < list.Length; i++)
                        {
                            list[i] = (int)reader[i];
                        }
                    }
                    reader.Close();
                    return list;
                }
            }
        }
    }
}