namespace EngineeringManagementSystem.WinForms.Forms
{
    partial class FormProduction
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
            this.lblProduction = new System.Windows.Forms.Label();
            this.dgvProjects = new System.Windows.Forms.DataGridView();
            this.lblProductionItems = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.lblQuestionsAndAnswers = new System.Windows.Forms.Label();
            this.dgvQuestions = new System.Windows.Forms.DataGridView();
            this.btnOpenDoc = new System.Windows.Forms.Button();
            this.btnAskQuestion = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProduction
            // 
            this.lblProduction.AutoSize = true;
            this.lblProduction.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblProduction.Location = new System.Drawing.Point(130, 111);
            this.lblProduction.Name = "lblProduction";
            this.lblProduction.Size = new System.Drawing.Size(345, 46);
            this.lblProduction.TabIndex = 0;
            this.lblProduction.Text = "Production Projects:";
            // 
            // dgvProjects
            // 
            this.dgvProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjects.Location = new System.Drawing.Point(136, 166);
            this.dgvProjects.Name = "dgvProjects";
            this.dgvProjects.RowHeadersWidth = 102;
            this.dgvProjects.RowTemplate.Height = 40;
            this.dgvProjects.Size = new System.Drawing.Size(2239, 320);
            this.dgvProjects.TabIndex = 1;
            this.dgvProjects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProjects_CellContentClick);
            // 
            // lblProductionItems
            // 
            this.lblProductionItems.AutoSize = true;
            this.lblProductionItems.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblProductionItems.Location = new System.Drawing.Point(127, 526);
            this.lblProductionItems.Name = "lblProductionItems";
            this.lblProductionItems.Size = new System.Drawing.Size(305, 46);
            this.lblProductionItems.TabIndex = 2;
            this.lblProductionItems.Text = "Production Items:";
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(138, 592);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersWidth = 102;
            this.dgvItems.RowTemplate.Height = 40;
            this.dgvItems.Size = new System.Drawing.Size(2237, 344);
            this.dgvItems.TabIndex = 3;
            // 
            // lblQuestionsAndAnswers
            // 
            this.lblQuestionsAndAnswers.AutoSize = true;
            this.lblQuestionsAndAnswers.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblQuestionsAndAnswers.Location = new System.Drawing.Point(130, 1095);
            this.lblQuestionsAndAnswers.Name = "lblQuestionsAndAnswers";
            this.lblQuestionsAndAnswers.Size = new System.Drawing.Size(407, 46);
            this.lblQuestionsAndAnswers.TabIndex = 4;
            this.lblQuestionsAndAnswers.Text = "Questions And Answers:";
            // 
            // dgvQuestions
            // 
            this.dgvQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestions.Location = new System.Drawing.Point(138, 1171);
            this.dgvQuestions.Name = "dgvQuestions";
            this.dgvQuestions.RowHeadersWidth = 102;
            this.dgvQuestions.RowTemplate.Height = 40;
            this.dgvQuestions.Size = new System.Drawing.Size(2237, 321);
            this.dgvQuestions.TabIndex = 5;
            // 
            // btnOpenDoc
            // 
            this.btnOpenDoc.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnOpenDoc.Location = new System.Drawing.Point(135, 963);
            this.btnOpenDoc.Name = "btnOpenDoc";
            this.btnOpenDoc.Size = new System.Drawing.Size(300, 60);
            this.btnOpenDoc.TabIndex = 6;
            this.btnOpenDoc.Text = "Open Doc";
            this.btnOpenDoc.UseVisualStyleBackColor = true;
            this.btnOpenDoc.Click += new System.EventHandler(this.btnOpenDoc_Click);
            // 
            // btnAskQuestion
            // 
            this.btnAskQuestion.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnAskQuestion.Location = new System.Drawing.Point(468, 963);
            this.btnAskQuestion.Name = "btnAskQuestion";
            this.btnAskQuestion.Size = new System.Drawing.Size(300, 60);
            this.btnAskQuestion.TabIndex = 7;
            this.btnAskQuestion.Text = "Ask Question";
            this.btnAskQuestion.UseVisualStyleBackColor = true;
            this.btnAskQuestion.Click += new System.EventHandler(this.btnAskQuestion_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnBack.Location = new System.Drawing.Point(138, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(300, 60);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2884, 1538);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAskQuestion);
            this.Controls.Add(this.btnOpenDoc);
            this.Controls.Add(this.dgvQuestions);
            this.Controls.Add(this.lblQuestionsAndAnswers);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.lblProductionItems);
            this.Controls.Add(this.dgvProjects);
            this.Controls.Add(this.lblProduction);
            this.Name = "FormProduction";
            this.Text = "Production";
            this.Load += new System.EventHandler(this.FormProduction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProduction;
        private System.Windows.Forms.DataGridView dgvProjects;
        private System.Windows.Forms.Label lblProductionItems;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label lblQuestionsAndAnswers;
        private System.Windows.Forms.DataGridView dgvQuestions;
        private System.Windows.Forms.Button btnOpenDoc;
        private System.Windows.Forms.Button btnAskQuestion;
        private System.Windows.Forms.Button btnBack;
    }
}