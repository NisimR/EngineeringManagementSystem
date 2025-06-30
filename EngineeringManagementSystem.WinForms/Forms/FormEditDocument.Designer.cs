namespace EngineeringManagementSystem.WinForms.Forms
{
    partial class FormEditDocument
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
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.txtPathDoc = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cmbReviewer = new System.Windows.Forms.ComboBox();
            this.cmbApprover = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblRevision = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDocName
            // 
            this.txtDocName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDocName.Location = new System.Drawing.Point(151, 177);
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.Size = new System.Drawing.Size(418, 43);
            this.txtDocName.TabIndex = 0;
            this.txtDocName.Text = "Doc Name";
            this.txtDocName.TextChanged += new System.EventHandler(this.txtDocName_TextChanged);
            // 
            // txtPathDoc
            // 
            this.txtPathDoc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtPathDoc.Location = new System.Drawing.Point(151, 308);
            this.txtPathDoc.Name = "txtPathDoc";
            this.txtPathDoc.Size = new System.Drawing.Size(418, 43);
            this.txtPathDoc.TabIndex = 1;
            this.txtPathDoc.Text = "Path Doc";
            this.txtPathDoc.TextChanged += new System.EventHandler(this.txtPathDoc_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnBrowse.Location = new System.Drawing.Point(623, 286);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(300, 60);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cmbReviewer
            // 
            this.cmbReviewer.Font = new System.Drawing.Font("Segoe UI Semibold", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbReviewer.FormattingEnabled = true;
            this.cmbReviewer.Location = new System.Drawing.Point(151, 382);
            this.cmbReviewer.Name = "cmbReviewer";
            this.cmbReviewer.Size = new System.Drawing.Size(418, 45);
            this.cmbReviewer.TabIndex = 3;
            this.cmbReviewer.Text = "Reviewer";
            this.cmbReviewer.SelectedIndexChanged += new System.EventHandler(this.cmbReviewer_SelectedIndexChanged);
            // 
            // cmbApprover
            // 
            this.cmbApprover.Font = new System.Drawing.Font("Segoe UI Semibold", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbApprover.FormattingEnabled = true;
            this.cmbApprover.Location = new System.Drawing.Point(151, 463);
            this.cmbApprover.Name = "cmbApprover";
            this.cmbApprover.Size = new System.Drawing.Size(418, 45);
            this.cmbApprover.TabIndex = 4;
            this.cmbApprover.Text = "Approver";
            this.cmbApprover.SelectedIndexChanged += new System.EventHandler(this.cmbApprover_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSave.Location = new System.Drawing.Point(151, 571);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(418, 60);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblRevision
            // 
            this.lblRevision.AutoSize = true;
            this.lblRevision.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblRevision.Location = new System.Drawing.Point(615, 169);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(83, 46);
            this.lblRevision.TabIndex = 6;
            this.lblRevision.Text = "REV";
            // 
            // FormEditDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1678, 837);
            this.Controls.Add(this.lblRevision);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbApprover);
            this.Controls.Add(this.cmbReviewer);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPathDoc);
            this.Controls.Add(this.txtDocName);
            this.Name = "FormEditDocument";
            this.Text = "Edit Document";
            this.Load += new System.EventHandler(this.FormEditDocument_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.TextBox txtPathDoc;
        private System.Windows.Forms.ComboBox cmbReviewer;
        private System.Windows.Forms.ComboBox cmbApprover;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblRevision;
    }
}