using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SinglePayDao : BaseSql
    {
        //static string sqlconnstr = ConfigurationManager.ConnectionStrings["loginsql"].ConnectionString;
        public string AddSinglePay(SinglePay sin)
        {
            sin.SID = RandomID.GetRandomID("S");
            sin.CreateTime = DateTime.Now;
            //adr.AID = RandomID.GetRandomID("A");
            using (IDbConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                conn.Execute(@"insert singlebuy(openid,GID,Gcount,createtime,sid) values(@openid,@GID,@Gcount,@createtime,@sid)", new { openid = sin.OpenID, GID = sin.GID, Gcount = sin.GCount, createtime = sin.CreateTime, sid = sin.SID });
                return sin.SID;
            }
        }

        public SinglePay QuerySinglePay(string sid)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                return conn.Query<SinglePay>("select * from singlebuy where sid = @sid", new { @sid = sid }).SingleOrDefault();
            }
        }

        public SinglePay QuerySinglePayByTrade(string trade)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                return conn.Query<SinglePay>("select * from singlebuy where sid = @trade", new { @trade = trade }).SingleOrDefault();
            }
        }
        public int UpdateAdd(string sid, string add, string tel, string name)
        {
            using (IDbConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                return conn.Execute("update singlebuy set address = @address,phone = @phone,name=@name where sid = @sid", new { address = add, phone = tel, name = name, sid = sid });
            }
        }

        public bool IsContain(string trade)
        {
            trade = ClearParams(trade);
            string sql = string.Format("select count(*) from singlebuy where sid = '{0}'", trade);
            return ExecuteScalar(sql) > 0;
        }

        
    }
}
