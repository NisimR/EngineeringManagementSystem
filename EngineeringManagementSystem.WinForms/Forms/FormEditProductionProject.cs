using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineeringManagementSystem.WinForms.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;



namespace EngineeringManagementSystem.WinForms.Forms
{
    public partial class FormEditProductionProject : Form
    {

        private readonly int _projectId;
        private ProductionProject _project;
        private List<UserDTO> _users;
        public FormEditProductionProject(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
        }
        private async void FormEditProductionProject_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
            await LoadProjectAsync();
        }

        private async Task LoadUsersAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7251/api/Users");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    _users = JsonConvert.DeserializeObject<List<UserDTO>>(json);
                    cboManagers.DataSource = _users;
                    cboManagers.DisplayMember = "FullName";
                    cboManagers.ValueMember = "UserId";
                }
            }
        }

        private async Task LoadProjectAsync()
        {
            using (var client = new HttpClient())
            {
                var res = await client.GetAsync($"https://localhost:7251/api/ProductionProjects/{_projectId}");

                if (res.IsSuccessStatusCode)
                {
                    var json = await res.Content.ReadAsStringAsync();
                    _project = JsonConvert.DeserializeObject<ProductionProject>(json);

                    txtProjectName.Text = _project.ProjectName;
                    txtDescription.Text = _project.Description;
                    cboManagers.SelectedValue = _project.ProjectManagerId;
                }
                else
                {
                    MessageBox.Show("לא ניתן לטעון את פרטי הפרויקט", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjectName.Text) || cboManagers.SelectedItem == null)
            {
                MessageBox.Show("יש למלא את כל השדות");
                return;
            }

            _project.ProjectName = txtProjectName.Text;
            _project.Description = txtDescription.Text;
            _project.ProjectManagerId = (int)cboManagers.SelectedValue;

            using (var client = new HttpClient())
            {
                var res = await client.PutAsJsonAsync($"https://localhost:7251/api/ProductionProjects/{_projectId}", _project);

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("הפרויקט עודכן בהצלחה", "עדכון", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("אירעה שגיאה בעדכון", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
