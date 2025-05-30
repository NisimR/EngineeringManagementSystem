namespace EngineeringManagementSystem.WinForms.Forms
{
    partial class FormAddDocument
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
            this.lblProjectName = new System.Windows.Forms.Label();
            this.txtPathDoc = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cmbAuthor = new System.Windows.Forms.ComboBox();
            this.cmbReviewer = new System.Windows.Forms.ComboBox();
            this.cmbApprover = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDocName
            // 
            this.txtDocName.Location = new System.Drawing.Point(87, 194);
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.Size = new System.Drawing.Size(417, 38);
            this.txtDocName.TabIndex = 0;
            this.txtDocName.Text = "Name Doc";
            this.txtDocName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(81, 118);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(185, 32);
            this.lblProjectName.TabIndex = 1;
            this.lblProjectName.Text = "Project Name";
            // 
            // txtPathDoc
            // 
            this.txtPathDoc.Location = new System.Drawing.Point(87, 261);
            this.txtPathDoc.Name = "txtPathDoc";
            this.txtPathDoc.Size = new System.Drawing.Size(417, 38);
            this.txtPathDoc.TabIndex = 2;
            this.txtPathDoc.Text = "Path Doc";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(566, 261);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(233, 38);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cmbAuthor
            // 
            this.cmbAuthor.FormattingEnabled = true;
            this.cmbAuthor.Location = new System.Drawing.Point(87, 410);
            this.cmbAuthor.Name = "cmbAuthor";
            this.cmbAuthor.Size = new System.Drawing.Size(417, 39);
            this.cmbAuthor.TabIndex = 4;
            this.cmbAuthor.Text = "Author";
            // 
            // cmbReviewer
            // 
            this.cmbReviewer.FormattingEnabled = true;
            this.cmbReviewer.Location = new System.Drawing.Point(87, 484);
            this.cmbReviewer.Name = "cmbReviewer";
            this.cmbReviewer.Size = new System.Drawing.Size(417, 39);
            this.cmbReviewer.TabIndex = 5;
            this.cmbReviewer.Text = "Reviewer";
            // 
            // cmbApprover
            // 
            this.cmbApprover.FormattingEnabled = true;
            this.cmbApprover.Location = new System.Drawing.Point(87, 575);
            this.cmbApprover.Name = "cmbApprover";
            this.cmbApprover.Size = new System.Drawing.Size(417, 39);
            this.cmbApprover.TabIndex = 6;
            this.cmbApprover.Text = "Approver";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(87, 666);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(417, 45);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormAddDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1752, 997);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbApprover);
            this.Controls.Add(this.cmbReviewer);
            this.Controls.Add(this.cmbAuthor);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPathDoc);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.txtDocName);
            this.Name = "FormAddDocument";
            this.Text = "FormAddDocument";
            this.Load += new System.EventHandler(this.FormAddDocument_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.TextBox txtPathDoc;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cmbAuthor;
        private System.Windows.Forms.ComboBox cmbReviewer;
        private System.Windows.Forms.ComboBox cmbApprover;
        private System.Windows.Forms.Button btnSave;
    }
}