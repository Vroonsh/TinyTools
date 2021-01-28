using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyTools.FirmwareFlashersTinyTool
{
    partial class FirmwareFlashersTinyToolAboutBox : Form
    {
        public FirmwareFlashersTinyToolAboutBox()
        {
            InitializeComponent();
            this.Text = $"{FirmwareFlashersResources.Menu_About} {FirmwareFlashersResources.Title}";
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
