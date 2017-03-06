using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class AddressServer
    {
        AddressDao _dao = new AddressDao();
        public int AddAddress(Address adr)
        {
            return _dao.AddAddress(adr);
        }

        public List<Address> GetAddress(User u)
        {
            return _dao.GetAddress(u);
        }
    }
}
