using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class LogServer
    {
       static LogDao _dao = new LogDao();
        public static void AddLog(string type,string classname,string content)
        {
            _dao.InfoLog(type, classname, content);
        }
    }
}
