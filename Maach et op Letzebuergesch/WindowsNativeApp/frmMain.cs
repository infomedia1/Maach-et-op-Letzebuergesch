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
//using TranslationConnector.TranslatorClass


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
                    dataGrid.DataSource = null;

                    dataGrid.ColumnCount = 3;
                    dataGrid.Columns[0].Name = "ID";
                    dataGrid.Columns[1].Name = "Source";
                    dataGrid.Columns[2].Name = "Target";
                    dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGrid.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                    foreach (W.Paragraph theParagraph in body.Elements<W.Paragraph>())
                    {
                        if (theParagraph.InnerText.Length >= 1)
                        // check if it's not an empty line
                        {
                            counter++;
                            //if (counter > 0) { reEditor.AppendText("\r\n"); }

                            dataGrid.Rows.Add(counter, theParagraph.InnerText, " ");

                           // data
                           // dataGrid.Rows[counter].Cells[0].Value = counter;
                           // dataGrid.Rows[counter].Cells[1].Value = theParagraph.InnerText;

                            /*
                            //Edito
                            reEditor.ForeColor = Color.Gray;
                            reEditor.AppendText("None");
                            reEditor.AppendText("\r\n");

                            //BaseText
                            reEditor.SelectionBackColor = Color.LightGreen;
                            reEditor.AppendText(theParagraph.InnerText);
                            reEditor.AppendText("\r\n");

                            //Translation
                            reEditor.SelectionBackColor = System.Drawing.Color.Yellow;
                            reEditor.AppendText("The empty translation");
                            reEditor.AppendText("\r\n");
                            */
                            
                        }
                    }
                }
            }
            }

        private void btnAutoTranslate_Click(object sender, EventArgs e)
        {
            //Autotranslate
            TranslatorClass* theEmptyClass;
            theEmptyClass = new TranslatorClass;
            theEmptyClass->initTranslator(languageCode::de, languageCode::lu);
        }
    }
}
