using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using MeoL;
using MeoL.Assets.Forms;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Pickers;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MeoL.Assets.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartPage : Page
    {
        public StartPage()
        {
            this.InitializeComponent();
        }



        private async System.Threading.Tasks.Task BtnUpload_ClickAsync(object sender, RoutedEventArgs e)
        {
            //var ParentFrame = this.Frame as Frame;
            var ParentFrame = this.Parent as Frame;
            var ThePageGrid = ParentFrame.Parent as Grid;

            var OurCommandBar = FindControl<CommandBar>(ThePageGrid, typeof(CommandBar), "TheCommandBar");

            AppState LeAppState = ((App)Application.Current).TheAppState;

            FileOpenPicker opener = new FileOpenPicker();
            opener.FileTypeFilter.Add(".docx");

            StorageFile file = await opener.PickSingleFileAsync();
            if (file != null)
            {
                LeAppState.SetOpenFilePath(file.Path);
                OurCommandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Compact;
            }

            ParentFrame.Navigate(typeof(TheArticle));
        }


        public static T FindControl<T>(UIElement parent, Type targetType, string ControlName) where T : FrameworkElement
        {

            if (parent == null) return null;

            if (parent.GetType() == targetType && ((T)parent).Name == ControlName)
            {
                return (T)parent;
            }
            T result = null;
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                UIElement child = (UIElement)VisualTreeHelper.GetChild(parent, i);

                if (FindControl<T>(child, targetType, ControlName) != null)
                {
                    result = FindControl<T>(child, targetType, ControlName);
                    break;
                }
            }
            return result;
        }

        private async void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            await BtnUpload_ClickAsync(sender, e);
        }
    }
}
