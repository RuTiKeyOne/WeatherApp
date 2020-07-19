using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Net;
namespace Weather.View
{
    class InternetConnection
    {

        public static bool CheckInternetConnection()
        {
            try
            {
                using (WebClient client = new WebClient())
                using (client.OpenRead("http://google.com"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
