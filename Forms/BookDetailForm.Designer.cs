namespace ReadLog
{
    partial class BookDetailForm
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
            lblTitle = new Label();
            lblAuthor = new Label();
            lblGenre = new Label();
            lblStatus = new Label();
            lblPages = new Label();
            label7 = new Label();
            progressReading = new ProgressBar();
            label8 = new Label();
            numCurrentPage = new NumericUpDown();
            btnUpdateProgress = new Button();
            label9 = new Label();
            cmbRating = new ComboBox();
            label10 = new Label();
            txtReview = new TextBox();
            btnSaveReview = new Button();
            ((System.ComponentModel.ISupportInitialize)numCurrentPage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(229, 21);
            label1.Name = "label1";
            label1.Size = new Size(111, 25);
            label1.TabIndex = 0;
            label1.Text = "Book Details";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(167, 66);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 1;
            label2.Text = "Title:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(167, 107);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 2;
            label3.Text = "Author:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(167, 142);
            label4.Name = "label4";
            label4.Size = new Size(62, 25);
            label4.TabIndex = 3;
            label4.Text = "Genre:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(167, 180);
            label5.Name = "label5";
            label5.Size = new Size(64, 25);
            label5.TabIndex = 4;
            label5.Text = "Status:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(167, 219);
            label6.Name = "label6";
            label6.Size = new Size(62, 25);
            label6.TabIndex = 5;
            label6.Text = "Pages:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(289, 66);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(107, 25);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Harry Potter";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(289, 107);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(99, 25);
            lblAuthor.TabIndex = 7;
            lblAuthor.Text = "J.K.Rowling";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(289, 142);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(71, 25);
            lblGenre.TabIndex = 8;
            lblGenre.Text = "Fantasy";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(289, 180);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(51, 25);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Read";
            // 
            // lblPages
            // 
            lblPages.AutoSize = true;
            lblPages.Location = new Point(289, 219);
            lblPages.Name = "lblPages";
            lblPages.Size = new Size(42, 25);
            lblPages.TabIndex = 10;
            lblPages.Text = "300";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(167, 278);
            label7.Name = "label7";
            label7.Size = new Size(150, 25);
            label7.TabIndex = 11;
            label7.Text = "Reading Progress";
            // 
            // progressReading
            // 
            progressReading.Location = new Point(167, 306);
            progressReading.Name = "progressReading";
            progressReading.Size = new Size(501, 34);
            progressReading.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(167, 399);
            label8.Name = "label8";
            label8.Size = new Size(113, 25);
            label8.TabIndex = 13;
            label8.Text = "Current Page";
            // 
            // numCurrentPage
            // 
            numCurrentPage.Location = new Point(304, 397);
            numCurrentPage.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numCurrentPage.Name = "numCurrentPage";
            numCurrentPage.Size = new Size(180, 31);
            numCurrentPage.TabIndex = 14;
            // 
            // btnUpdateProgress
            // 
            btnUpdateProgress.Location = new Point(520, 391);
            btnUpdateProgress.Name = "btnUpdateProgress";
            btnUpdateProgress.Size = new Size(166, 40);
            btnUpdateProgress.TabIndex = 15;
            btnUpdateProgress.Text = "Update Progress";
            btnUpdateProgress.UseVisualStyleBackColor = true;
            btnUpdateProgress.Click += btnUpdateProgress_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(217, 453);
            label9.Name = "label9";
            label9.Size = new Size(63, 25);
            label9.TabIndex = 16;
            label9.Text = "Rating";
            // 
            // cmbRating
            // 
            cmbRating.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRating.FormattingEnabled = true;
            cmbRating.Items.AddRange(new object[] { "1 Star", "2 Stars", "3 Stars", "4 Stars", "5 Stars" });
            cmbRating.Location = new Point(304, 450);
            cmbRating.Name = "cmbRating";
            cmbRating.Size = new Size(182, 33);
            cmbRating.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(151, 540);
            label10.Name = "label10";
            label10.Size = new Size(134, 25);
            label10.TabIndex = 18;
            label10.Text = "Review / Notes:";
            // 
            // txtReview
            // 
            txtReview.Location = new Point(151, 568);
            txtReview.Multiline = true;
            txtReview.Name = "txtReview";
            txtReview.ScrollBars = ScrollBars.Vertical;
            txtReview.Size = new Size(500, 150);
            txtReview.TabIndex = 19;
            // 
            // btnSaveReview
            // 
            btnSaveReview.Location = new Point(502, 524);
            btnSaveReview.Name = "btnSaveReview";
            btnSaveReview.Size = new Size(166, 38);
            btnSaveReview.TabIndex = 20;
            btnSaveReview.Text = "Save Review";
            btnSaveReview.UseVisualStyleBackColor = true;
            btnSaveReview.Click += btnSaveReview_Click;
            // 
            // BookDetailForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 783);
            Controls.Add(btnSaveReview);
            Controls.Add(txtReview);
            Controls.Add(label10);
            Controls.Add(cmbRating);
            Controls.Add(label9);
            Controls.Add(btnUpdateProgress);
            Controls.Add(numCurrentPage);
            Controls.Add(label8);
            Controls.Add(progressReading);
            Controls.Add(label7);
            Controls.Add(lblPages);
            Controls.Add(lblStatus);
            Controls.Add(lblGenre);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "BookDetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)numCurrentPage).EndInit();
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
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblGenre;
        private Label lblStatus;
        private Label lblPages;
        private Label label7;
        private ProgressBar progressReading;
        private Label label8;
        private NumericUpDown numCurrentPage;
        private Button btnUpdateProgress;
        private Label label9;
        private ComboBox cmbRating;
        private Label label10;
        private TextBox txtReview;
        private Button btnSaveReview;
        private Button btnDelete;
    }
}