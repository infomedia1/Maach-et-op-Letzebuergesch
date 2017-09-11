using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Classes
{
    class LoginChecker
    {
        public Boolean Checkpassword(string username, string password)
        {
            switch (username.ToLower())
            {
                default:
                {
                    return false;
                }
                case "jill":
                    {
                        if (password == "aaa123")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
            }
            
        }
    }
}
