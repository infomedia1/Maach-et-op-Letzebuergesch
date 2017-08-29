namespace WindowsNativeApp
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opMaachenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zouMaachenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Hëllef = new System.Windows.Forms.ToolStripMenuItem();
            this.iwwerEisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.reEditor = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.Hëllef});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(967, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opMaachenToolStripMenuItem,
            this.toolStripSeparator1,
            this.zouMaachenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // opMaachenToolStripMenuItem
            // 
            this.opMaachenToolStripMenuItem.Name = "opMaachenToolStripMenuItem";
            this.opMaachenToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.opMaachenToolStripMenuItem.Text = "Op maachen";
            this.opMaachenToolStripMenuItem.Click += new System.EventHandler(this.opMaachenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // zouMaachenToolStripMenuItem
            // 
            this.zouMaachenToolStripMenuItem.Name = "zouMaachenToolStripMenuItem";
            this.zouMaachenToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.zouMaachenToolStripMenuItem.Text = "Zou maachen";
            this.zouMaachenToolStripMenuItem.Click += new System.EventHandler(this.zouMaachenToolStripMenuItem_Click);
            // 
            // Hëllef
            // 
            this.Hëllef.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iwwerEisToolStripMenuItem});
            this.Hëllef.Name = "Hëllef";
            this.Hëllef.Size = new System.Drawing.Size(50, 20);
            this.Hëllef.Text = "Hëllef";
            // 
            // iwwerEisToolStripMenuItem
            // 
            this.iwwerEisToolStripMenuItem.Name = "iwwerEisToolStripMenuItem";
            this.iwwerEisToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.iwwerEisToolStripMenuItem.Text = "Iwwer eis...";
            this.iwwerEisToolStripMenuItem.Click += new System.EventHandler(this.iwwerEisToolStripMenuItem_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "dlgOpen";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.reEditor);
            this.splitContainer1.Size = new System.Drawing.Size(967, 455);
            this.splitContainer1.SplitterDistance = 577;
            this.splitContainer1.TabIndex = 2;
            // 
            // reEditor
            // 
            this.reEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reEditor.Location = new System.Drawing.Point(0, 0);
            this.reEditor.Name = "reEditor";
            this.reEditor.Size = new System.Drawing.Size(577, 455);
            this.reEditor.TabIndex = 0;
            this.reEditor.Text = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 479);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Maach et op Lëtzebuergesch";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Hëllef;
        private System.Windows.Forms.ToolStripMenuItem iwwerEisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opMaachenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem zouMaachenToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox reEditor;
    }
}

