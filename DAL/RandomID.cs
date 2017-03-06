using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class RandomID
    {
        
        public static string GetRandomID(string R)
        {
            Random r = new Random();
            string RandomID = "";

            RandomID += R;
           // DateTime.Now();
            RandomID += DateTime.Now.ToString("ddHHmmss");
            RandomID += r.Next(10, 99);
            return RandomID;
        }
    }
}
