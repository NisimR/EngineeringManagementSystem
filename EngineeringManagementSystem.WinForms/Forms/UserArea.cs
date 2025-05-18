using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EngineeringManagementSystem.WinForms.Forms
{
    public partial class UserArea : Form
    {
        public UserArea()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void prevPage_click(object sender, EventArgs e)
        {
            Form mainScreen = new MainScreen();
            mainScreen.Show();
            this.Close();
        }
    }
}
