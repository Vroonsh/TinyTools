using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

            Title = FirmwareFlashersResource.Title;

            Icon = null;

            ToolMenu = null;
        }

        private void FirmwareFlashersTinyTool_Load(object sender, EventArgs e)
        {
            updateComPorts += UpdateComPorts;

            comboBoxCards.Items.Clear();
            comboBoxCards.DataSource = Enum.GetValues(typeof(CardTypeEnum));
            comboBoxCards.SelectedItem = CurrentCardType;
            UpdateCurrentCardType();
        }

        private void UpdateCurrentCardType()
        {
            CurrentCardType = (CardTypeEnum)comboBoxCards.SelectedItem;

            switch (CurrentCardType) {
                case CardTypeEnum.Teensy: {
                    pictureBoxCard.Image = FirmwareFlashersResource.Teensy40;
                    panelFirmwareTeensy.Visible = true;
                    panelFirmwareWemos.Visible = false;
                    break;
                }
                case CardTypeEnum.Wemos: {
                    pictureBoxCard.Image = FirmwareFlashersResource.Wemos;
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
                } catch {
                }
            }

            buttonResetWemos.Enabled = true;
            buttonWemosFlashFirmware.Enabled = true;

        }

        private void buttonWemosUpload_Click(object sender, EventArgs e)
        {
            var esptoolProcess = new Process() {
                StartInfo = new ProcessStartInfo() {
                    FileName = Path.Combine(Application.StartupPath, "wemos\\esptool.exe"),
                    Arguments = $"-cp {comboBoxWemosCards.Text} -cd nodemcu -cb 921600 -cf {textBoxWemosFirmwareName.Text}"
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
                Title = FirmwareFlashersResource.OpenFile_WemosFirmware,
                InitialDirectory = Path.Combine(Application.StartupPath, "wemos\\firmwares")
            };

            fd.ShowDialog(this);

            textBoxWemosFirmwareName.Text = fd.FileName;
        }

        private void textBoxWemosFirmwareName_TextChanged(object sender, EventArgs e)
        {
            UpdateWemosButtonState();
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
                pictureBoxCard.Image = FirmwareFlashersResource.Teensy40;
            } else {
                pictureBoxCard.Image = FirmwareFlashersResource.Teensy32;
            }
            UpdateTeensyButtonState();
        }

        private void buttonSelectTeensyFirmware_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog() {
                DefaultExt = "hex",
                Filter = "Teensy firmware files|*.hex",
                Title = FirmwareFlashersResource.OpenFile_TeensyFirmware,
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

        private void buttonTeensyUpload_Click(object sender, EventArgs e)
        {
            var teensyProcess = new Process() {
                StartInfo = new ProcessStartInfo() {
                    FileName = Path.Combine(Application.StartupPath, "teensy\\teensy_loader_cli.exe"),
                    Arguments = $"--mcu={CurrentTeensyModel} -w {textBoxTeensyFirmware.Text} -v"
                }
            };

            buttonTeensyUpload.Enabled = false;

            if (teensyProcess != null) {
                try {
                    teensyProcess.Start();
                    while (!teensyProcess.HasExited) {
                        Thread.Sleep(100);
                    }
                } catch {
                }
            }

            buttonTeensyUpload.Enabled = true;
        }
        #endregion

    }
}
