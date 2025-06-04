namespace EngineeringManagementSystem.WinForms.Forms
{
    partial class FormCreateNewRevision
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtOldName = new System.Windows.Forms.TextBox();
            this.txtOldRev = new System.Windows.Forms.TextBox();
            this.txtNewRev = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(147, 255);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(483, 86);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create New Revision";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtOldName
            // 
            this.txtOldName.Location = new System.Drawing.Point(147, 62);
            this.txtOldName.Name = "txtOldName";
            this.txtOldName.Size = new System.Drawing.Size(262, 38);
            this.txtOldName.TabIndex = 1;
            // 
            // txtOldRev
            // 
            this.txtOldRev.Location = new System.Drawing.Point(147, 128);
            this.txtOldRev.Name = "txtOldRev";
            this.txtOldRev.Size = new System.Drawing.Size(262, 38);
            this.txtOldRev.TabIndex = 2;
            // 
            // txtNewRev
            // 
            this.txtNewRev.Location = new System.Drawing.Point(147, 189);
            this.txtNewRev.Name = "txtNewRev";
            this.txtNewRev.Size = new System.Drawing.Size(262, 38);
            this.txtNewRev.TabIndex = 3;
            // 
            // FormCreateNewRevision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNewRev);
            this.Controls.Add(this.txtOldRev);
            this.Controls.Add(this.txtOldName);
            this.Controls.Add(this.btnCreate);
            this.Name = "FormCreateNewRevision";
            this.Text = "FormCreateNewRevision";
            this.Load += new System.EventHandler(this.FormCreateNewRevision_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtOldName;
        private System.Windows.Forms.TextBox txtOldRev;
        private System.Windows.Forms.TextBox txtNewRev;
    }
}