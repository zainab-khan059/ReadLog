namespace ReadLog
{
    partial class ReadingGoalForm
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
            label1 = new Label();
            label2 = new Label();
            numGoal = new NumericUpDown();
            label3 = new Label();
            numCompleted = new NumericUpDown();
            label4 = new Label();
            progressGoal = new ProgressBar();
            lblPercent = new Label();
            btnSaveGoal = new Button();
            dgvHistory = new DataGridView();
            colYear = new DataGridViewTextBoxColumn();
            colGoal = new DataGridViewTextBoxColumn();
            colCompleted = new DataGridViewTextBoxColumn();
            colResult = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)numGoal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCompleted).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(191, 23);
            label1.Name = "label1";
            label1.Size = new Size(393, 30);
            label1.TabIndex = 0;
            label1.Text = "Set your personal reading goals here";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(149, 80);
            label2.Name = "label2";
            label2.Size = new Size(114, 25);
            label2.TabIndex = 1;
            label2.Text = "Target Books";
            // 
            // numGoal
            // 
            numGoal.Location = new Point(320, 78);
            numGoal.Name = "numGoal";
            numGoal.Size = new Size(180, 31);
            numGoal.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(109, 130);
            label3.Name = "label3";
            label3.Size = new Size(154, 25);
            label3.TabIndex = 3;
            label3.Text = "Books Completed";
            // 
            // numCompleted
            // 
            numCompleted.Location = new Point(320, 124);
            numCompleted.Name = "numCompleted";
            numCompleted.Size = new Size(180, 31);
            numCompleted.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(182, 180);
            label4.Name = "label4";
            label4.Size = new Size(81, 25);
            label4.TabIndex = 5;
            label4.Text = "Progress";
            // 
            // progressGoal
            // 
            progressGoal.Location = new Point(317, 180);
            progressGoal.Name = "progressGoal";
            progressGoal.Size = new Size(180, 32);
            progressGoal.TabIndex = 6;
            // 
            // lblPercent
            // 
            lblPercent.AutoSize = true;
            lblPercent.Location = new Point(529, 180);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new Size(119, 25);
            lblPercent.TabIndex = 7;
            lblPercent.Text = "0% Complete";
            // 
            // btnSaveGoal
            // 
            btnSaveGoal.Location = new Point(273, 250);
            btnSaveGoal.Name = "btnSaveGoal";
            btnSaveGoal.Size = new Size(172, 41);
            btnSaveGoal.TabIndex = 8;
            btnSaveGoal.Text = "Save Goal";
            btnSaveGoal.UseVisualStyleBackColor = true;
            btnSaveGoal.Click += btnSaveGoal_Click;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Columns.AddRange(new DataGridViewColumn[] { colYear, colGoal, colCompleted, colResult });
            dgvHistory.Location = new Point(105, 313);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersWidth = 62;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(528, 283);
            dgvHistory.TabIndex = 9;
            // 
            // colYear
            // 
            colYear.HeaderText = "Year";
            colYear.MinimumWidth = 8;
            colYear.Name = "colYear";
            colYear.ReadOnly = true;
            // 
            // colGoal
            // 
            colGoal.HeaderText = "Goal";
            colGoal.MinimumWidth = 8;
            colGoal.Name = "colGoal";
            colGoal.ReadOnly = true;
            // 
            // colCompleted
            // 
            colCompleted.HeaderText = "Completed";
            colCompleted.MinimumWidth = 8;
            colCompleted.Name = "colCompleted";
            colCompleted.ReadOnly = true;
            // 
            // colResult
            // 
            colResult.HeaderText = "Result";
            colResult.MinimumWidth = 8;
            colResult.Name = "colResult";
            colResult.ReadOnly = true;
            // 
            // ReadingGoalForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 644);
            Controls.Add(dgvHistory);
            Controls.Add(btnSaveGoal);
            Controls.Add(lblPercent);
            Controls.Add(progressGoal);
            Controls.Add(label4);
            Controls.Add(numCompleted);
            Controls.Add(label3);
            Controls.Add(numGoal);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "ReadingGoalForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += ReadingGoalForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)numGoal).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCompleted).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown numGoal;
        private Label label3;
        private NumericUpDown numCompleted;
        private Label label4;
        private ProgressBar progressGoal;
        private Label lblPercent;
        private Button btnSaveGoal;
        private DataGridView dgvHistory;
        private DataGridViewTextBoxColumn colYear;
        private DataGridViewTextBoxColumn colGoal;
        private DataGridViewTextBoxColumn colCompleted;
        private DataGridViewTextBoxColumn colResult;
    }
}