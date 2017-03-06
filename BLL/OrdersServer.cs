using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
    public class OrdersServer
    {
        OrdersDao _dao = new OrdersDao();
        public int AddOrders(Order or)
        {
            return _dao.AddOreder(or);
        }
    }
}
