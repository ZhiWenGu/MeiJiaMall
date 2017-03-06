using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dapper;

namespace DAL
{
    public class ShoppingCarDao
    {
        static string sqlconnstr = ConfigurationManager.ConnectionStrings["loginsql"].ConnectionString;

        public int AddShoppingCar(ShoppingCar car)
        {
            car.SID = RandomID.GetRandomID("S");
            using (IDbConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                return conn.Execute("insert shoppingcar(GID,UID,SID,SCount,SPay) values(@GID,@UID,@SID,@SCount,@SPay)", new { GID=car.GID, UID=car.UID, SID=car.SID, SCount=car.SCount, SPay=car.SPay });
            }
        }

        public bool IsContain(ShoppingCar car)
        {
            string sql = string.Format("select count(*) from shoppingcar where gid = '{0}' and uid = '{1}' and spay = 0",car.GID,car.UID);
            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    int k = (int)cmd.ExecuteScalar();
                    if (k >= 1)
                        return true;
                    else
                        return false;
                }
            }
        }

        public int UpdateShoppingCar(ShoppingCar car)
        {
            using (IDbConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                return conn.Execute("update shoppingcar set scount =scount + @scount where gid = @GID and UID = @UID and Spay =0", new {scount = car.SCount,GID = car.GID, UID = car.UID });
            }
        }

        //public int UpdateShoppingCar(string key, string value, string SID)
        //{
        //    string sql = string.Format("update shoppingcar set {0} = '{1}' where AID = '{3}'", key, value, SID);
        //    using (SqlConnection conn = new SqlConnection(sqlconnstr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(sql, conn))
        //        {
        //            conn.Open();
        //            return cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        public List<ShoppingCar> QueryAllCart(string openid)
        {
            string sql = string.Format("select * from shoppingcar where UID = @UID and Spay = 0");
            using (IDbConnection conn = new SqlConnection(sqlconnstr))
            {
                return conn.Query<ShoppingCar>(sql, new { @UID = openid }).ToList();
            }
        }
    }
}
