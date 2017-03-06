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
    public class GoodsDao : BaseSql
    {
        //static string connstr = ConfigurationManager.ConnectionStrings["loginsql"].ConnectionString;


        public List<Goods> GetGoodsList(string type)
        {
            List<Goods> goodslist = new List<Goods>();
            using (IDbConnection conn = new SqlConnection(sqlconnstr))
            {
                string query = "select top 8 * from Goods where GType = @type ";
                conn.Open();
                goodslist = conn.Query<Goods>(query, new { type = type }).ToList();
                return goodslist;
            }
        }

        public Goods GetGoods(string id)
        {
            id = ClearParams(id);
            //hhhhh
            string query = string.Format("select * from Goods where GID = '{0}' ",id);
            return GetQuerySingle<Goods>(query);

        }

        public int AddGoods(string gName, string gType, double gPrice, int gCount, string gDescription, string gpicture)
        {
            Random rnd = new Random();
            string gID = DateTime.Now.ToString("yyyyMMddHHmmssfff") + rnd.Next(10, 99).ToString();
            using (IDbConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                return conn.Execute(@"insert goods(GID,GName,GType,GPrice,GCount,Gdescription,Gpicture) values(@GID,@GName,@GType,@GPrice,@GCount,@Gdescription,@Gpicture)", new { GID = gID, GName = gName, GType = gType, GPrice = gPrice, GCount = gCount, Gdescription = gDescription, Gpicture = gpicture });
            }
        }
    }
}
