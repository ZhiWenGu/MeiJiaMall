using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SinglePay
    {
        public SinglePay()
        {

        }
        public SinglePay(string openid, string gid, int count)
        {
            this.OpenID = openid;
            this.GID = gid;
            this.GCount = count;
        }
        public string OpenID { get; set; }
        public string GID { get; set; }
        public int GCount { get; set; }
        public DateTime CreateTime { get; set; }
        public string SID { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public int SPay { get; set; }
    }
}
