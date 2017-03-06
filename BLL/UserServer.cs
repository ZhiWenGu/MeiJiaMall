using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class UserServer
    {
        UserDao _dao = new UserDao();
        public  int CheckUser(string phone,string password){
            
            return _dao.CheckUser(phone, password);
        }

        public  int InsertUser(string name,string phone,string email,string password)
        {
            
            return _dao.InsertUser(name, phone, email, password);
        }

        public User GetUser(string id)
        {
            if (id == "" || id == null)
            {
                return null;
            }
            else
            {
                return _dao.GetUser(id);
            }
           
        }
    }
}
