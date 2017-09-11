using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.UI.Core;
using System.Globalization;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MeoL
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public static class MsgBox
        {
            static public async void Show(string mytext, string title)
            {
                var dialog = new MessageDialog(mytext, title);
                await dialog.ShowAsync();
            }
        }

        private void edtPassword_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                btnLogin_Click(this, e);
            }
            //Login();
            
        }

        public void Login(string Username)
        {
            AppState LeAppState = ((App)Application.Current).TheAppState;
            LeAppState.SetUsername(Username);
        }

        private string ToTitleCase(string str)
        {
            string auxStr = str.ToLower();
            string[] auxArr = auxStr.Split(' ');
            string result = "";
            bool firstWord = true;
            foreach (string word in auxArr)
            {
                if (!firstWord)
                    result += " ";
                else
                    firstWord = false;

                result += word.Substring(0, 1).ToUpper() + word.Substring(1, word.Length - 1);
            }
            return result;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //check login
            string theusername = edtUsername.Text;
            string theusernamesw = theusername.ToLower();
            TextInfo myTI = new CultureInfo("de-LU").TextInfo;
            theusername = ToTitleCase(theusernamesw);
            switch (theusernamesw)
            {
                case "jill": if (edtPassword.Password == "aaa123")
                    { //OK 
                        Login(theusername);
                        this.Frame.Navigate(typeof(Overview));
                    }
                    else MsgBox.Show("Your password is wrong", "Wrong Password");
                    break;
                default:
                    MsgBox.Show("Username not found","Wrong Username");
                    break;
            }

        }
    }
}
