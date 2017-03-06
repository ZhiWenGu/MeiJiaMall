using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using Model;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class CartOrderDao:BaseSql
    {
        // static string sqlconnstr = ConfigurationManager.ConnectionStrings["loginsql"].ConnectionString;
        public string AddCartOrder(CartOrder co)
        {
            co.COID = RandomID.GetRandomID("CO");
            co.CreateTime = DateTime.Now;
            co.GLID = RandomID.GetRandomID("GL");

            using (IDbConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                conn.Execute(@"insert cartorder(openid,coid,createtime,glid) values(@openid,@coid,@createtime,@glid)", new { @openid = co.Openid, @coid = co.COID, @createtime = co.CreateTime, @glid = co.GLID });
            }
            return co.GLID;
        }
        public int UpdateCartOrder(string glist, string add, string tel, string name)
        {

            using (IDbConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                return conn.Execute(@"update cartorder set address = @address,phone = @phone,name=@name where glid = @glid", new { address = add, phone = tel, name = name, glid = glist });
            }
        }
        public double GetTotal(string Glist)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                string sql = string.Format("select sum (total) from glist where glid = '{0}'", Glist);
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    return Convert.ToDouble(cmd.ExecuteScalar());
                }
            }
        }

        public CartOrder QueryCartByTrade(string trade)
        {
            trade = ClearParams(trade);
            string sql = string.Format("select * from cartorder where coid = '{0}'",trade);
            return GetQuerySingle<CartOrder>(sql);
        }

        public GoodList QueryGoodList(string glist)
        {
            glist = ClearParams(glist);
            string sql = string.Format("select top 1 * from glist where glid = '{0}'");
            return GetQuerySingle<GoodList>(sql);
        }


    }
}
