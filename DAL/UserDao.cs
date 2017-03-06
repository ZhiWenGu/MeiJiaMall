using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Model;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class UserDao:BaseSql
    {
        

        public int InsertUser(string name,string phone,string email,string password)
        {
            string uid = RandomID.GetRandomID("U");

            string token = RandomID.GetRandomID("T");

            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                return conn.Execute(@"insert users(UID,UName,UPassword,UPhone,UEMail,UToken) values(@UID,@UName,@UPassword,@UPhone,@UEMail,@UToken)", new { UID = uid, UName = name, UPassword = password,UPhone = phone, UEMail = email, UToken = token });
            }
        }


        public int CheckUser(string phone, string password)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                string sql = string.Format("select count(*) from users where UPhone = '{0}' and UPassword = '{1}'",phone,password);
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    return (int)cmd.ExecuteScalar();                    
                }
            }
        }


        public User GetUser(string uid)
        {
            string query = "select * from users where UPhone =@id";
            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                return conn.Query<User>(query, new { id = uid }).SingleOrDefault();
            }
        }
    }
}
