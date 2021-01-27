using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private void TinyToolsTesterForm_Load(object sender, EventArgs e)
        {
            Tools = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(x => Assembly.Load(x))
                            .SelectMany(x => x.GetTypes())
                            .Where(T => T.IsSubclassOf(typeof(TinyToolUserControl)))
                            .Select(T => Activator.CreateInstance(T) as TinyToolUserControl).ToList();

            toolStripComboBoxTinytools.ComboBox.DataSource = Tools.Select(T => T.Title).ToArray();
        }

        private void toolStripComboBoxTinytools_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelTinyTool.SuspendLayout();
            panelTinyTool.Controls.Clear();

            var tool = Tools[toolStripComboBoxTinytools.SelectedIndex];
            tool.Dock = DockStyle.Fill;
            panelTinyTool.Controls.Add(tool);

            panelTinyTool.ResumeLayout(true);
        }
    }
}
