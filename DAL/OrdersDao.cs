using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class OrdersDao
    {
        static string sqlconnstr = ConfigurationManager.ConnectionStrings["loginsql"].ConnectionString;
        public int AddOreder(Order or)
        {
            or.OID = RandomID.GetRandomID("O");
            using (IDbConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                return conn.Execute(@"insert orders(OID,GID,UID,AID,SID,OCount,OCoordersmment) values(@OID,@GID,@UID,@AID,@SID,@OCount,@OCoordersmment)", new { OID = or.OID, GID = or.GID, UID = or.UID, AID = or.AID, SID = or.SID, OCount = or.OCount, OCoordersmment = or.OCoordersmment });
            }
        }
    }
}
