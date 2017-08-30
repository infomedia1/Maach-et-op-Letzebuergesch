using System;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Validation;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using W = DocumentFormat.OpenXml.Wordprocessing;


namespace WindowsNativeApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public static class MsgBox
        {
            static public void Show(string mytext, string title)
            {
                MessageBox.Show(mytext, title, MessageBoxButtons.OK);
            }
        }

        private void iwwerEisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open About us Popup
            MsgBox.Show("Copyright Staudt Jill \n Autisme Luxembourg a.s.b.l.", "Iwwert eis");
        }

        private void zouMaachenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void opMaachenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult thedlgOpenRes;
            dlgOpen.FileName = "";
            dlgOpen.Filter = "documents (*.docx)|*.docx";
      
            thedlgOpenRes = dlgOpen.ShowDialog();
            if (thedlgOpenRes == DialogResult.OK)
            {
                //File Open
                using (WordprocessingDocument theDocument = WordprocessingDocument.Open(dlgOpen.FileName, true))
                {
                    W.Body body = theDocument.MainDocumentPart.Document.Body;
                    int counter = 0;
                    foreach (W.Paragraph theParagraph in body.Elements<W.Paragraph>())
                    {
                        if (counter > 0) { reEditor.AppendText("\r\n"); }
                        reEditor.AppendText(theParagraph.InnerText);
                        counter++;
                    }
                }
            }
            }
    }
}
