using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetworkUtility.Ping
{
    public class NetworkServices
    {
        public string SengPing()
        {
            return "Success: Ping sent";
        }
        public int PingTimeout(int a,int b)
        {
            return a + b;
        
        }

    }
}
