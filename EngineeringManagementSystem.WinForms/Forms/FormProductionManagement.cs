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
using EngineeringManagementSystem.WinForms.Forms;
using Newtonsoft.Json;
using EngineeringManagementSystem.WinForms.Models;

namespace EngineeringManagementSystem.WinForms.Forms
{
    public partial class FormProductionManagement : Form
    {
        private List<ProductionProject> _projects;
        private List<UserDTO> _users;


        public FormProductionManagement()
        {
            InitializeComponent();
        }

        private int? GetSelectedProjectId()
        {
            if (dgvProjects.SelectedRows.Count == 0)
                return null;

            return Convert.ToInt32(dgvProjects.SelectedRows[0].Cells["ProdProjId"].Value);
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
                }
                else
                {
                    MessageBox.Show("שגיאה בטעינת משתמשים");
                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var projectId = GetSelectedProjectId();
            if (projectId == null) return;

            int currentUserId = Session.UserId;
            var form = new FormProductionItem(projectId.Value, currentUserId);
            if (form.ShowDialog() == DialogResult.OK)
                _ = LoadItemsByProject(projectId.Value);
        }
        private async Task LoadItemsByProject(int projectId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://localhost:7251/api/ProductionItems/by-project/{projectId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var items = JsonConvert.DeserializeObject<List<ProductionItemDTO>>(json);

                    dgvItems.DataSource = items.Select(i => new
                    {
                        מזהה = i.Id,
                        שם_חלק = i.ItemName,
                        כמות = i.Quantity,
                        מסמך = i.DocumentNumber,
                        פרויקט = i.ProjectNumber
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("שגיאה בטעינת פריטי הייצור.");
                }
            }
        }


        private async Task LoadProjectsAsync()
        {
            await LoadUsersAsync();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7251");
                var response = await client.GetAsync("/api/ProductionProjects");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    _projects = JsonConvert.DeserializeObject<List<ProductionProject>>(json);

                    dgvProjects.DataSource = _projects.Select(p => new
                    {
                        ProdProjId = p.ProdProjId,
                        ProjectName = p.ProjectName,
                        Description = p.Description,
                        ProjectManager = _users.FirstOrDefault(u => u.UserId == p.ProjectManagerId)?.FullName ?? "לא ידוע",
                        CreatedAt = p.CreatedAt.ToShortDateString()
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("אירעה שגיאה בעת שליפת הפרויקטים", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count > 0)
            {
                var selectedRow = dgvProjects.SelectedRows[0];
                int projectId = Convert.ToInt32(selectedRow.Cells["ProdProjId"].Value);
                _ = LoadItemsByProject(projectId);
            }
        }



        private async void FormProductionManagement_Load(object sender, EventArgs e)
        {
            dgvProjects.SelectionChanged += dgvProjects_SelectionChanged; // 🟢 חשוב!

            await LoadProjectsAsync();

            // בחר את השורה הראשונה אם קיימת
            if (dgvProjects.Rows.Count > 0)
            {
                dgvProjects.ClearSelection();
                dgvProjects.Rows[0].Selected = true;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            var form = new FormAddProductionProject();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = LoadProjectsAsync();
            }
        }

        private void btnEditProject_Click(object sender, EventArgs e)
        {
            var selectedId = GetSelectedProjectId();
            if (selectedId == null)
            {
                MessageBox.Show("אנא בחר פרויקט מהרשימה.");
                return;
            }

            var form = new FormEditProductionProject(selectedId.Value);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = LoadProjectsAsync();
            }
        }




    }
}
