using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TinyTools;

namespace TinyToolsTester
{
    public partial class TinyToolsTesterForm : Form
    {
        public TinyToolsTesterForm()
        {
            InitializeComponent();
        }

        private List<TinyToolUserControl> Tools = new List<TinyToolUserControl>();
        TinyToolUserControl CurrentTool = null;

        private void TinyToolsTesterForm_Load(object sender, EventArgs e)
        {
            Tools = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(x => Assembly.Load(x))
                            .SelectMany(x => x.GetTypes())
                            .Where(T => T.IsSubclassOf(typeof(TinyToolUserControl)))
                            .Select(T => Activator.CreateInstance(T) as TinyToolUserControl).ToList();

            foreach (var tool in Tools) {
                tool.UpdateCulture(Thread.CurrentThread.CurrentCulture, Thread.CurrentThread.CurrentUICulture);
            }

            toolStripComboBoxTinytools.ComboBox.DataSource = Tools.Select(T => T.Title).ToArray();
            
            toolStripComboBoxLanguage.Items.Clear();
            toolStripComboBoxLanguage.Items.Add("Default");
            toolStripComboBoxLanguage.Items.Add("fr");
        }

        private void toolStripComboBoxTinytools_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentTool = Tools[toolStripComboBoxTinytools.SelectedIndex];

            this.SuspendLayout();
            panelTinyTool.SuspendLayout();
            CurrentTool.SuspendLayout();

            panelTinyTool.Controls.Clear();
            panelTinyTool.Controls.Add(CurrentTool);
            CurrentTool.Location = new Point(0, 0);
            CurrentTool.Size = new Size(panelTinyTool.ClientSize.Width, panelTinyTool.ClientSize.Height);
            CurrentTool.Dock = DockStyle.Fill;
            CurrentTool.TabIndex = 0;
            CurrentTool.TabStop = false;

            Icon = CurrentTool.Icon;

            this.ResumeLayout(true);
            panelTinyTool.ResumeLayout(true);
            CurrentTool.ResumeLayout(true);
        }

        private void toolStripComboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxLanguage.SelectedIndex == 0) {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("");
            } else {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
            }

            UpdateSettings("language", Thread.CurrentThread.CurrentCulture.Name);
            Application.Restart();
        }

        private void UpdateSettings(string setting, string value)
        {
            var XmlDoc = new XmlDocument();
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement xmlElement in XmlDoc.DocumentElement) {
                if (xmlElement.Name.Equals("appSettings")) {
                    foreach (XmlNode xmlNode in xmlElement.ChildNodes) {
                        if (xmlNode.Attributes[0].Value.Equals(setting)) {
                            xmlNode.Attributes[1].Value = value;
                        }
                    }
                }
            }

            ConfigurationManager.RefreshSection("appSettings");

            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

    }
}
