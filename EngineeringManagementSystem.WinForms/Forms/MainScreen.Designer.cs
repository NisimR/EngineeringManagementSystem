namespace EngineeringManagementSystem.WinForms.Forms
{
    partial class MainScreen
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addUserBtn = new System.Windows.Forms.Button();
            this.fullName = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.passwordHash = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.role = new System.Windows.Forms.ComboBox();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.roleDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.userDTOBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(183, 156);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(435, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(201, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(398, 44);
            this.label2.TabIndex = 2;
            this.label2.Text = "ניהול פרוייקטים בהנדסה";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(318, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "נוצר ע\"י: ניסים רחום";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.role);
            this.groupBox1.Controls.Add(this.email);
            this.groupBox1.Controls.Add(this.passwordHash);
            this.groupBox1.Controls.Add(this.addUserBtn);
            this.groupBox1.Controls.Add(this.fullName);
            this.groupBox1.Controls.Add(this.username);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 195);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "הוספת משתמש";
            // 
            // addUserBtn
            // 
            this.addUserBtn.Location = new System.Drawing.Point(20, 156);
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Size = new System.Drawing.Size(100, 23);
            this.addUserBtn.TabIndex = 4;
            this.addUserBtn.Text = "הוסף משתמש";
            this.addUserBtn.UseVisualStyleBackColor = true;
            this.addUserBtn.Click += new System.EventHandler(this.addUserBtn_Click);
            // 
            // fullName
            // 
            this.fullName.Location = new System.Drawing.Point(20, 51);
            this.fullName.Name = "fullName";
            this.fullName.Size = new System.Drawing.Size(100, 20);
            this.fullName.TabIndex = 1;
            this.fullName.Text = "שם מלא";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(20, 27);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(100, 20);
            this.username.TabIndex = 0;
            this.username.Text = "שם משתמש";
            this.username.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // passwordHash
            // 
            this.passwordHash.Location = new System.Drawing.Point(20, 104);
            this.passwordHash.Name = "passwordHash";
            this.passwordHash.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.passwordHash.Size = new System.Drawing.Size(100, 20);
            this.passwordHash.TabIndex = 5;
            this.passwordHash.Text = "סיסמה";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(20, 130);
            this.email.Name = "email";
            this.email.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.email.Size = new System.Drawing.Size(100, 20);
            this.email.TabIndex = 6;
            this.email.Text = "אימייל";
            this.email.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // role
            // 
            this.role.FormattingEnabled = true;
            this.role.Items.AddRange(new object[] {
            "Operator ",
            "Engineer",
            "ProjectManager",
            "Admin"});
            this.role.Location = new System.Drawing.Point(20, 77);
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(100, 21);
            this.role.TabIndex = 7;
            this.role.Text = "תפקיד";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            // 
            // roleDataGridViewTextBoxColumn
            // 
            this.roleDataGridViewTextBoxColumn.DataPropertyName = "Role";
            this.roleDataGridViewTextBoxColumn.HeaderText = "Role";
            this.roleDataGridViewTextBoxColumn.Name = "roleDataGridViewTextBoxColumn";
            // 
            // userDTOBindingSource
            // 
            this.userDTOBindingSource.DataSource = typeof(EngineeringManagementSystem.WinForms.Models.UserDTO);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource userDTOBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addUserBtn;
        private System.Windows.Forms.TextBox fullName;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox passwordHash;
        private System.Windows.Forms.ComboBox role;
    }
}