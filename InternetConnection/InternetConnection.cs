using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace InternetConnection
{
    class InternetConnection
    {
        public bool CheckInternetConnection()
        {
            string Host = "http://google.com";
            Ping P = new Ping();
            try
            {
                PingReply Reply = P.Send(Host, 3000);
                if (Reply.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch { }
            return false;
        }
    }
}
