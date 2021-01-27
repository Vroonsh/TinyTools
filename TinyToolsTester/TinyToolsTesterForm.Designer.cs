
namespace TinyToolsTester
{
    partial class TinyToolsTesterForm
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
            if (disposing && (components != null)) {
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxTinytools = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxLanguage = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panelTinyTool = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBoxTinytools,
            this.toolStripLabel2,
            this.toolStripComboBoxLanguage,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1126, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel1.Text = "Tiny Tools";
            // 
            // toolStripComboBoxTinytools
            // 
            this.toolStripComboBoxTinytools.Name = "toolStripComboBoxTinytools";
            this.toolStripComboBoxTinytools.Size = new System.Drawing.Size(250, 25);
            this.toolStripComboBoxTinytools.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxTinytools_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel2.Text = "Language";
            // 
            // toolStripComboBoxLanguage
            // 
            this.toolStripComboBoxLanguage.Name = "toolStripComboBoxLanguage";
            this.toolStripComboBoxLanguage.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // panelTinyTool
            // 
            this.panelTinyTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTinyTool.Location = new System.Drawing.Point(0, 25);
            this.panelTinyTool.Name = "panelTinyTool";
            this.panelTinyTool.Size = new System.Drawing.Size(1126, 686);
            this.panelTinyTool.TabIndex = 1;
            // 
            // TinyToolsTesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 711);
            this.Controls.Add(this.panelTinyTool);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TinyToolsTesterForm";
            this.Text = "Tiny Tools Tester";
            this.Load += new System.EventHandler(this.TinyToolsTesterForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxTinytools;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxLanguage;
        private System.Windows.Forms.Panel panelTinyTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

