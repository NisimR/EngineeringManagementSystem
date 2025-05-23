using EngineeringManagementSystem.WinForms.Models;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnEngineering_Click(object sender, EventArgs e)
        {
            new FormEngineering().Show();
            this.Hide();
        }

        private void btnProduction_Click(object sender, EventArgs e)
        {
            new FormProduction().Show();
            this.Hide();

        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            if (Session.Role != "Admin")
            {
                MessageBox.Show("גישה לסביבת ניהול מותרת רק למנהל מערכת");
                return;
            }

            new FormManagement().Show();
            this.Hide();
        }
    }
}
