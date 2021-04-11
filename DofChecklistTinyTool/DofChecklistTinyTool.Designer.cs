
namespace TinyTools.DofChecklistTinyTool
{
    partial class DofChecklistTinyTool
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DofChecklistTinyTool));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDirectOutput = new System.Windows.Forms.TabPage();
            this.buttonDOCheck = new System.Windows.Forms.Button();
            this.dataGridViewDOResults = new System.Windows.Forms.DataGridView();
            this.Result = new System.Windows.Forms.DataGridViewImageColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Errors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Warnings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Informations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxDOStatus = new System.Windows.Forms.GroupBox();
            this.buttonDirectOutputFrontend = new System.Windows.Forms.Button();
            this.textBoxDLLPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRegisteredDLL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageVisualPinball = new System.Windows.Forms.TabPage();
            this.tabPagePinupSystem = new System.Windows.Forms.TabPage();
            this.buttonSelectGlobalConfig = new System.Windows.Forms.Button();
            this.textBoxMainGlobalConfig = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageDirectOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDOResults)).BeginInit();
            this.groupBoxDOStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPageDirectOutput);
            this.tabControl1.Controls.Add(this.tabPageVisualPinball);
            this.tabControl1.Controls.Add(this.tabPagePinupSystem);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPageDirectOutput
            // 
            this.tabPageDirectOutput.Controls.Add(this.buttonDOCheck);
            this.tabPageDirectOutput.Controls.Add(this.dataGridViewDOResults);
            this.tabPageDirectOutput.Controls.Add(this.groupBoxDOStatus);
            resources.ApplyResources(this.tabPageDirectOutput, "tabPageDirectOutput");
            this.tabPageDirectOutput.Name = "tabPageDirectOutput";
            this.tabPageDirectOutput.UseVisualStyleBackColor = true;
            // 
            // buttonDOCheck
            // 
            resources.ApplyResources(this.buttonDOCheck, "buttonDOCheck");
            this.buttonDOCheck.Name = "buttonDOCheck";
            this.buttonDOCheck.UseVisualStyleBackColor = true;
            this.buttonDOCheck.Click += new System.EventHandler(this.buttonDOCheck_Click);
            // 
            // dataGridViewDOResults
            // 
            this.dataGridViewDOResults.AllowUserToAddRows = false;
            this.dataGridViewDOResults.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dataGridViewDOResults, "dataGridViewDOResults");
            this.dataGridViewDOResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDOResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Result,
            this.Description,
            this.Errors,
            this.Warnings,
            this.Informations});
            this.dataGridViewDOResults.Name = "dataGridViewDOResults";
            this.dataGridViewDOResults.ReadOnly = true;
            this.dataGridViewDOResults.RowHeadersVisible = false;
            this.dataGridViewDOResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDOResults_CellClick);
            this.dataGridViewDOResults.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewDOResults_CellMouseMove);
            // 
            // Result
            // 
            this.Result.DataPropertyName = "Result";
            this.Result.Frozen = true;
            resources.ApplyResources(this.Result, "Result");
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            resources.ApplyResources(this.Description, "Description");
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Errors
            // 
            this.Errors.DataPropertyName = "Errors";
            resources.ApplyResources(this.Errors, "Errors");
            this.Errors.Name = "Errors";
            this.Errors.ReadOnly = true;
            this.Errors.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Errors.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Warnings
            // 
            this.Warnings.DataPropertyName = "Warnings";
            resources.ApplyResources(this.Warnings, "Warnings");
            this.Warnings.Name = "Warnings";
            this.Warnings.ReadOnly = true;
            this.Warnings.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Warnings.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Informations
            // 
            this.Informations.DataPropertyName = "Informations";
            resources.ApplyResources(this.Informations, "Informations");
            this.Informations.Name = "Informations";
            this.Informations.ReadOnly = true;
            this.Informations.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Informations.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBoxDOStatus
            // 
            resources.ApplyResources(this.groupBoxDOStatus, "groupBoxDOStatus");
            this.groupBoxDOStatus.Controls.Add(this.buttonDirectOutputFrontend);
            this.groupBoxDOStatus.Controls.Add(this.textBoxDLLPath);
            this.groupBoxDOStatus.Controls.Add(this.label3);
            this.groupBoxDOStatus.Controls.Add(this.textBoxRegisteredDLL);
            this.groupBoxDOStatus.Controls.Add(this.label2);
            this.groupBoxDOStatus.Name = "groupBoxDOStatus";
            this.groupBoxDOStatus.TabStop = false;
            // 
            // buttonDirectOutputFrontend
            // 
            resources.ApplyResources(this.buttonDirectOutputFrontend, "buttonDirectOutputFrontend");
            this.buttonDirectOutputFrontend.Name = "buttonDirectOutputFrontend";
            this.buttonDirectOutputFrontend.UseVisualStyleBackColor = true;
            this.buttonDirectOutputFrontend.Click += new System.EventHandler(this.buttonDirectOutputFrontend_Click);
            // 
            // textBoxDLLPath
            // 
            resources.ApplyResources(this.textBoxDLLPath, "textBoxDLLPath");
            this.textBoxDLLPath.Name = "textBoxDLLPath";
            this.textBoxDLLPath.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // textBoxRegisteredDLL
            // 
            resources.ApplyResources(this.textBoxRegisteredDLL, "textBoxRegisteredDLL");
            this.textBoxRegisteredDLL.Name = "textBoxRegisteredDLL";
            this.textBoxRegisteredDLL.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tabPageVisualPinball
            // 
            resources.ApplyResources(this.tabPageVisualPinball, "tabPageVisualPinball");
            this.tabPageVisualPinball.Name = "tabPageVisualPinball";
            this.tabPageVisualPinball.UseVisualStyleBackColor = true;
            // 
            // tabPagePinupSystem
            // 
            resources.ApplyResources(this.tabPagePinupSystem, "tabPagePinupSystem");
            this.tabPagePinupSystem.Name = "tabPagePinupSystem";
            this.tabPagePinupSystem.UseVisualStyleBackColor = true;
            // 
            // buttonSelectGlobalConfig
            // 
            resources.ApplyResources(this.buttonSelectGlobalConfig, "buttonSelectGlobalConfig");
            this.buttonSelectGlobalConfig.Name = "buttonSelectGlobalConfig";
            this.buttonSelectGlobalConfig.UseVisualStyleBackColor = true;
            this.buttonSelectGlobalConfig.Click += new System.EventHandler(this.buttonSelectGlobalConfig_Click);
            // 
            // textBoxMainGlobalConfig
            // 
            resources.ApplyResources(this.textBoxMainGlobalConfig, "textBoxMainGlobalConfig");
            this.textBoxMainGlobalConfig.Name = "textBoxMainGlobalConfig";
            this.textBoxMainGlobalConfig.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DofChecklistTinyTool
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSelectGlobalConfig);
            this.Controls.Add(this.textBoxMainGlobalConfig);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "DofChecklistTinyTool";
            this.Load += new System.EventHandler(this.DofChecklistTinyTool_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageDirectOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDOResults)).EndInit();
            this.groupBoxDOStatus.ResumeLayout(false);
            this.groupBoxDOStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDirectOutput;
        private System.Windows.Forms.TabPage tabPageVisualPinball;
        private System.Windows.Forms.TabPage tabPagePinupSystem;
        private System.Windows.Forms.GroupBox groupBoxDOStatus;
        private System.Windows.Forms.TextBox textBoxDLLPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRegisteredDLL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSelectGlobalConfig;
        private System.Windows.Forms.TextBox textBoxMainGlobalConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDOCheck;
        private System.Windows.Forms.DataGridView dataGridViewDOResults;
        private System.Windows.Forms.Button buttonDirectOutputFrontend;
        private System.Windows.Forms.DataGridViewImageColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Errors;
        private System.Windows.Forms.DataGridViewTextBoxColumn Warnings;
        private System.Windows.Forms.DataGridViewTextBoxColumn Informations;
    }
}
