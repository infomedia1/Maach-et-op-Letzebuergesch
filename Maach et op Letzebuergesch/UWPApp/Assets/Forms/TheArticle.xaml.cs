using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.IO.Compression;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Validation;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using W = DocumentFormat.OpenXml.Wordprocessing;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MeoL.Assets.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TheArticle : Page
    {
        public string FilePath = null;
        public TheArticle()
        {
            this.InitializeComponent();
            AppState LeAppState = ((App)Application.Current).TheAppState;
            this.FilePath = LeAppState.GetOpenFilePath();
            this.HeaderText.Text = this.FilePath;

            this.

            ShowLoadingIndicator(true);
             /*var t = Task.Run(() => InitWFile(this.FilePath));
             t.Wait();
             */
            //InitWFile(this.FilePath);
        }

        public void InitWFile(string theFilepath)
        {
            // XmlDocument theDocument = null;

            var fileInfo = new FileInfo(theFilepath);

            string tempFile = Path.GetTempPath();

            Task T = Task.Run(() => { System.IO.File.Copy(fileInfo.FullName, tempFile + ".docx"); });


            Task T2 = Task.Run(() => { WordprocessingDocument theDocument = WordprocessingDocument.Open(fileInfo.FullName, false);
                W.Body body = theDocument.MainDocumentPart.Document.Body;
                foreach (W.Paragraph theParagraph in body.Elements<W.Paragraph>())
                {
                    // using theParagraph.innerText for each line
                }
            });
            //using (WordprocessingDocument theDocument = WordprocessingDocument.Open(fileInfo.FullName, false))

            //OK
            
            
        }


        public void ShowLoadingIndicator(Boolean isShown)
        {

            LoadingIndicator.Name = "LoadingIndicator";
            this.LoadingIndicator.IsActive = isShown;

        }

        public static class MsgBox
        {
            static public async void Show(string mytext, string title)
            {
                var dialog = new MessageDialog(mytext, title);
                await dialog.ShowAsync();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //MsgBox.Show("LOKIII", "Loaded");
            InitWFile(FilePath);
        }
    }
}
