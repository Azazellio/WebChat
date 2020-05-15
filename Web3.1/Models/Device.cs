using System;
using System.Collections.Generic;

namespace Web2.Models
{
    public class Device
    {
        private int ip;
        private List<DateTime> logins;
        public Device(int ip)
        {
            this.logins = new List<DateTime>();
            this.ip = ip;
            this.logins.Add(DateTime.Now);
        }
        public void Login()
        {
            this.logins.Add(DateTime.Now);
        }
    }
}
