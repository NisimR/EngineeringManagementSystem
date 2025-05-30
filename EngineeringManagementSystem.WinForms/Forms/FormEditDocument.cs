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
    public partial class FormEditDocument : Form
    {
        private DocumentDTO _doc;

        public FormEditDocument(DocumentDTO doc)
        {
            InitializeComponent();
            _doc = doc;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormEditDocument_Load(object sender, EventArgs e)
        {

        }

        private void txtDocName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPathDoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbReviewer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbApprover_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
