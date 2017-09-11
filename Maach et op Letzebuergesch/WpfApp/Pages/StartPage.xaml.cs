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
using System.IO;

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

        void stackpanel_MouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel stackpanel = (StackPanel)sender;
            stackpanel.Background = Brushes.Transparent;
        }

        void stackpanel_MouseEnter(object sender, MouseEventArgs e)
        {
            StackPanel stackpanel = (StackPanel)sender;
            stackpanel.Background = Brushes.LightGray;
        }

        private void InitStartPage()
        {
            this.Settings = Settings.Read(UserSettingsPathFile);
            username.Content = this.Settings.Username;
            this.Title = "Wëllkomm "+ username.Content;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*this.StartPage1.NavigationService.Navigate(new Artikel());
            this.WindowTitle = "Artikel verschaffen";*/
            FileInfo fclass = new FileInfo("T:\\00_Source");
            DirectoryInfo dirInfo = new DirectoryInfo("T:\\00_Source");
            stpList.Children.Clear();

            FileInfo[] info = dirInfo.GetFiles("*.docx");
            int Contr = 0;
            foreach (FileInfo f in info)
            {
                StackPanel stpElements = new StackPanel();
                stpElements.Name = "Files" + Contr.ToString();
                stpElements.MouseEnter += new MouseEventHandler(stackpanel_MouseEnter);
                stpElements.MouseLeave += new MouseEventHandler(stackpanel_MouseLeave);
                stpElements.Height = 170;
                Image Icon = new Image();
                Icon.Name = "Icon" + Contr.ToString();
                Icon.Source = new BitmapImage(new Uri(@"/Images/icon-docx.png", UriKind.Relative));
                Icon.Width = 150;
                Icon.Height = 150;
                Icon.Stretch = Stretch.Fill;
                stpElements.Children.Add(Icon);
                TextBlock File = new TextBlock();
                File.Width = 150;
                File.Name = "Docx" + Contr.ToString();
                File.Text = f.Name;
                File.HorizontalAlignment = HorizontalAlignment.Stretch;
                File.TextAlignment = TextAlignment.Center;
                stpElements.Children.Add(File);
                stpList.Children.Add(stpElements);
                Contr++;
            }

        }
    }
}
