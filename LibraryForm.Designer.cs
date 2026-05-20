namespace ReadLog
{
    partial class LibraryForm
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
            txtSearch = new TextBox();
            label2 = new Label();
            panelFilters = new Panel();
            btnDelete = new Button();
            btnEdit = new Button();
            cmbRating = new ComboBox();
            cmbStatus = new ComboBox();
            cmbGenre = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            dgvBooks = new DataGridView();
            ColId = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colAuthor = new DataGridViewTextBoxColumn();
            colGenre = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colRating = new DataGridViewTextBoxColumn();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(211, 27);
            label1.Name = "label1";
            label1.Size = new Size(362, 30);
            label1.TabIndex = 0;
            label1.Text = "Welcome to Your Personal Library";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(185, 86);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(452, 31);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(99, 89);
            label2.Name = "label2";
            label2.Size = new Size(64, 25);
            label2.TabIndex = 2;
            label2.Text = "Search";
            // 
            // panelFilters
            // 
            panelFilters.Controls.Add(btnDelete);
            panelFilters.Controls.Add(btnEdit);
            panelFilters.Controls.Add(cmbRating);
            panelFilters.Controls.Add(cmbStatus);
            panelFilters.Controls.Add(cmbGenre);
            panelFilters.Controls.Add(label5);
            panelFilters.Controls.Add(label4);
            panelFilters.Controls.Add(label3);
            panelFilters.Location = new Point(39, 148);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(707, 147);
            panelFilters.TabIndex = 3;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(477, 77);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(143, 40);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete Books";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(477, 23);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(143, 40);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Edit Books";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // cmbRating
            // 
            cmbRating.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRating.FormattingEnabled = true;
            cmbRating.Items.AddRange(new object[] { "1 Star", "2 Stars", "3 Stars", "4 Stars", "5 Stars" });
            cmbRating.Location = new Point(163, 91);
            cmbRating.Name = "cmbRating";
            cmbRating.Size = new Size(165, 33);
            cmbRating.TabIndex = 5;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Read", "Currently Reading", "Want to Read" });
            cmbStatus.Location = new Point(163, 52);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(165, 33);
            cmbStatus.TabIndex = 4;
            // 
            // cmbGenre
            // 
            cmbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Items.AddRange(new object[] { "Sci-Fi", "Fantasy", "Self Help", "Programming", "Education", "History" });
            cmbGenre.Location = new Point(163, 14);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(165, 33);
            cmbGenre.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(61, 92);
            label5.Name = "label5";
            label5.Size = new Size(63, 25);
            label5.TabIndex = 2;
            label5.Text = "Rating";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 52);
            label4.Name = "label4";
            label4.Size = new Size(60, 25);
            label4.TabIndex = 1;
            label4.Text = "Status";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 17);
            label3.Name = "label3";
            label3.Size = new Size(58, 25);
            label3.TabIndex = 0;
            label3.Text = "Genre";
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Columns.AddRange(new DataGridViewColumn[] { ColId, colTitle, colAuthor, colGenre, colStatus, colRating });
            dgvBooks.Location = new Point(39, 315);
            dgvBooks.MultiSelect = false;
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersWidth = 62;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(707, 335);
            dgvBooks.TabIndex = 4;
            dgvBooks.CellClick += dgvBooks_CellClick;
            dgvBooks.CellDoubleClick += dgvBooks_CellDoubleClick;
            // 
            // ColId
            // 
            ColId.HeaderText = "ID";
            ColId.MinimumWidth = 8;
            ColId.Name = "ColId";
            ColId.ReadOnly = true;
            ColId.Visible = false;
            // 
            // colTitle
            // 
            colTitle.HeaderText = "Title";
            colTitle.MinimumWidth = 8;
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            // 
            // colAuthor
            // 
            colAuthor.HeaderText = "Author";
            colAuthor.MinimumWidth = 8;
            colAuthor.Name = "colAuthor";
            colAuthor.ReadOnly = true;
            // 
            // colGenre
            // 
            colGenre.HeaderText = "Genre";
            colGenre.MinimumWidth = 8;
            colGenre.Name = "colGenre";
            colGenre.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colRating
            // 
            colRating.HeaderText = "Rating";
            colRating.MinimumWidth = 8;
            colRating.Name = "colRating";
            colRating.ReadOnly = true;
            // 
            // LibraryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 694);
            Controls.Add(dgvBooks);
            Controls.Add(panelFilters);
            Controls.Add(label2);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "LibraryForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += LibraryForm_FormClosed;
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private Label label2;
        private Panel panelFilters;
        private ComboBox cmbRating;
        private ComboBox cmbStatus;
        private ComboBox cmbGenre;
        private Label label5;
        private Label label4;
        private Label label3;
        private DataGridView dgvBooks;
        private Button btnDelete;
        private Button btnEdit;
        private DataGridViewTextBoxColumn ColId;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colAuthor;
        private DataGridViewTextBoxColumn colGenre;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colRating;
    }
}