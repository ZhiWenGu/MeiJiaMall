using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CartOrderServer
    {
        CartOrderDao _dao = new CartOrderDao ();
        
        public double AddCartOrder(string Glid){
            //生成订单并返回订单价格
            
                return _dao.GetTotal(Glid);
          
        }

        public int UpdateCartOrder(string glist, string add, string tel, string name)
        {
            return _dao.UpdateCartOrder(glist, add, tel, name);
        }
        public string GetGLid(CartOrder car)
        {
            return _dao.AddCartOrder(car);
        }
    }
}
