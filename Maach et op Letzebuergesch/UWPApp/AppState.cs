using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeoL
{
    class AppState
    {
        string username;
        string openfilepath;

        public AppState()
        {
            this.username = "";
            this.openfilepath = null;
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

        public void SetOpenFilePath(string theFilePath)
        {
            this.openfilepath = theFilePath;
        }

        public string GetOpenFilePath()
        {
            return this.openfilepath;
        }
    }
}
