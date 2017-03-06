using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class GoodsServer
    {
        GoodsDao dao = new GoodsDao();
        public  List<Goods> GetGoodsList(string type)
        {
            return dao.GetGoodsList(type);
        }

        public  int AddGoods(string GName, string GType, double GPrice, int GCount, string GDescription, string Gpicture)
        {
            return dao.AddGoods(GName, GType, GPrice, GCount, GDescription, Gpicture);
        }


        public Goods GetGoods(string id)
        {
            return dao.GetGoods(id);
        }


    }
}
