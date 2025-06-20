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
    public partial class FormManagement : Form
    {
        public FormManagement()
        {
            InitializeComponent();
        }

        private void FormManagement_Load(object sender, EventArgs e)
        {
            
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            var usersForm = new FormUsersAdmin();
            usersForm.ShowDialog();
        }

        private void btnEngineering_Click(object sender, EventArgs e)
        {
            var engForm = new FormEngineeringManagement();
            engForm.ShowDialog();
        }

        private void btnProduction_Click(object sender, EventArgs e)
        {
            var prodForm = new FormProductionManagement();
            prodForm.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainForm().Show();
        }
    }
}
