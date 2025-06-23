namespace EngineeringManagementSystem.WinForms.Forms
{
    partial class FormUsersAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridUsers = new System.Windows.Forms.DataGridView();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridUsers
            // 
            this.dataGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsers.Location = new System.Drawing.Point(289, 221);
            this.dataGridUsers.Name = "dataGridUsers";
            this.dataGridUsers.RowHeadersWidth = 102;
            this.dataGridUsers.RowTemplate.Height = 40;
            this.dataGridUsers.Size = new System.Drawing.Size(2249, 363);
            this.dataGridUsers.TabIndex = 0;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(289, 636);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(750, 87);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(1100, 636);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(652, 87);
            this.btnEditUser.TabIndex = 2;
            this.btnEditUser.Text = "Edit User";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(1833, 636);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(705, 87);
            this.btnDeleteUser.TabIndex = 3;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(302, 1115);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(234, 106);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormUsersAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2720, 1376);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.dataGridUsers);
            this.Name = "FormUsersAdmin";
            this.Text = "FormUsersAdmin";
            this.Load += new System.EventHandler(this.FormUsersAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnBack;
    }
}