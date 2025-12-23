using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduBarcode
{
    public partial class ManageSettings : Form
    {
        // Define delegate
        public delegate void delManageSettings(object sender);

        public delManageSettings delMS;
        public ManageSettings()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string inputText = txtMainIP.Text.Trim();
            System.Net.IPAddress ip;
            if (System.Net.IPAddress.TryParse(inputText, out ip))
            {
                delMS(txtMainIP);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid IP Address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                //this.Close();
            }
        }
    }
}
