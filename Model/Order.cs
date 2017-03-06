using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        public string OID { get; set; }
        public string GID { get; set; }
        public string UID { get; set; }
        public string AID { get; set; }
        public string SID { get; set; }
        public double OCount { get; set; }
        public bool OPay { get; set; }
        public string OStatus { get; set; }
        public string OSendTime { get; set; }
        public string OGetTime { get; set; }

        public string OMailCompany { get; set; }
        public string OGoodsInf { get; set; }
        public string OCoordersmment { get; set; }
        public string OCreateTime { get; set; }

    }
}
