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
    public class AddressDao
    {
        static string sqlconnstr = ConfigurationManager.ConnectionStrings["loginsql"].ConnectionString;

        public int AddAddress(Address adr)
        {
            adr.AID = RandomID.GetRandomID("A");
            using (IDbConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                return conn.Execute(@"insert Address(AID,UID,AName,APhone,AAddress,APostalCode) values(@AID,@UID,@AName,@APhone,@AAddress,@APostalCode)", new { AID = adr.AID, UID = adr.UID, AName = adr.AName, APhone = adr.APhone, AAddress = adr.AAddress,  b = adr.APostalCode });
            }
        }


        public int UpdateAddress(string key, string value, string AID)
        {
            string sql = string.Format("update Address set {0} = '{1}' where AID = '{3}'", key, value, AID);
            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Address> GetAddress(User u)
        {
            using (IDbConnection conn = new SqlConnection(sqlconnstr))
            {
                conn.Open();
                return conn.Query<Address>(@"select * from address where uid = @uid", new { uid = u.UID }).ToList();
            }
        }
    }
}
