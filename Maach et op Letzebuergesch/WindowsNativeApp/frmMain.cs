using System;
using Novacode;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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

            thedlgOpenRes = dlgOpen.ShowDialog();
            if (thedlgOpenRes==DialogResult.OK)
            {
                //File Open
                DocX TheFile;
                TheFile = DocX.Load(dlgOpen.FileName);
                TheFile.ToString();
                foreach (Novacode.Paragraph theParagraph in TheFile.Paragraphs)
                {
                    if (theParagraph.Text.Length >= 1)
                    {
                        reEditor.AppendText(theParagraph.Text);
                        reEditor.AppendText("\r\n");
                    }
                }
            }
        }
    }
}
