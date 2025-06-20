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
            this.btnOpenDoc = new System.Windows.Forms.Button();
            this.btnEditDoc = new System.Windows.Forms.Button();
            this.btnDeleteDoc = new System.Windows.Forms.Button();
            this.btnReleaseDoc = new System.Windows.Forms.Button();
            this.btnAddDoc = new System.Windows.Forms.Button();
            this.lblEngProj = new System.Windows.Forms.Label();
            this.lblQuestions = new System.Windows.Forms.Label();
            this.dataGridQuestions = new System.Windows.Forms.DataGridView();
            this.btnAnswerQuestion = new System.Windows.Forms.Button();
            this.btnNewRevision = new System.Windows.Forms.Button();
            this.dataGridPendingDocs = new System.Windows.Forms.DataGridView();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPendingDocs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(105, 57);
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
            this.cmbProjects.Size = new System.Drawing.Size(310, 39);
            this.cmbProjects.TabIndex = 1;
            this.cmbProjects.Text = "Project List";
            this.cmbProjects.SelectedIndexChanged += new System.EventHandler(this.cmbProjects_SelectedIndexChanged);
            // 
            // dataGridDocuments
            // 
            this.dataGridDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDocuments.Location = new System.Drawing.Point(453, 218);
            this.dataGridDocuments.Name = "dataGridDocuments";
            this.dataGridDocuments.RowHeadersWidth = 102;
            this.dataGridDocuments.RowTemplate.Height = 40;
            this.dataGridDocuments.Size = new System.Drawing.Size(3027, 522);
            this.dataGridDocuments.TabIndex = 2;
            this.dataGridDocuments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnOpenDoc
            // 
            this.btnOpenDoc.Location = new System.Drawing.Point(453, 773);
            this.btnOpenDoc.Name = "btnOpenDoc";
            this.btnOpenDoc.Size = new System.Drawing.Size(424, 60);
            this.btnOpenDoc.TabIndex = 3;
            this.btnOpenDoc.Text = "Open Doc";
            this.btnOpenDoc.UseVisualStyleBackColor = true;
            this.btnOpenDoc.Click += new System.EventHandler(this.btnOpenDoc_Click);
            // 
            // btnEditDoc
            // 
            this.btnEditDoc.Location = new System.Drawing.Point(929, 773);
            this.btnEditDoc.Name = "btnEditDoc";
            this.btnEditDoc.Size = new System.Drawing.Size(390, 60);
            this.btnEditDoc.TabIndex = 4;
            this.btnEditDoc.Text = "Edit Doc";
            this.btnEditDoc.UseVisualStyleBackColor = true;
            this.btnEditDoc.Click += new System.EventHandler(this.btnEditDoc_Click);
            // 
            // btnDeleteDoc
            // 
            this.btnDeleteDoc.Location = new System.Drawing.Point(1358, 773);
            this.btnDeleteDoc.Name = "btnDeleteDoc";
            this.btnDeleteDoc.Size = new System.Drawing.Size(360, 60);
            this.btnDeleteDoc.TabIndex = 5;
            this.btnDeleteDoc.Text = "Delete Doc";
            this.btnDeleteDoc.UseVisualStyleBackColor = true;
            this.btnDeleteDoc.Click += new System.EventHandler(this.btnDeleteDoc_Click);
            // 
            // btnReleaseDoc
            // 
            this.btnReleaseDoc.Location = new System.Drawing.Point(1755, 773);
            this.btnReleaseDoc.Name = "btnReleaseDoc";
            this.btnReleaseDoc.Size = new System.Drawing.Size(382, 60);
            this.btnReleaseDoc.TabIndex = 6;
            this.btnReleaseDoc.Text = "Release Doc";
            this.btnReleaseDoc.UseVisualStyleBackColor = true;
            this.btnReleaseDoc.Click += new System.EventHandler(this.btnReleaseDoc_Click);
            // 
            // btnAddDoc
            // 
            this.btnAddDoc.Location = new System.Drawing.Point(2404, 783);
            this.btnAddDoc.Name = "btnAddDoc";
            this.btnAddDoc.Size = new System.Drawing.Size(487, 60);
            this.btnAddDoc.TabIndex = 7;
            this.btnAddDoc.Text = "Add Doc";
            this.btnAddDoc.UseVisualStyleBackColor = true;
            this.btnAddDoc.Click += new System.EventHandler(this.btnAddDoc_Click);
            // 
            // lblEngProj
            // 
            this.lblEngProj.AutoSize = true;
            this.lblEngProj.Location = new System.Drawing.Point(99, 166);
            this.lblEngProj.Name = "lblEngProj";
            this.lblEngProj.Size = new System.Drawing.Size(286, 32);
            this.lblEngProj.TabIndex = 8;
            this.lblEngProj.Text = "Engineering Projects:";
            // 
            // lblQuestions
            // 
            this.lblQuestions.AutoSize = true;
            this.lblQuestions.Location = new System.Drawing.Point(447, 899);
            this.lblQuestions.Name = "lblQuestions";
            this.lblQuestions.Size = new System.Drawing.Size(151, 32);
            this.lblQuestions.TabIndex = 9;
            this.lblQuestions.Text = "Questions:";
            this.lblQuestions.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridQuestions
            // 
            this.dataGridQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridQuestions.Location = new System.Drawing.Point(453, 950);
            this.dataGridQuestions.Name = "dataGridQuestions";
            this.dataGridQuestions.ReadOnly = true;
            this.dataGridQuestions.RowHeadersWidth = 102;
            this.dataGridQuestions.Size = new System.Drawing.Size(1492, 294);
            this.dataGridQuestions.TabIndex = 10;
            this.dataGridQuestions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridQuestions_CellContentClick);
            // 
            // btnAnswerQuestion
            // 
            this.btnAnswerQuestion.Location = new System.Drawing.Point(453, 1268);
            this.btnAnswerQuestion.Name = "btnAnswerQuestion";
            this.btnAnswerQuestion.Size = new System.Drawing.Size(1492, 73);
            this.btnAnswerQuestion.TabIndex = 11;
            this.btnAnswerQuestion.Text = "Answer";
            this.btnAnswerQuestion.UseVisualStyleBackColor = true;
            this.btnAnswerQuestion.Click += new System.EventHandler(this.btnAnswerQuestion_Click);
            // 
            // btnNewRevision
            // 
            this.btnNewRevision.Location = new System.Drawing.Point(2957, 783);
            this.btnNewRevision.Name = "btnNewRevision";
            this.btnNewRevision.Size = new System.Drawing.Size(523, 60);
            this.btnNewRevision.TabIndex = 12;
            this.btnNewRevision.Text = "New Revision";
            this.btnNewRevision.UseVisualStyleBackColor = true;
            this.btnNewRevision.Click += new System.EventHandler(this.btnNewRevision_Click);
            // 
            // dataGridPendingDocs
            // 
            this.dataGridPendingDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPendingDocs.Location = new System.Drawing.Point(2000, 950);
            this.dataGridPendingDocs.Name = "dataGridPendingDocs";
            this.dataGridPendingDocs.RowHeadersWidth = 102;
            this.dataGridPendingDocs.RowTemplate.Height = 40;
            this.dataGridPendingDocs.Size = new System.Drawing.Size(1480, 294);
            this.dataGridPendingDocs.TabIndex = 13;
            this.dataGridPendingDocs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPendingDocs_CellContentClick);
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(2000, 1268);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(439, 73);
            this.btnApprove.TabIndex = 14;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(2475, 1273);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(533, 73);
            this.btnReject.TabIndex = 15;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(3058, 1273);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(422, 73);
            this.btnOpen.TabIndex = 16;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1994, 899);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(445, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "Documents Awaiting My Approval:\n";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // FormEngineering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3542, 1449);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.dataGridPendingDocs);
            this.Controls.Add(this.btnNewRevision);
            this.Controls.Add(this.btnAnswerQuestion);
            this.Controls.Add(this.dataGridQuestions);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.lblEngProj);
            this.Controls.Add(this.btnAddDoc);
            this.Controls.Add(this.btnReleaseDoc);
            this.Controls.Add(this.btnDeleteDoc);
            this.Controls.Add(this.btnEditDoc);
            this.Controls.Add(this.btnOpenDoc);
            this.Controls.Add(this.dataGridDocuments);
            this.Controls.Add(this.cmbProjects);
            this.Controls.Add(this.btnBack);
            this.Name = "FormEngineering";
            this.Text = "FormEngineering";
            this.Load += new System.EventHandler(this.FormEngineering_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPendingDocs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.DataGridView dataGridDocuments;
        private System.Windows.Forms.Button btnOpenDoc;
        private System.Windows.Forms.Button btnEditDoc;
        private System.Windows.Forms.Button btnDeleteDoc;
        private System.Windows.Forms.Button btnReleaseDoc;
        private System.Windows.Forms.Button btnAddDoc;
        private System.Windows.Forms.Label lblEngProj;
        private System.Windows.Forms.Label lblQuestions;
        private System.Windows.Forms.DataGridView dataGridQuestions;
        private System.Windows.Forms.Button btnAnswerQuestion;
        private System.Windows.Forms.Button btnNewRevision;
        private System.Windows.Forms.DataGridView dataGridPendingDocs;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label1;
    }
}