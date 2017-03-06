using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class ShoppingCarServer
    {
        ShoppingCarDao _dao = new ShoppingCarDao();
        GoodsDao G_dao = new GoodsDao();
        public int AddShoppingCar(ShoppingCar car)
        {
            if (_dao.IsContain(car))
            {
                return _dao.UpdateShoppingCar(car);
            }
            else
                return _dao.AddShoppingCar(car);
        }
        public List<Goods> QueryGoods(string openid)
        {
            List<ShoppingCar> carlist = _dao.QueryAllCart(openid);
            List<Goods> goodslist = new List<Goods>();
            foreach (ShoppingCar car in carlist)
            {
                goodslist.Add(G_dao.GetGoods(car.GID));
            }
            return goodslist;
        }

        public List<ShoppingCar> QueryShoppingCar(string openid)
        {
            return _dao.QueryAllCart(openid);
        }
    }
}
