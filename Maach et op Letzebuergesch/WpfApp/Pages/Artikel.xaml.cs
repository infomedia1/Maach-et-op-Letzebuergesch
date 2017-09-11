using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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
using Nevron.Nov.Dom;
using Nevron.Nov.Text;
using Nevron.Nov.UI;
using Nevron.Nov.Graphics;
using Nevron.Nov.Editors;
using Nevron.Nov.Chart;
using DocumentFormat.OpenXml.Packaging;
using W = DocumentFormat.OpenXml.Wordprocessing;


namespace WpfApp.Pages
{
    /// <summary>
    /// Interaktionslogik für Artikel.xaml
    /// </summary>
    /// 

    public partial class Artikel : Page
    {

        public Artikel()
        {
            InitializeComponent();
            this.Title = "Artikel verschaffen";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opener = new OpenFileDialog();
            opener.Filter = "Word File(*.docx) | *.docx";

            if (opener.ShowDialog() == true)
            {
                //File Open
                using (WordprocessingDocument theDocument = WordprocessingDocument.Open(opener.FileName, false))
                {
                    W.Body body = theDocument.MainDocumentPart.Document.Body;
                    int counter = 0;

                    foreach (W.Paragraph theParagraph in body.Elements<W.Paragraph>())
                    {
                        if (theParagraph.InnerText.Length >= 1)
                        // check if it's not an empty line
                        {
                            counter++;                
                            RichTest.AppendText(theParagraph.InnerText+"\n");
                        }   
                    }
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
