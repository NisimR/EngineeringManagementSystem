namespace EngineeringManagementSystem.WinForms.Forms
{
    partial class FormEngineeringManagement
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
            this.dgvProjects = new System.Windows.Forms.DataGridView();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.btnEditProject = new System.Windows.Forms.Button();
            this.btnRefreshProjects = new System.Windows.Forms.Button();
            this.dgvProjectDocuments = new System.Windows.Forms.DataGridView();
            this.btnAddDocument = new System.Windows.Forms.Button();
            this.btnEditDocument = new System.Windows.Forms.Button();
            this.btnDeleteDocument = new System.Windows.Forms.Button();
            this.btnRefreshDocuments = new System.Windows.Forms.Button();
            this.lblDocumentsTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectDocuments)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProjects
            // 
            this.dgvProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjects.Location = new System.Drawing.Point(377, 97);
            this.dgvProjects.Name = "dgvProjects";
            this.dgvProjects.RowHeadersWidth = 102;
            this.dgvProjects.RowTemplate.Height = 40;
            this.dgvProjects.Size = new System.Drawing.Size(2026, 310);
            this.dgvProjects.TabIndex = 0;
            // 
            // btnAddProject
            // 
            this.btnAddProject.Location = new System.Drawing.Point(98, 170);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(238, 58);
            this.btnAddProject.TabIndex = 1;
            this.btnAddProject.Text = "Add Project";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click_1);
            // 
            // btnEditProject
            // 
            this.btnEditProject.Location = new System.Drawing.Point(98, 255);
            this.btnEditProject.Name = "btnEditProject";
            this.btnEditProject.Size = new System.Drawing.Size(238, 62);
            this.btnEditProject.TabIndex = 2;
            this.btnEditProject.Text = "Edit Project";
            this.btnEditProject.UseVisualStyleBackColor = true;
            this.btnEditProject.Click += new System.EventHandler(this.btnEditProject_Click_1);
            // 
            // btnRefreshProjects
            // 
            this.btnRefreshProjects.Location = new System.Drawing.Point(98, 347);
            this.btnRefreshProjects.Name = "btnRefreshProjects";
            this.btnRefreshProjects.Size = new System.Drawing.Size(238, 60);
            this.btnRefreshProjects.TabIndex = 3;
            this.btnRefreshProjects.Text = "Refresh Projects";
            this.btnRefreshProjects.UseVisualStyleBackColor = true;
            this.btnRefreshProjects.Click += new System.EventHandler(this.btnRefreshProjects_Click);
            // 
            // dgvProjectDocuments
            // 
            this.dgvProjectDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjectDocuments.Location = new System.Drawing.Point(377, 553);
            this.dgvProjectDocuments.Name = "dgvProjectDocuments";
            this.dgvProjectDocuments.RowHeadersWidth = 102;
            this.dgvProjectDocuments.RowTemplate.Height = 40;
            this.dgvProjectDocuments.Size = new System.Drawing.Size(2026, 290);
            this.dgvProjectDocuments.TabIndex = 4;
            // 
            // btnAddDocument
            // 
            this.btnAddDocument.Location = new System.Drawing.Point(377, 891);
            this.btnAddDocument.Name = "btnAddDocument";
            this.btnAddDocument.Size = new System.Drawing.Size(213, 42);
            this.btnAddDocument.TabIndex = 5;
            this.btnAddDocument.Text = "Add Document";
            this.btnAddDocument.UseVisualStyleBackColor = true;
            this.btnAddDocument.Click += new System.EventHandler(this.btnAddDocument_Click);
            // 
            // btnEditDocument
            // 
            this.btnEditDocument.Location = new System.Drawing.Point(641, 882);
            this.btnEditDocument.Name = "btnEditDocument";
            this.btnEditDocument.Size = new System.Drawing.Size(227, 51);
            this.btnEditDocument.TabIndex = 6;
            this.btnEditDocument.Text = "Edit Document";
            this.btnEditDocument.UseVisualStyleBackColor = true;
            this.btnEditDocument.Click += new System.EventHandler(this.btnEditDocument_Click);
            // 
            // btnDeleteDocument
            // 
            this.btnDeleteDocument.Location = new System.Drawing.Point(916, 882);
            this.btnDeleteDocument.Name = "btnDeleteDocument";
            this.btnDeleteDocument.Size = new System.Drawing.Size(309, 51);
            this.btnDeleteDocument.TabIndex = 7;
            this.btnDeleteDocument.Text = "Delete Document";
            this.btnDeleteDocument.UseVisualStyleBackColor = true;
            this.btnDeleteDocument.Click += new System.EventHandler(this.btnDeleteDocument_Click);
            // 
            // btnRefreshDocuments
            // 
            this.btnRefreshDocuments.Location = new System.Drawing.Point(1332, 895);
            this.btnRefreshDocuments.Name = "btnRefreshDocuments";
            this.btnRefreshDocuments.Size = new System.Drawing.Size(314, 42);
            this.btnRefreshDocuments.TabIndex = 8;
            this.btnRefreshDocuments.Text = "Refresh Documents";
            this.btnRefreshDocuments.UseVisualStyleBackColor = true;
            this.btnRefreshDocuments.Click += new System.EventHandler(this.btnRefreshDocuments_Click);
            // 
            // lblDocumentsTitle
            // 
            this.lblDocumentsTitle.AutoSize = true;
            this.lblDocumentsTitle.Location = new System.Drawing.Point(371, 467);
            this.lblDocumentsTitle.Name = "lblDocumentsTitle";
            this.lblDocumentsTitle.Size = new System.Drawing.Size(219, 32);
            this.lblDocumentsTitle.TabIndex = 9;
            this.lblDocumentsTitle.Text = "Documents Title";
            // 
            // FormEngineeringManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2634, 1132);
            this.Controls.Add(this.lblDocumentsTitle);
            this.Controls.Add(this.btnRefreshDocuments);
            this.Controls.Add(this.btnDeleteDocument);
            this.Controls.Add(this.btnEditDocument);
            this.Controls.Add(this.btnAddDocument);
            this.Controls.Add(this.dgvProjectDocuments);
            this.Controls.Add(this.btnRefreshProjects);
            this.Controls.Add(this.btnEditProject);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.dgvProjects);
            this.Name = "FormEngineeringManagement";
            this.Text = "FormEngineeringManagement";
            this.Load += new System.EventHandler(this.FormEngineeringManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectDocuments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProjects;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.Button btnEditProject;
        private System.Windows.Forms.Button btnRefreshProjects;
        private System.Windows.Forms.DataGridView dgvProjectDocuments;
        private System.Windows.Forms.Button btnAddDocument;
        private System.Windows.Forms.Button btnEditDocument;
        private System.Windows.Forms.Button btnDeleteDocument;
        private System.Windows.Forms.Button btnRefreshDocuments;
        private System.Windows.Forms.Label lblDocumentsTitle;
    }
}