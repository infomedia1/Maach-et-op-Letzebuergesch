using System;
using System.Collections.Generic;
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
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public const string UserSettingsFilename = "user-settings.xml";
        public string UserSettingsPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Settings\\";
        public string UserSettingsPathFile = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Settings\\" + UserSettingsFilename;
        public MySettings Settings = new MySettings();


        public StartPage()
        {
            InitializeComponent();

            InitStartPage();
        }

        private void InitStartPage()
        {
            this.Settings = Settings.Read(UserSettingsPathFile);
            username.Content = this.Settings.Username;

        }

        private void ExpandButton_Click(object sender, RoutedEventArgs e)
        {
            if (SideBar.Visibility == System.Windows.Visibility.Collapsed)
            {
                SideBar.Visibility = System.Windows.Visibility.Visible;
                (sender as Button).Content = "<";
            }
            else
            {
                SideBar.Visibility = System.Windows.Visibility.Collapsed;
                (sender as Button).Content = ">";
            }
        }
    }
}
