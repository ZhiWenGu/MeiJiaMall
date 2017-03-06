using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{

    public class SinglePayServer
    {
        SinglePayDao _dao = new SinglePayDao();
        CartOrderDao _cdao = new CartOrderDao();
        public string AddSinglePay(SinglePay sin)
        {
            return _dao.AddSinglePay(sin);
        }

        public SinglePay QuerySingle(string sid)
        {
            return _dao.QuerySinglePay(sid);
        }

        public string QueryOrderGidByTrade(string trade)
        {
            if (_dao.IsContain(trade))
            {
                return _dao.QuerySinglePayByTrade(trade).GID;
            }
            else
            {
               CartOrder co = _cdao.QueryCartByTrade(trade);
               if (co != null)
               {
                   return _cdao.QueryGoodList(co.GLID).GID;
               }
                return "";
            }
            
        }
        public int UpdateSinglePay(string sid, string tel, string name, string address)
        {
            return _dao.UpdateAdd(sid, address, tel, name);
        }


        public bool IsContain(string trade)
        {
            return _dao.IsContain(trade);
        }

        
    }

}
