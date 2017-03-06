using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FinalOrder
    {
       public string OpenId { get; set; }
       public string orderId { get; set; }
       public string out_trade_no { get; set; }
       public DateTime createtime { get; set; }

        int opay { get; set; }
    }
}
