using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace TinyTools.DofChecklistTinyTool
{
    public partial class DofChecklistTinyTool : TinyTools.TinyToolUserControl
    {
        private string ConfigPath = string.Empty;
        private string MainGlobalConfigFile = string.Empty;
        private dynamic DirectOutputComObject = null;

        public DofChecklistTinyTool()
        {
            InitializeComponent();

            UpdateCulture(Thread.CurrentThread.CurrentCulture, Thread.CurrentThread.CurrentUICulture);

            Title = DofChecklistResources.Title;

            Icon = null;

            ToolMenu = new ToolStripMenuItem(Title);
            ToolMenu.DropDownItems.Add(new ToolStripMenuItem(DofChecklistResources.Menu_About, null, new EventHandler(this.OnMenuAbout)));
        }

        private void OnMenuAbout(object sender, EventArgs e)
        {
            
        }

        private void InitDirectOutputComObject()
        {
            DisposeDirectOutputComObject();

            Type DOComObjType = Type.GetTypeFromProgID("DirectOutput.ComObject");
            if (DOComObjType != null) {
                DirectOutputComObject = Activator.CreateInstance(DOComObjType);
            }

            textBoxRegisteredDLL.BackColor = TextBox.DefaultBackColor;
            textBoxDLLPath.Text = string.Empty;
            buttonDirectOutputFrontend.Enabled = false;
            buttonDOCheck.Enabled = false;
            if (DirectOutputComObject == null) {
                textBoxRegisteredDLL.ForeColor = Color.Red;
                textBoxRegisteredDLL.Text = "!!! DirectOut DLL is not registered, please install DirectOutput and/or register Com object.";
            } else if (MainGlobalConfigFile == string.Empty) {
                textBoxRegisteredDLL.ForeColor = Color.Orange;
                textBoxRegisteredDLL.Text = "Select a main GlobalConfig file to properly initialize DirectOutput";
            } else {
                var FileName = Path.GetFileNameWithoutExtension(MainGlobalConfigFile).ToLower();
                if (!FileName.StartsWith("globalconfig_")) {
                    textBoxRegisteredDLL.ForeColor = Color.Orange;
                    textBoxRegisteredDLL.Text = $"Cannot initialize DirectOutput with file {Path.GetFileName(MainGlobalConfigFile)}, name need to start with \"GlobalConfig_\"";
                } else {
                    var GlobalConfigSuffix =  FileName.Substring(FileName.IndexOf('_') + 1);
                    textBoxRegisteredDLL.ForeColor = TextBox.DefaultForeColor;
                    textBoxRegisteredDLL.Text = DirectOutputComObject.GetName();
                    textBoxDLLPath.Text = DirectOutputComObject.GetDllPath();
                    DirectOutputComObject.Init(GlobalConfigSuffix);
                    buttonDirectOutputFrontend.Enabled = true;
                    buttonDOCheck.Enabled = true;
                }
            }
        }

        private void DisposeDirectOutputComObject()
        {
            if (DirectOutputComObject != null) {
                DirectOutputComObject.Finish();
                DirectOutputComObject.Dispose();
                DirectOutputComObject = null;
            }
        }

        private void DofChecklistTinyTool_Load(object sender, EventArgs e)
        {
            MainGlobalConfigFile = textBoxMainGlobalConfig.Text;

            InitDirectOutputComObject();
            Disposed += DofChecklistTinyTool_Disposed;

        }

        private void DofChecklistTinyTool_Disposed(object sender, EventArgs e)
        {
            DisposeDirectOutputComObject();
        }

        /*        private void AppendSection(string section)
                {
                    richTextBoxResults.SelectionColor = Color.DarkBlue;
                    richTextBoxResults.SelectedText = $"{section} {new String('_', 100 - section.Length)}\n";
                }

                private void AppendLine(string line)
                {
                    richTextBoxResults.SelectionColor = richTextBoxResults.ForeColor;
                    richTextBoxResults.SelectedText = $"{line}\n";
                }
                private void AppendCheckLine(string line, string message, bool error)
                {
                    richTextBoxResults.SelectionColor = message == string.Empty ? Color.Green : (error ? Color.Red : Color.Orange);
                    richTextBoxResults.SelectedText = message == string.Empty ? "√\t" : (error ? "X\t" : "!\t");
                    richTextBoxResults.SelectionColor = richTextBoxResults.ForeColor;
                    richTextBoxResults.SelectedText = $"{line}";
                    richTextBoxResults.SelectionColor = message == string.Empty ? Color.Green : (error ? Color.Red : Color.Orange);
                    richTextBoxResults.SelectedText = message == string.Empty ? "\tOK\n" : $"\t{message}\n";
                }


                private void buttonCheckDof_Click(object sender, EventArgs e)
                {

                    richTextBoxResults.Clear();
                    richTextBoxResults.Refresh();
                    ValidateGlobalConfigFiles();
                    ValidateGlobalConfigReferences();
                }

                private void ValidateGlobalConfigReferences()
                {
                    GlobalConfig MainGlobalConfig = null;
                    AppendSection($"{Path.GetFileName(MainGlobalConfigFile)} Checks");
                    try {
                        using (FileStream fs = new FileStream(MainGlobalConfigFile, FileMode.Open, FileAccess.Read)) {
                            MainGlobalConfig = (GlobalConfig)new XmlSerializer(typeof(GlobalConfig)).Deserialize(fs);
                        }
                    } catch(Exception E) {
                        AppendCheckLine($"Error while reading {MainGlobalConfigFile}", E.ToString(), true);
                        return;
                    } 

                    AppendCheckLine("InitFilesPath is set", MainGlobalConfig.IniFilesPath != string.Empty ? string.Empty : $"IniFilesPath was not set", true);
                    if (MainGlobalConfig.IniFilesPath != string.Empty) {
                        AppendCheckLine("InitFilesPath exists", Directory.Exists(MainGlobalConfig.IniFilesPath) ? string.Empty : $"{MainGlobalConfig.IniFilesPath} doesn't exists.", true);
                        if (Directory.Exists(MainGlobalConfig.IniFilesPath)) {
                            var configFiles = Directory.GetFiles(MainGlobalConfig.IniFilesPath, "directoutputconfig*.ini");
                            AppendCheckLine($"{configFiles.Length} Ini files found", configFiles.Length > 0 ? string.Empty : $"No DofConfigTool Ini files found, you have to generate some and extract them in this directory", true);
                            if (configFiles.Length > 0) {
                                foreach (var cFile in configFiles) {
                                    var fileName = Path.GetFileNameWithoutExtension(cFile);
                                    var filenum = fileName.Substring("directoutputconfig".Length);
                                    Int32 num;
                                    if (!Int32.TryParse(filenum, out num)) {
                                        AppendCheckLine($"\t{Path.GetFileName(cFile)}", "Not a valid generated ini file from DofConfigTool, need a number suffix", false);
                                    } else {
                                        AppendCheckLine($"\t{Path.GetFileName(cFile)}", string.Empty, false);
                                    }
                                }
                            }
                        }
                    }
                }

                private void ValidateGlobalConfigFiles()
                {
                    AppendSection("Config Path & GlobalConfig Files");

                    MainGlobalConfigFile = textBoxGlobalConfig.Text;
                    ConfigPath = Path.GetDirectoryName(MainGlobalConfigFile);
                    AppendCheckLine($"Base config path : {ConfigPath}", Directory.Exists(ConfigPath) ? string.Empty : "Invalid config path, check your GlobalConfig file selection", true);

                    string[] globalConfigFiles = new string[0];
                    if (Directory.Exists(ConfigPath)) {
                        globalConfigFiles = Directory.GetFiles(ConfigPath, "GlobalConfig*.xml");
                    }

                    AppendCheckLine("GlobalConfig files presence", globalConfigFiles.Length > 0 ? string.Empty : $"no GlobalConfig files found in {ConfigPath}.", true);
                    if (globalConfigFiles.Length > 0) {
                        AppendLine($"\t{globalConfigFiles.Length,-3} GlobalConfig files found in {ConfigPath}, Size and SHA should be the same for those you really use.");

                        if (MainGlobalConfigFile.ToLower().Contains(".xml.xml")) {
                            AppendCheckLine($"\tReference File : {Path.GetFileName(MainGlobalConfigFile),-64}", "Double extension detected (.xml.xml)", true);
                        } else {
                            SHA1 sha = SHA1.Create();
                            FileStream fileStream = File.OpenRead(MainGlobalConfigFile);
                            fileStream.Position = 0;
                            var refSize = fileStream.Length;
                            var refSHA = string.Join("", sha.ComputeHash(fileStream));
                            AppendLine($"\tReference File : {Path.GetFileName(MainGlobalConfigFile),-64} Size: {refSize,8} SHA: {refSHA}");
                            fileStream.Close();

                            foreach (var file in globalConfigFiles) {
                                if (file.Equals(MainGlobalConfigFile, StringComparison.InvariantCultureIgnoreCase)) {
                                    continue;
                                }

                                if (file.ToLower().Contains(".xml.xml")) {
                                    AppendCheckLine($"\t\t{Path.GetFileName(file),-64}", "Double extension detected (.xml.xml)", false);
                                } else {
                                    fileStream = File.OpenRead(file);
                                    fileStream.Position = 0;
                                    // Compute the hash of the fileStream.
                                    var curSHA = string.Join("", sha.ComputeHash(fileStream));
                                    var sameFile = fileStream.Length == refSize && curSHA.Equals(refSHA, StringComparison.InvariantCultureIgnoreCase);
                                    AppendCheckLine($"\t\t{Path.GetFileName(file),-64} Size: {fileStream.Length,8}", sameFile ? string.Empty : "File doesn't match reference (SHA is different).", false);
                                    fileStream.Close();
                                }
                            }

                            sha.Dispose();
                        }
                    }
                }
        */

        private void buttonSelectGlobalConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog() {
                DefaultExt = "xml",
                Filter = "GlobalConfig files|*.xml",
                Title = "Choose main GlobalConfig file",
                InitialDirectory = Application.StartupPath
            };
                
            if (dlg.ShowDialog() == DialogResult.OK) {
                textBoxMainGlobalConfig.Text = dlg.FileName;
                MainGlobalConfigFile = dlg.FileName;
                InitDirectOutputComObject();
            }
        }

        #region TabPage DirectOutput
        private void buttonDirectOutputFrontend_Click(object sender, EventArgs e)
        {
            if (DirectOutputComObject != null) {
                DirectOutputComObject.ShowFrontend();
            }
        }

        List<DofChecklistResult> DofResults = new List<DofChecklistResult>();

        private void buttonDOCheck_Click(object sender, EventArgs e)
        {
            var globalConfigPass = new DofCheck_GlobalConfig() { MainGlobalConfigFile = MainGlobalConfigFile };
            globalConfigPass.DoCheck();
            DofResults.AddRange(globalConfigPass.Results);
            UpdateDataGridView(dataGridViewDOResults, DofResults);

/*            var random = new Random();
            var newResult = new DofChecklistResult() { Description = $"Check #{DofResults.Count}" };

            if (random.Next(2) > 0) {
                newResult.ErrorsList.Add($"{random.Next()}");
            }

            if (random.Next(2) > 0) {
                newResult.WarningsList.Add($"{random.Next()}");
            }

            if (random.Next(2) > 0) {
                newResult.InformationsList.Add($"{random.Next()}");
            }
            DofResults.Add(newResult);
            UpdateDataGridView(dataGridViewDOResults, DofResults);*/
        }

        private void dataGridViewDOResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellClick(dataGridViewDOResults, DofResults, e);
        }

        private void dataGridViewDOResults_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCellMouseMove(dataGridViewDOResults, DofResults, e);
        }

        #endregion

        #region DataGridView helpers

        private void UpdateDataGridView(DataGridView dtgView, List<DofChecklistResult> results)
        {
            dtgView.DataSource = null;
            dtgView.DataSource = results;
            (dtgView.Columns["Result"] as DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom;
            (dtgView.Columns["Description"] as DataGridViewTextBoxColumn).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgView.Columns["Errors"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgView.Columns["Errors"].DefaultCellStyle.ForeColor = Color.Red;
            dtgView.Columns["Warnings"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgView.Columns["Warnings"].DefaultCellStyle.ForeColor = Color.Orange;
            dtgView.Columns["Informations"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgView.Columns["Informations"].DefaultCellStyle.ForeColor = Color.Green;
            dtgView.Refresh();
        }

        private void DataGridViewCellClick(DataGridView dtgView, List<DofChecklistResult> results, DataGridViewCellEventArgs e)
        {
            var result = results[e.RowIndex];
            switch (e.ColumnIndex) {
                case 2: // Errors
                    MessageBox.Show(string.Join("\n", result.ErrorsList), "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3: // Warnings
                    MessageBox.Show(string.Join("\n", result.WarningsList), "Warnings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 4: // Informations
                    MessageBox.Show(string.Join("\n", result.InformationsList), "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                default:
                    break;
            }
        }

        ToolTip ResultTooltip = new ToolTip();
        DofChecklistResult ToolTipResult = null;

        private void DataGridViewCellMouseMove(DataGridView dtgView, List<DofChecklistResult> results, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) {
                ResultTooltip.Hide(dtgView.Parent);
                ToolTipResult = null;
                return;
            }

            var result = results[e.RowIndex];
            string message = string.Empty;
            switch (e.ColumnIndex) {
                case 2: // Errors
                    message = string.Join("\n", result.ErrorsList);
                    break;
                case 3: // Warnings
                    message = string.Join("\n", result.WarningsList);
                    break;
                case 4: // Informations
                    message = string.Join("\n", result.InformationsList);
                    break;

                default:
                    break;
            }

            if (message == string.Empty) {
                ResultTooltip.Hide(dtgView.Parent);
                ToolTipResult = null;
            } else if (result != ToolTipResult) {
                var loc = dtgView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                loc.Offset(dtgView.Bounds.Location);
                loc.Offset(e.Location);
                loc.Offset(10, 10);
                ResultTooltip.ToolTipTitle = result.Description;
                ResultTooltip.Show(message, dtgView.Parent, loc);
                ToolTipResult = result;
            }
        }

        #endregion

    }
}
