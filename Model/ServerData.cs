using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ServerData
    {
        Dictionary<string, string> dic;
        public ServerData()
        {
            dic = new Dictionary<string, string>();
        }

        public void SetValue(string key, string value)
        {
            dic.Add(key, value);
        }

        public string GetValue(string key)
        {
            return dic[key];
        }

        public bool IsInsert(string key)
        {
            return dic.ContainsKey(key);
        }

        
    }
}
