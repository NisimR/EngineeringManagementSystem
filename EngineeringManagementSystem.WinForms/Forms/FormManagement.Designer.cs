namespace EngineeringManagementSystem.WinForms.Forms
{
    partial class FormManagement
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
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnEngineering = new System.Windows.Forms.Button();
            this.btnProduction = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(299, 299);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(412, 270);
            this.btnUsers.TabIndex = 0;
            this.btnUsers.Text = "User Managment";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnEngineering
            // 
            this.btnEngineering.Location = new System.Drawing.Point(747, 299);
            this.btnEngineering.Name = "btnEngineering";
            this.btnEngineering.Size = new System.Drawing.Size(406, 278);
            this.btnEngineering.TabIndex = 1;
            this.btnEngineering.Text = "Engineering Managment";
            this.btnEngineering.UseVisualStyleBackColor = true;
            this.btnEngineering.Click += new System.EventHandler(this.btnEngineering_Click);
            // 
            // btnProduction
            // 
            this.btnProduction.Location = new System.Drawing.Point(1216, 299);
            this.btnProduction.Name = "btnProduction";
            this.btnProduction.Size = new System.Drawing.Size(382, 278);
            this.btnProduction.TabIndex = 2;
            this.btnProduction.Text = "Production Managment";
            this.btnProduction.UseVisualStyleBackColor = true;
            this.btnProduction.Click += new System.EventHandler(this.btnProduction_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(299, 765);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(210, 98);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1806, 984);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnProduction);
            this.Controls.Add(this.btnEngineering);
            this.Controls.Add(this.btnUsers);
            this.Name = "FormManagement";
            this.Text = "FormManagement";
            this.Load += new System.EventHandler(this.FormManagement_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnEngineering;
        private System.Windows.Forms.Button btnProduction;
        private System.Windows.Forms.Button btnBack;
    }
}