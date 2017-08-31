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
using Microsoft.VisualBasic.FileIO;
using W = DocumentFormat.OpenXml.Wordprocessing;
using TranslatorClass;

//using TranslationConnector.TranslatorClass


namespace WindowsNativeApp
{
    public partial class frmMain : Form
    {

        ATranslator newTranslator = new ATranslator("de", "lb");

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

                    DataGridView dataGrid = new DataGridView();
                    dataGrid.Name = "dataGrid";
                    dataGrid.AllowUserToAddRows = false;
                    dataGrid.AllowUserToOrderColumns = false;
                    splitContainer1.Panel1.Controls.Add(dataGrid);
                    dataGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGrid_MouseDown);
                    
                    dataGrid.Dock = DockStyle.Fill;
                    dataGrid.DataSource = null;

                    dataGrid.ColumnCount = 3;
                    dataGrid.Columns[0].ReadOnly = true;
                    dataGrid.Columns[1].ReadOnly = true;
                    dataGrid.Columns[2].ReadOnly = true;
                    dataGrid.Columns[0].Name = "ID";
                    dataGrid.Columns[1].Name = "Source";
                    dataGrid.Columns[2].Name = "Target";
                    dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGrid.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dataGrid.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

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

        private void btnLoadTranslation_Click(object sender, EventArgs e)
        {

            TextFieldParser theParser = new TextFieldParser("lod_DE_LB.csv");
            theParser.Delimiters = new string[] { "\t" };

            string currentline = null;
            string[] currentlineelements;
            while ((currentline = theParser.ReadLine()) != null)
            {

                currentlineelements = currentline.Split('\t');

                //skip header
                if (theParser.LineNumber != 2)
                {
                    Translation newTranslation = new Translation("de", "lb", currentlineelements[0], currentlineelements[1]);
                    newTranslator.Translations.Add(newTranslation);
                }
            }

            Console.Write("YOLO");

        }

        private void BtnAutoTranslate_Click(object sender, EventArgs e)
        {

            //Autotranslate
            for (int i = 0; i < ((DataGridView)this.splitContainer1.Panel1.Controls.Find("dataGrid", true)[0]).RowCount - 1; i++)
            {
                ((DataGridView)this.splitContainer1.Panel1.Controls.Find("dataGrid", true)[0]).Rows[i].Cells[2].Value = newTranslator.TranslateSentenceToTargetStringEasy(((DataGridView)this.splitContainer1.Panel1.Controls.Find("dataGrid", true)[0]).Rows[i].Cells[1].Value.ToString());
            }

            //dataGrid.Rows[0].Cells[1].Value;

            Console.Write("YOLO");
        }



   


        private void dataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Console.Write("YOLO");
                ContextMenuStrip myContextMenu = new System.Windows.Forms.ContextMenuStrip();
                int position_xy_mouse_row = ((DataGridView)this.splitContainer1.Panel1.Controls.Find("dataGrid", true)[0]).HitTest(e.X, e.Y).RowIndex+1;

                if (position_xy_mouse_row>=1)
                {
                    ((DataGridView)this.splitContainer1.Panel1.Controls.Find("dataGrid", true)[0]).ClearSelection();
                    ((DataGridView)this.splitContainer1.Panel1.Controls.Find("dataGrid", true)[0]).Rows[position_xy_mouse_row-1].Selected = true;
                    
                    myContextMenu.Items.Add("Edit...").Name="EDIT " + position_xy_mouse_row.ToString();
                    myContextMenu.Items.Add("AutoTranslate Line:" + position_xy_mouse_row.ToString()).Name = "AT "+position_xy_mouse_row.ToString();
                }

                myContextMenu.Show(this.splitContainer1.Panel1.Controls.Find("dataGrid",true)[0], new Point(e.X, e.Y));

                myContextMenu.ItemClicked += new ToolStripItemClickedEventHandler(myContextMenu_ItemClicked);
                
            }
        }

        private void myContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string TheClickEvent = e.ClickedItem.Name.ToString();
            string[] TheClickEventArgs;

            TheClickEventArgs = TheClickEvent.Split(' ');

            switch (TheClickEventArgs[0])
            {
                case "AT":
                    //Autotranslate Clicked
                    //MessageBox.Show("You clicked on: "+TheClickEventArgs[1]);
                    ((DataGridView)this.splitContainer1.Panel1.Controls.Find("dataGrid", true)[0]).Rows[Int32.Parse(TheClickEventArgs[1])-1].Cells[2].Value = newTranslator.TranslateSentenceToTargetStringEasy(((DataGridView)this.splitContainer1.Panel1.Controls.Find("dataGrid", true)[0]).Rows[Int32.Parse(TheClickEventArgs[1])-1].Cells[1].Value.ToString());
                    break;
                case "EDIT":
                    //EditMode
                    string theContent = ((DataGridView)this.splitContainer1.Panel1.Controls.Find("dataGrid", true)[0]).Rows[Int32.Parse(TheClickEventArgs[1]) - 1].Cells[1].Value.ToString();
                    if (tableLayoutPanel1.Controls.Count > 1)
                    {
                        RichTextBox richEdit = (RichTextBox)tableLayoutPanel1.Controls.Find("richEdit", true)[0];
                        richEdit.Clear();
                        richEdit.AppendText(theContent);
                    }
                    else
                    {
                        RichTextBox richEdit = new RichTextBox();
                        richEdit.Dock = DockStyle.Fill;
                        richEdit.Name = "richEdit";
                        richEdit.AppendText(theContent);
                        tableLayoutPanel1.Controls.Add(richEdit);
                    }
                    break;
            }

        }
    }
}
