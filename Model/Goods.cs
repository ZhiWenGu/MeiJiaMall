using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Model
{
    public class Goods
    {
       public string GID { get; set; }
       public string GName { get; set; }
       public string GType { get; set; }
       public double GPrice { get; set; }
       public int GCount { get; set; }
       public string Gdescription { get; set; }
       public int GCollection { get; set; }
       public string Gpicture { get; set; }
    }
}
