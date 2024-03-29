﻿
namespace TinyTools.FirmwareFlashersTinyTool
{
    partial class FirmwareFlashersTinyTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmwareFlashersTinyTool));
            this.backgroundWorkerComPorts = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxCard = new System.Windows.Forms.PictureBox();
            this.comboBoxCards = new System.Windows.Forms.ComboBox();
            this.labelCardType = new System.Windows.Forms.Label();
            this.panelFirmwareTeensy = new System.Windows.Forms.Panel();
            this.labelTeensyCardModel = new System.Windows.Forms.Label();
            this.comboBoxTeensyCardModels = new System.Windows.Forms.ComboBox();
            this.buttonTeensyUpload = new System.Windows.Forms.Button();
            this.buttonSelectTeensyFirmware = new System.Windows.Forms.Button();
            this.labelTeensySelectFirmware = new System.Windows.Forms.Label();
            this.textBoxTeensyFirmware = new System.Windows.Forms.TextBox();
            this.panelFirmwareWemos = new System.Windows.Forms.Panel();
            this.comboBoxFlashSize = new System.Windows.Forms.ComboBox();
            this.labelWemosSelectSize = new System.Windows.Forms.Label();
            this.checkBoxTestSwitch = new System.Windows.Forms.CheckBox();
            this.checkBoxTestOnReset = new System.Windows.Forms.CheckBox();
            this.checkBoxActivityLed = new System.Windows.Forms.CheckBox();
            this.buttonWemosDrivers = new System.Windows.Forms.Button();
            this.buttonDirectOutput = new System.Windows.Forms.Button();
            this.buttonResetWemos = new System.Windows.Forms.Button();
            this.labelWemosComPort = new System.Windows.Forms.Label();
            this.buttonWemosFlashFirmware = new System.Windows.Forms.Button();
            this.comboBoxWemosCards = new System.Windows.Forms.ComboBox();
            this.buttonSelectWemosFirmware = new System.Windows.Forms.Button();
            this.labelWemosSelectFirmware = new System.Windows.Forms.Label();
            this.textBoxWemosFirmwareName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard)).BeginInit();
            this.panelFirmwareTeensy.SuspendLayout();
            this.panelFirmwareWemos.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorkerComPorts
            // 
            this.backgroundWorkerComPorts.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerComPorts_DoWork);
            // 
            // pictureBoxCard
            // 
            resources.ApplyResources(this.pictureBoxCard, "pictureBoxCard");
            this.pictureBoxCard.BackColor = System.Drawing.SystemColors.MenuText;
            this.pictureBoxCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxCard.Name = "pictureBoxCard";
            this.pictureBoxCard.TabStop = false;
            // 
            // comboBoxCards
            // 
            this.comboBoxCards.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxCards, "comboBoxCards");
            this.comboBoxCards.Name = "comboBoxCards";
            this.comboBoxCards.SelectedIndexChanged += new System.EventHandler(this.comboBoxCards_SelectedIndexChanged);
            // 
            // labelCardType
            // 
            resources.ApplyResources(this.labelCardType, "labelCardType");
            this.labelCardType.Name = "labelCardType";
            // 
            // panelFirmwareTeensy
            // 
            resources.ApplyResources(this.panelFirmwareTeensy, "panelFirmwareTeensy");
            this.panelFirmwareTeensy.Controls.Add(this.labelTeensyCardModel);
            this.panelFirmwareTeensy.Controls.Add(this.comboBoxTeensyCardModels);
            this.panelFirmwareTeensy.Controls.Add(this.buttonTeensyUpload);
            this.panelFirmwareTeensy.Controls.Add(this.buttonSelectTeensyFirmware);
            this.panelFirmwareTeensy.Controls.Add(this.labelTeensySelectFirmware);
            this.panelFirmwareTeensy.Controls.Add(this.textBoxTeensyFirmware);
            this.panelFirmwareTeensy.Name = "panelFirmwareTeensy";
            this.panelFirmwareTeensy.VisibleChanged += new System.EventHandler(this.panelFirmwareTeensy_VisibleChanged);
            // 
            // labelTeensyCardModel
            // 
            resources.ApplyResources(this.labelTeensyCardModel, "labelTeensyCardModel");
            this.labelTeensyCardModel.Name = "labelTeensyCardModel";
            // 
            // comboBoxTeensyCardModels
            // 
            resources.ApplyResources(this.comboBoxTeensyCardModels, "comboBoxTeensyCardModels");
            this.comboBoxTeensyCardModels.FormattingEnabled = true;
            this.comboBoxTeensyCardModels.Name = "comboBoxTeensyCardModels";
            this.comboBoxTeensyCardModels.SelectedIndexChanged += new System.EventHandler(this.comboBoxTeensyCardModels_SelectedIndexChanged);
            // 
            // buttonTeensyUpload
            // 
            resources.ApplyResources(this.buttonTeensyUpload, "buttonTeensyUpload");
            this.buttonTeensyUpload.Name = "buttonTeensyUpload";
            this.buttonTeensyUpload.UseVisualStyleBackColor = true;
            this.buttonTeensyUpload.Click += new System.EventHandler(this.buttonTeensyUpload_Click);
            // 
            // buttonSelectTeensyFirmware
            // 
            resources.ApplyResources(this.buttonSelectTeensyFirmware, "buttonSelectTeensyFirmware");
            this.buttonSelectTeensyFirmware.Name = "buttonSelectTeensyFirmware";
            this.buttonSelectTeensyFirmware.UseVisualStyleBackColor = true;
            this.buttonSelectTeensyFirmware.Click += new System.EventHandler(this.buttonSelectTeensyFirmware_Click);
            // 
            // labelTeensySelectFirmware
            // 
            resources.ApplyResources(this.labelTeensySelectFirmware, "labelTeensySelectFirmware");
            this.labelTeensySelectFirmware.Name = "labelTeensySelectFirmware";
            // 
            // textBoxTeensyFirmware
            // 
            resources.ApplyResources(this.textBoxTeensyFirmware, "textBoxTeensyFirmware");
            this.textBoxTeensyFirmware.Name = "textBoxTeensyFirmware";
            this.textBoxTeensyFirmware.TextChanged += new System.EventHandler(this.textBoxTeensyFirmware_TextChanged);
            // 
            // panelFirmwareWemos
            // 
            resources.ApplyResources(this.panelFirmwareWemos, "panelFirmwareWemos");
            this.panelFirmwareWemos.Controls.Add(this.comboBoxFlashSize);
            this.panelFirmwareWemos.Controls.Add(this.labelWemosSelectSize);
            this.panelFirmwareWemos.Controls.Add(this.checkBoxTestSwitch);
            this.panelFirmwareWemos.Controls.Add(this.checkBoxTestOnReset);
            this.panelFirmwareWemos.Controls.Add(this.checkBoxActivityLed);
            this.panelFirmwareWemos.Controls.Add(this.buttonWemosDrivers);
            this.panelFirmwareWemos.Controls.Add(this.buttonDirectOutput);
            this.panelFirmwareWemos.Controls.Add(this.buttonResetWemos);
            this.panelFirmwareWemos.Controls.Add(this.labelWemosComPort);
            this.panelFirmwareWemos.Controls.Add(this.buttonWemosFlashFirmware);
            this.panelFirmwareWemos.Controls.Add(this.comboBoxWemosCards);
            this.panelFirmwareWemos.Controls.Add(this.buttonSelectWemosFirmware);
            this.panelFirmwareWemos.Controls.Add(this.labelWemosSelectFirmware);
            this.panelFirmwareWemos.Controls.Add(this.textBoxWemosFirmwareName);
            this.panelFirmwareWemos.Name = "panelFirmwareWemos";
            this.panelFirmwareWemos.VisibleChanged += new System.EventHandler(this.panelFirmwareWemos_VisibleChanged);
            // 
            // comboBoxFlashSize
            // 
            resources.ApplyResources(this.comboBoxFlashSize, "comboBoxFlashSize");
            this.comboBoxFlashSize.FormattingEnabled = true;
            this.comboBoxFlashSize.Items.AddRange(new object[] {
            resources.GetString("comboBoxFlashSize.Items"),
            resources.GetString("comboBoxFlashSize.Items1"),
            resources.GetString("comboBoxFlashSize.Items2")});
            this.comboBoxFlashSize.Name = "comboBoxFlashSize";
            // 
            // labelWemosSelectSize
            // 
            resources.ApplyResources(this.labelWemosSelectSize, "labelWemosSelectSize");
            this.labelWemosSelectSize.Name = "labelWemosSelectSize";
            // 
            // checkBoxTestSwitch
            // 
            resources.ApplyResources(this.checkBoxTestSwitch, "checkBoxTestSwitch");
            this.checkBoxTestSwitch.Checked = true;
            this.checkBoxTestSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTestSwitch.Name = "checkBoxTestSwitch";
            this.checkBoxTestSwitch.UseVisualStyleBackColor = true;
            // 
            // checkBoxTestOnReset
            // 
            resources.ApplyResources(this.checkBoxTestOnReset, "checkBoxTestOnReset");
            this.checkBoxTestOnReset.Name = "checkBoxTestOnReset";
            this.checkBoxTestOnReset.UseVisualStyleBackColor = true;
            // 
            // checkBoxActivityLed
            // 
            resources.ApplyResources(this.checkBoxActivityLed, "checkBoxActivityLed");
            this.checkBoxActivityLed.Checked = true;
            this.checkBoxActivityLed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActivityLed.Name = "checkBoxActivityLed";
            this.checkBoxActivityLed.UseVisualStyleBackColor = true;
            // 
            // buttonWemosDrivers
            // 
            resources.ApplyResources(this.buttonWemosDrivers, "buttonWemosDrivers");
            this.buttonWemosDrivers.Name = "buttonWemosDrivers";
            this.buttonWemosDrivers.UseVisualStyleBackColor = true;
            this.buttonWemosDrivers.Click += new System.EventHandler(this.buttonWemosDrivers_Click);
            // 
            // buttonDirectOutput
            // 
            resources.ApplyResources(this.buttonDirectOutput, "buttonDirectOutput");
            this.buttonDirectOutput.Name = "buttonDirectOutput";
            this.buttonDirectOutput.UseVisualStyleBackColor = true;
            this.buttonDirectOutput.Click += new System.EventHandler(this.buttonDirectOutput_Click);
            // 
            // buttonResetWemos
            // 
            resources.ApplyResources(this.buttonResetWemos, "buttonResetWemos");
            this.buttonResetWemos.Name = "buttonResetWemos";
            this.buttonResetWemos.UseVisualStyleBackColor = true;
            this.buttonResetWemos.Click += new System.EventHandler(this.buttonResetWemos_Click);
            // 
            // labelWemosComPort
            // 
            resources.ApplyResources(this.labelWemosComPort, "labelWemosComPort");
            this.labelWemosComPort.Name = "labelWemosComPort";
            // 
            // buttonWemosFlashFirmware
            // 
            resources.ApplyResources(this.buttonWemosFlashFirmware, "buttonWemosFlashFirmware");
            this.buttonWemosFlashFirmware.Name = "buttonWemosFlashFirmware";
            this.buttonWemosFlashFirmware.UseVisualStyleBackColor = true;
            this.buttonWemosFlashFirmware.Click += new System.EventHandler(this.buttonWemosUpload_Click);
            // 
            // comboBoxWemosCards
            // 
            resources.ApplyResources(this.comboBoxWemosCards, "comboBoxWemosCards");
            this.comboBoxWemosCards.FormattingEnabled = true;
            this.comboBoxWemosCards.Name = "comboBoxWemosCards";
            this.comboBoxWemosCards.SelectedIndexChanged += new System.EventHandler(this.comboBoxWemosCards_SelectedIndexChanged);
            // 
            // buttonSelectWemosFirmware
            // 
            resources.ApplyResources(this.buttonSelectWemosFirmware, "buttonSelectWemosFirmware");
            this.buttonSelectWemosFirmware.Name = "buttonSelectWemosFirmware";
            this.buttonSelectWemosFirmware.UseVisualStyleBackColor = true;
            this.buttonSelectWemosFirmware.Click += new System.EventHandler(this.buttonWemosSelectFirmware_Click);
            // 
            // labelWemosSelectFirmware
            // 
            resources.ApplyResources(this.labelWemosSelectFirmware, "labelWemosSelectFirmware");
            this.labelWemosSelectFirmware.Name = "labelWemosSelectFirmware";
            // 
            // textBoxWemosFirmwareName
            // 
            resources.ApplyResources(this.textBoxWemosFirmwareName, "textBoxWemosFirmwareName");
            this.textBoxWemosFirmwareName.Name = "textBoxWemosFirmwareName";
            this.textBoxWemosFirmwareName.TextChanged += new System.EventHandler(this.textBoxWemosFirmwareName_TextChanged);
            // 
            // FirmwareFlashersTinyTool
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panelFirmwareWemos);
            this.Controls.Add(this.panelFirmwareTeensy);
            this.Controls.Add(this.pictureBoxCard);
            this.Controls.Add(this.comboBoxCards);
            this.Controls.Add(this.labelCardType);
            this.Name = "FirmwareFlashersTinyTool";
            this.Load += new System.EventHandler(this.FirmwareFlashersTinyTool_Load);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.FirmwareFlashersTinyTool_ControlRemoved);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard)).EndInit();
            this.panelFirmwareTeensy.ResumeLayout(false);
            this.panelFirmwareTeensy.PerformLayout();
            this.panelFirmwareWemos.ResumeLayout(false);
            this.panelFirmwareWemos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCardType;
        private System.Windows.Forms.ComboBox comboBoxCards;
        private System.Windows.Forms.PictureBox pictureBoxCard;
        private System.Windows.Forms.Panel panelFirmwareWemos;
        private System.Windows.Forms.Button buttonResetWemos;
        private System.Windows.Forms.Label labelWemosComPort;
        private System.Windows.Forms.Button buttonWemosFlashFirmware;
        private System.Windows.Forms.ComboBox comboBoxWemosCards;
        private System.Windows.Forms.Button buttonSelectWemosFirmware;
        private System.Windows.Forms.Label labelWemosSelectFirmware;
        private System.Windows.Forms.TextBox textBoxWemosFirmwareName;
        private System.Windows.Forms.Panel panelFirmwareTeensy;
        private System.Windows.Forms.Button buttonTeensyUpload;
        private System.Windows.Forms.Button buttonSelectTeensyFirmware;
        private System.Windows.Forms.Label labelTeensySelectFirmware;
        private System.Windows.Forms.TextBox textBoxTeensyFirmware;
        private System.ComponentModel.BackgroundWorker backgroundWorkerComPorts;
        private System.Windows.Forms.Label labelTeensyCardModel;
        private System.Windows.Forms.ComboBox comboBoxTeensyCardModels;
        private System.Windows.Forms.Button buttonDirectOutput;
        private System.Windows.Forms.Button buttonWemosDrivers;
        private System.Windows.Forms.CheckBox checkBoxTestSwitch;
        private System.Windows.Forms.CheckBox checkBoxTestOnReset;
        private System.Windows.Forms.CheckBox checkBoxActivityLed;
        private System.Windows.Forms.ComboBox comboBoxFlashSize;
        private System.Windows.Forms.Label labelWemosSelectSize;
    }
}
