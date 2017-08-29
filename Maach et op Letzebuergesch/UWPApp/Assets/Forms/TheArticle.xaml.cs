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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPApp.Assets.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TheArticle : Page
    {
        public TheArticle()
        {
            this.InitializeComponent();
        }

        public async System.Threading.Tasks.Task InitWFileAsync(string theFilepath)
        {
            FileOpenPicker opener = new FileOpenPicker();
            opener.FileTypeFilter.Add(".docx");

            StorageFile file = await opener.PickSingleFileAsync();
            if (file != null)
            {
                // XmlDocument theDocument = null;

                var fileInfo = new FileInfo(file.Name);

                using (WordprocessingDocument theDocument = WordprocessingDocument.Open(fileInfo.FullName, true))
                {
                    //OK
                    W.Body body = theDocument.MainDocumentPart.Document.Body;
                    foreach (W.Paragraph theParagraph in body.Elements<W.Paragraph>())
                    {
                        //
                    }
                }
/*
                using (var fileStream = await file.OpenReadAsync())
                {
                    using (ZipArchive archive = new ZipArchive(fileStream.AsStream(), ZipArchiveMode.Read))
                    {
                        theDocument = this.GetSheet(archive)
                    }
                }
                */
            }
        }
    }
}
