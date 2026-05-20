namespace ReadLog
{
    partial class AddEditBookForm
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            cmbGenre = new ComboBox();
            cmbStatus = new ComboBox();
            numYear = new NumericUpDown();
            numPages = new NumericUpDown();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            lblError = new Label();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPages).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(191, 25);
            label1.Name = "label1";
            label1.Size = new Size(326, 30);
            label1.TabIndex = 0;
            label1.Text = "Here, you can add/edit books.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(191, 84);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 1;
            label2.Text = "Title:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(182, 134);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 2;
            label3.Text = "Author:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(191, 187);
            label4.Name = "label4";
            label4.Size = new Size(62, 25);
            label4.TabIndex = 3;
            label4.Text = "Genre:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(138, 237);
            label5.Name = "label5";
            label5.Size = new Size(140, 25);
            label5.TabIndex = 4;
            label5.Text = "Publication Year:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(145, 288);
            label6.Name = "label6";
            label6.Size = new Size(133, 25);
            label6.TabIndex = 5;
            label6.Text = "Reading Status:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(174, 341);
            label7.Name = "label7";
            label7.Size = new Size(104, 25);
            label7.TabIndex = 6;
            label7.Text = "Total Pages:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(174, 396);
            label8.Name = "label8";
            label8.Size = new Size(94, 25);
            label8.TabIndex = 7;
            label8.Text = "Start Date:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(182, 451);
            label9.Name = "label9";
            label9.Size = new Size(84, 25);
            label9.TabIndex = 8;
            label9.Text = "End Date";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(277, 543);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(205, 53);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(277, 613);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(205, 49);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(277, 78);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(205, 31);
            txtTitle.TabIndex = 11;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(277, 128);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(205, 31);
            txtAuthor.TabIndex = 12;
            // 
            // cmbGenre
            // 
            cmbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Items.AddRange(new object[] { "Sci-Fi", "Fantasy", "Self-Help", "Programming", "Education", "History" });
            cmbGenre.Location = new Point(277, 179);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(205, 33);
            cmbGenre.TabIndex = 13;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Read", "Currently Reading ", "Want to Read" });
            cmbStatus.Location = new Point(284, 288);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(198, 33);
            cmbStatus.TabIndex = 16;
            // 
            // numYear
            // 
            numYear.Location = new Point(284, 235);
            numYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(180, 31);
            numYear.TabIndex = 17;
            numYear.Value = new decimal(new int[] { 1900, 0, 0, 0 });
            // 
            // numPages
            // 
            numPages.Location = new Point(284, 339);
            numPages.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPages.Name = "numPages";
            numPages.Size = new Size(180, 31);
            numPages.TabIndex = 18;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(277, 396);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(300, 31);
            dtpStartDate.TabIndex = 19;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(277, 451);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(300, 31);
            dtpEndDate.TabIndex = 20;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(277, 494);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 25);
            lblError.TabIndex = 21;
            // 
            // AddEditBookForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 691);
            Controls.Add(lblError);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(numPages);
            Controls.Add(numYear);
            Controls.Add(cmbStatus);
            Controls.Add(cmbGenre);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddEditBookForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += AddEditBookForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPages).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private ComboBox cmbGenre;
        private TextBox textBox3;
        private TextBox textBox4;
        private ComboBox cmbStatus;
        private NumericUpDown numYear;
        private NumericUpDown numPages;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label lblError;
    }
}