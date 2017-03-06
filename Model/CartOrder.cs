using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CartOrder
    {
        public string Openid { get; set; }
        public string GLID { get; set; }
        public DateTime CreateTime { get; set; }
        public string COID { get; set; }
        public string Phone { get; set; }
        public string Address{get;set;}
    }
}
