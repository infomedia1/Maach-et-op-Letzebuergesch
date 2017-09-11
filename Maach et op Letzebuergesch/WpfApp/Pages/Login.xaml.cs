using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Classes;

namespace WpfApp.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public const string UserSettingsFilename = "user-settings.xml";
        public string UserSettingsPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Settings\\";
        public string UserSettingsPathFile = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Settings\\" + UserSettingsFilename;
        public MySettings Settings = new MySettings();

        public Boolean Returninguser;

        public Login()
        {
            InitializeComponent();

            //this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
           // this.KeyDown += new KeyEventHandler(HandleEsc);

            CheckOldLogin();

            AddaptLayoutToUserSetup();
        }

        private void CheckOldLogin()
        {
            if (File.Exists(UserSettingsPathFile))
            {
                this.Settings = Settings.Read(UserSettingsPathFile);
                
                if (this.Settings.Username.Length>0)
                {
                    username.Content = this.Settings.Username;
                    edtUsername.Text = this.Settings.Username;
                    this.Returninguser = true;
                } else
                {
                    this.Returninguser = false;
                }
            } else
            {
                if (!Directory.Exists(UserSettingsPath))
                {
                    Directory.CreateDirectory(UserSettingsPath);
                }
                if (!File.Exists(UserSettingsPathFile))
                {
                    //File.Create(UserSettingsPathFile);
                }

                Settings.Save(UserSettingsPathFile);
                this.Returninguser = false;
            }
        }

        private void AddaptLayoutToUserSetup()
        {
            if (Returninguser)
            {
                edtUsername.Visibility = Visibility.Collapsed;
                edtPassword.Visibility = Visibility.Collapsed;
                btnLogin.Visibility = Visibility.Collapsed;
            } else
            {
                existingUser.Visibility = Visibility.Collapsed;
            }
            
        }

        private void ExistingUser_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //existing User
            newUser.Visibility = Visibility.Collapsed;
            //edtUsername.Visibility = Visibility.Visible;
            edtPassword.Visibility = Visibility.Visible;
            btnLogin.Visibility = Visibility.Visible;
            edtPassword.Focus();
        }

        private void NewUser_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            existingUser.Visibility = Visibility.Collapsed;
            edtUsername.Visibility = Visibility.Visible;
            edtPassword.Visibility = Visibility.Visible;
            btnLogin.Visibility = Visibility.Visible;
            edtUsername.Focus();
        }

        public void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if (Returninguser)
                {
                    edtUsername.Visibility = Visibility.Collapsed;
                    edtPassword.Visibility = Visibility.Collapsed;
                    btnLogin.Visibility = Visibility.Collapsed;
                    existingUser.Visibility = Visibility.Visible;
                    newUser.Visibility = Visibility.Visible;
                }
                else
                {
                    existingUser.Visibility = Visibility.Collapsed;
                    newUser.Visibility = Visibility.Visible;
                    edtUsername.Visibility = Visibility.Visible;
                    edtPassword.Visibility = Visibility.Visible;
                    btnLogin.Visibility = Visibility.Visible;
                }
                edtUsername.Text = "";
                edtPassword.Password = "";
                lblWrong.Visibility = Visibility.Collapsed;
            }
            e.Handled = true;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Login check

            LoginChecker thelogin = new LoginChecker();
            Boolean loginchecktrue = thelogin.Checkpassword(edtUsername.Text, edtPassword.Password);
            if (loginchecktrue)
            {
                //Login ok; save Username
                this.Settings.Username = edtUsername.Text;
                this.Settings.Save(UserSettingsPathFile);

                //GoTo StartPage
                this.LoginPage.NavigationService.Navigate(new StartPage());
            }
            else
            {
                lblWrong.Visibility = Visibility.Visible;
                edtPassword.Password = "";
            }
        }

        private void EdtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }
    }
}
