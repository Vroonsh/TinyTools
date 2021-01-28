using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace TinyTools
{
    public partial class TinyToolUserControl: UserControl
    {
        public string Title { get; protected set; } = "Tiny Tool";

        public Icon Icon { get; protected set; } = null;

        public ToolStripMenuItem ToolMenu { get; protected set; } = null;
        public TinyToolUserControl()
        {
            InitializeComponent();
        }

        public virtual void UpdateCulture(CultureInfo culture, CultureInfo uiCulture)
        {
        }

    }
}
