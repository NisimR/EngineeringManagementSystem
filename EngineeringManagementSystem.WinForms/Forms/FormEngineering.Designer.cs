namespace EngineeringManagementSystem.WinForms.Forms
{
    partial class FormEngineering
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
            this.btnBack = new System.Windows.Forms.Button();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.dataGridDocuments = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDocuments)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(105, 89);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(138, 60);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // cmbProjects
            // 
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(105, 218);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(411, 39);
            this.cmbProjects.TabIndex = 1;
            this.cmbProjects.Text = "Project List";
            this.cmbProjects.SelectedIndexChanged += new System.EventHandler(this.cmbProjects_SelectedIndexChanged);
            // 
            // dataGridDocuments
            // 
            this.dataGridDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDocuments.Location = new System.Drawing.Point(105, 282);
            this.dataGridDocuments.Name = "dataGridDocuments";
            this.dataGridDocuments.RowHeadersWidth = 102;
            this.dataGridDocuments.RowTemplate.Height = 40;
            this.dataGridDocuments.Size = new System.Drawing.Size(411, 327);
            this.dataGridDocuments.TabIndex = 2;
            this.dataGridDocuments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FormEngineering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 906);
            this.Controls.Add(this.dataGridDocuments);
            this.Controls.Add(this.cmbProjects);
            this.Controls.Add(this.btnBack);
            this.Name = "FormEngineering";
            this.Text = "FormEngineering";
            this.Load += new System.EventHandler(this.FormEngineering_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDocuments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.DataGridView dataGridDocuments;
    }
}