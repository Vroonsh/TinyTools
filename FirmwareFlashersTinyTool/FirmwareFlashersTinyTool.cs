using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TinyTools.FirmwareFlashersTinyTool
{
    public partial class FirmwareFlashersTinyTool : TinyToolUserControl
    {
        private enum CardTypeEnum
        {
            Wemos,
            Teensy
        }

        private CardTypeEnum CurrentCardType = CardTypeEnum.Wemos;

        public FirmwareFlashersTinyTool()
        {
            InitializeComponent();

            UpdateCulture(Thread.CurrentThread.CurrentCulture, Thread.CurrentThread.CurrentUICulture);

            Title = FirmwareFlashersResources.Title;

            Icon = null;

            ToolMenu = new ToolStripMenuItem(Title);
            ToolMenu.DropDownItems.Add(new ToolStripMenuItem(FirmwareFlashersResources.Menu_About, null, new EventHandler(this.OnMenuAbout)));
        }

        private void OnMenuAbout(object sender, EventArgs e)
        {
            FirmwareFlashersTinyToolAboutBox frm = new FirmwareFlashersTinyToolAboutBox();
            frm.ShowDialog(this);
        }

        private void FirmwareFlashersTinyTool_Load(object sender, EventArgs e)
        {
            updateComPorts += UpdateComPorts;

            comboBoxCards.Items.Clear();
            comboBoxCards.DataSource = Enum.GetValues(typeof(CardTypeEnum));
            comboBoxCards.SelectedItem = CurrentCardType;
            UpdateCurrentCardType();
        }

        private void FirmwareFlashersTinyTool_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (backgroundWorkerComPorts.IsBusy) {
                backgroundWorkerComPorts.CancelAsync();
                while (backgroundWorkerComPorts.CancellationPending) {
                    Application.DoEvents();
                }
            }
        }

        public override void UpdateCulture(CultureInfo culture, CultureInfo uiCulture)
        {
            base.UpdateCulture(culture, uiCulture);
            FirmwareFlashersResources.Culture = culture;
        }

        private void UpdateCurrentCardType()
        {
            CurrentCardType = (CardTypeEnum)comboBoxCards.SelectedItem;

            switch (CurrentCardType) {
                case CardTypeEnum.Teensy: {
                    pictureBoxCard.Image = FirmwareFlashersResources.Teensy40;
                    panelFirmwareTeensy.Visible = true;
                    panelFirmwareWemos.Visible = false;
                    break;
                }
                case CardTypeEnum.Wemos: {
                    pictureBoxCard.Image = FirmwareFlashersResources.Wemos;
                    panelFirmwareTeensy.Visible = false;
                    panelFirmwareWemos.Visible = true;
                    break;
                }
                default: {
                    break;
                }
            }
        }

        private void comboBoxCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCurrentCardType();
        }

        #region Wemos Panel
        private void UpdateWemosButtonState()
        {
            buttonResetWemos.Enabled = comboBoxWemosCards.SelectedIndex >= 0 &&
                                       comboBoxWemosCards.Text != string.Empty;
            buttonWemosFlashFirmware.Enabled = buttonResetWemos.Enabled && textBoxWemosFirmwareName.Text != string.Empty;
        }

        private void panelFirmwareWemos_VisibleChanged(object sender, EventArgs e)
        {
            if (panelFirmwareWemos.Visible) {
                UpdateWemosButtonState();
                if (!backgroundWorkerComPorts.IsBusy) {
                    backgroundWorkerComPorts.WorkerSupportsCancellation = true;
                    backgroundWorkerComPorts.RunWorkerAsync(this);
                }
            } else {
                backgroundWorkerComPorts.CancelAsync();
            }
        }

        private delegate void UpdateComPortsDelegate();
        private UpdateComPortsDelegate updateComPorts;
        private string[] ComPorts = new string[0];

        private void UpdateComPorts()
        {
            Application.DoEvents();
            var comPorts = SerialPort.GetPortNames();
            if (!comPorts.SequenceEqual(ComPorts)) {
                ComPorts = new string[comPorts.Length];
                comPorts.CopyTo(ComPorts, 0);
                comboBoxWemosCards.Items.Clear();
                comboBoxWemosCards.Items.AddRange(ComPorts);
                comboBoxWemosCards.SelectedIndex = -1;
                comboBoxWemosCards.Text = "";
                UpdateWemosButtonState();
            }
        }
        private void backgroundWorkerComPorts_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var control = e.Argument as FirmwareFlashersTinyTool;
            while (!worker.CancellationPending) {
                if (control != null && !control.IsDisposed && !control.Disposing) {
                    control.Invoke(updateComPorts);
                }
                Thread.Sleep(200);
            }
        }

        private void comboBoxWemosCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWemosButtonState();
        }

        private void buttonResetWemos_Click(object sender, EventArgs e)
        {
            var esptoolProcess = new Process() {
                StartInfo = new ProcessStartInfo() {
                    FileName = Path.Combine(Application.StartupPath, "wemos\\esptool.exe"),
                    Arguments = $"-cp {comboBoxWemosCards.Text} -cd nodemcu -ce"
                }
            };

            buttonResetWemos.Enabled = false;
            buttonWemosFlashFirmware.Enabled = false;

            if (esptoolProcess != null) {
                try {
                    esptoolProcess.Start();
                    while (!esptoolProcess.HasExited) {
                        Thread.Sleep(100);
                    }
                    if (esptoolProcess.ExitCode != 0) {
                        MessageBox.Show(FirmwareFlashersResources.FlashError_Message, FirmwareFlashersResources.FlashError_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch {
                }
            }

            buttonResetWemos.Enabled = true;
            buttonWemosFlashFirmware.Enabled = true;

        }

        private void buttonWemosUpload_Click(object sender, EventArgs e)
        {
            //Create Settings
            byte[] settings = {
                (byte)(checkBoxTestOnReset.Checked ? 1 : 0),
                (byte)(checkBoxTestSwitch.Checked ? 1 : 0),
                (byte)(checkBoxActivityLed.Checked ? 1 : 0),
                0,
                0,
                0,
                0,
                0
            };

            var settingFileName = Path.Combine(Application.StartupPath, "wemos\\settings.bin");
            var settingFile = File.OpenWrite(settingFileName);
            settingFile.Write(settings, 0, settings.Length * sizeof(byte));
            settingFile.Close();

            var esptoolProcess = new Process() {
                StartInfo = new ProcessStartInfo() {
                    FileName = Path.Combine(Application.StartupPath, "wemos\\esptool.exe"),
                    Arguments = $"-cp {comboBoxWemosCards.Text} -cd nodemcu -cb 921600 -cf \"{textBoxWemosFirmwareName.Text}\" -ca 0x3fb000 -cf \"{settingFileName}\" -v"}
            };

            buttonResetWemos.Enabled = false;
            buttonWemosFlashFirmware.Enabled = false;

            if (esptoolProcess != null) {
                try {
                    esptoolProcess.Start();
                    while (!esptoolProcess.HasExited) {
                        Thread.Sleep(100);
                    }
                    if (esptoolProcess.ExitCode != 0) {
                        MessageBox.Show($"{FirmwareFlashersResources.FlashError_Message}\nExit Code : {esptoolProcess.ExitCode}", FirmwareFlashersResources.FlashError_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch {
                }
            }

            buttonResetWemos.Enabled = true;
            buttonWemosFlashFirmware.Enabled = true;
        }

        private void buttonWemosSelectFirmware_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog() {
                DefaultExt = "bin",
                Filter = "Wemos firmware files|*.bin",
                Title = FirmwareFlashersResources.OpenFile_WemosFirmware,
                InitialDirectory = Path.Combine(Application.StartupPath, "wemos\\firmwares")
            };

            fd.ShowDialog(this);

            textBoxWemosFirmwareName.Text = fd.FileName;
        }

        private void textBoxWemosFirmwareName_TextChanged(object sender, EventArgs e)
        {
            UpdateWemosButtonState();
        }

        private void buttonDirectOutput_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(FirmwareFlashersResources.DirectOutput_Message, FirmwareFlashersResources.DirectOutput_Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                Process.Start("explorer.exe", Path.Combine(Application.StartupPath, "wemos\\modified directoutput"));
            }
        }

        private void buttonWemosDrivers_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.Combine(Application.StartupPath, "wemos\\drivers"));
        }

        #endregion

        #region Teensy Panel
        private enum TeensyModelEnum
        {
            TEENSY31,
            TEENSY32,
            TEENSY40
        }

        private TeensyModelEnum CurrentTeensyModel = TeensyModelEnum.TEENSY40;

        private void panelFirmwareTeensy_VisibleChanged(object sender, EventArgs e)
        {
            comboBoxTeensyCardModels.DataSource = Enum.GetValues(typeof(TeensyModelEnum));
            comboBoxTeensyCardModels.SelectedItem = CurrentTeensyModel;
            UpdateTeensyButtonState();
        }

        private void comboBoxTeensyCardModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!panelFirmwareTeensy.Visible) {
                return;
            }
            CurrentTeensyModel = (TeensyModelEnum)comboBoxTeensyCardModels.SelectedItem;
            if (CurrentTeensyModel >= TeensyModelEnum.TEENSY40) {
                pictureBoxCard.Image = FirmwareFlashersResources.Teensy40;
            } else {
                pictureBoxCard.Image = FirmwareFlashersResources.Teensy32;
            }
            UpdateTeensyButtonState();
        }

        private void buttonSelectTeensyFirmware_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog() {
                DefaultExt = "hex",
                Filter = "Teensy firmware files|*.hex",
                Title = FirmwareFlashersResources.OpenFile_TeensyFirmware,
                InitialDirectory = Path.Combine(Application.StartupPath, "teensy\\firmwares")
            };

            fd.ShowDialog(this);

            textBoxTeensyFirmware.Text = fd.FileName;
            UpdateTeensyButtonState();
        }

        private void UpdateTeensyButtonState()
        {
            buttonTeensyUpload.Enabled = textBoxTeensyFirmware.Text != string.Empty;
        }

        private void textBoxTeensyFirmware_TextChanged(object sender, EventArgs e)
        {
            UpdateTeensyButtonState();
        }

        private void buttonTeensyUpload_Click(object sender, EventArgs e)
        {
            var teensyProcess = new Process() {
                StartInfo = new ProcessStartInfo() {
                    FileName = Path.Combine(Application.StartupPath, "teensy\\teensy_loader_cli.exe"),
                    Arguments = $"--mcu={CurrentTeensyModel} -w \"{textBoxTeensyFirmware.Text}\" -v"
                }
            };

            buttonTeensyUpload.Enabled = false;

            if (teensyProcess != null) {
                try {
                    teensyProcess.Start();
                    while (!teensyProcess.HasExited) {
                        Thread.Sleep(100);
                    }
                    if (teensyProcess.ExitCode != 0) {
                        MessageBox.Show(FirmwareFlashersResources.FlashError_Message, FirmwareFlashersResources.FlashError_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch {
                }
            }

            buttonTeensyUpload.Enabled = true;
        }
        #endregion

    }
}
