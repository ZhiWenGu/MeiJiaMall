using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class wxorderserver
    {
        Wxorder _dao = new Wxorder();
        public int AddWxOrder(string appid, string mac_id, string nonce_str, string sign, string result_code, string openid, string trade_type, string bank_type, int total_fee, int cash_fee, string reansaction_id, string out_trade_no, string time_end)
        {
            return _dao.AddWxOrder(appid, mac_id, nonce_str, sign, result_code, openid, trade_type, bank_type, total_fee, cash_fee, reansaction_id, out_trade_no, time_end);
        }
        public int AddFinalOrder(string openid, string orderid, string out_trade_no)
        {
            return _dao.AddFinalOrder(openid, orderid, out_trade_no);
        }

        public List<FinalOrder> QueryFinalOrderList(string openid)
        {
            return _dao.QueryFinalOrder(openid);
        }
    }
}
