using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Model;
using Dapper;
namespace DAL
{
    public class Wxorder:BaseSql
    {
        public int AddWxOrder(string appid, string mac_id, string nonce_str, string sign, string result_code, string openid, string trade_type, string bank_type, int total_fee, int cash_fee, string reansaction_id, string out_trade_no, string time_end)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                string sql = string.Format("insert into wxorder values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},{9},'{10}','{11}','{12}')", appid, mac_id, nonce_str, sign, result_code, openid, trade_type, bank_type, total_fee, cash_fee, reansaction_id, out_trade_no, time_end);
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int AddFinalOrder(string openid, string orderid, string out_trade_no)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                string sql = string.Format("insert into finalorder(openid,orderid,out_trade_no) values ('{0}','{1}','{2}')", openid, orderid, out_trade_no);
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FinalOrder> QueryFinalOrder(string openid)
        {
            string sql = "select * from finalorder where openid = @openid and opay = 1 order by createtime desc";
            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                return conn.Query<FinalOrder>(sql, new { @openid = openid }).ToList();
            }
        }
    }
}
