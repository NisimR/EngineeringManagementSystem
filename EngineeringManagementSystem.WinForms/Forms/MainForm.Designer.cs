namespace EngineeringManagementSystem.WinForms.Forms
{
    partial class MainForm
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
            this.btnEngineering = new System.Windows.Forms.Button();
            this.btnProduction = new System.Windows.Forms.Button();
            this.btnManagement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEngineering
            // 
            this.btnEngineering.Location = new System.Drawing.Point(139, 251);
            this.btnEngineering.Name = "btnEngineering";
            this.btnEngineering.Size = new System.Drawing.Size(380, 164);
            this.btnEngineering.TabIndex = 0;
            this.btnEngineering.Text = "Engineering ";
            this.btnEngineering.UseVisualStyleBackColor = true;
            this.btnEngineering.Click += new System.EventHandler(this.btnEngineering_Click);
            // 
            // btnProduction
            // 
            this.btnProduction.Location = new System.Drawing.Point(555, 251);
            this.btnProduction.Name = "btnProduction";
            this.btnProduction.Size = new System.Drawing.Size(356, 164);
            this.btnProduction.TabIndex = 1;
            this.btnProduction.Text = "Production";
            this.btnProduction.UseVisualStyleBackColor = true;
            this.btnProduction.Click += new System.EventHandler(this.btnProduction_Click);
            // 
            // btnManagement
            // 
            this.btnManagement.Location = new System.Drawing.Point(963, 251);
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Size = new System.Drawing.Size(354, 164);
            this.btnManagement.TabIndex = 2;
            this.btnManagement.Text = "Management";
            this.btnManagement.UseVisualStyleBackColor = true;
            this.btnManagement.Click += new System.EventHandler(this.btnManagement_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 938);
            this.Controls.Add(this.btnManagement);
            this.Controls.Add(this.btnProduction);
            this.Controls.Add(this.btnEngineering);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEngineering;
        private System.Windows.Forms.Button btnProduction;
        private System.Windows.Forms.Button btnManagement;
    }
}