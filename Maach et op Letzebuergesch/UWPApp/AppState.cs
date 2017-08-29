using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPApp
{
    class AppState
    {
        string username;

        public AppState()
        {
            this.username = "";
        }
        public AppState(string username)
        {
            this.username = username;
        }
   
        public void SetUsername(string theUsername)
        {
            this.username = theUsername;
        }

        public string GetUsername()
        {
            return this.username;
        }
    }
}
