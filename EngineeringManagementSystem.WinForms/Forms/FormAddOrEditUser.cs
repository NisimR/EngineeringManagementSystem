using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineeringManagementSystem.WinForms.Models;

namespace EngineeringManagementSystem.WinForms.Forms
{
    public partial class FormAddOrEditUser : Form
    {
        private UserDTO _user;

        public FormAddOrEditUser()
        {
            InitializeComponent();
 
        }
        // 🔧 זה הבנאי שחסר לך
        public FormAddOrEditUser(UserDTO user)
        {
            InitializeComponent();
            _user = user;

            // כאן תוכל למלא שדות לפי המשתמש
            //txtFullName.Text = _user.FullName;
            //cmbRole.SelectedItem = _user.Role;
            // וכן הלאה...
        }

        private void FormAddOrEditUser_Load(object sender, EventArgs e)
        {

        }
    }
}
