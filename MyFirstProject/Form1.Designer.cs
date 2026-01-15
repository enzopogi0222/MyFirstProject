namespace MyFirstProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            txtAge = new TextBox();
            btnAdd = new Button();
            btnList = new Button();
            dataGridViewStudents = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            pnlEditStudent = new Panel();
            txtEditName = new TextBox();
            btnSave = new Button();
            btnCancelEdit = new Button();
            txtEditAge = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            pnlEditStudent.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(205, 145);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 1;
            label2.Click += label2_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(587, 60);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 2;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(587, 100);
            txtAge.Name = "txtAge";
            txtAge.PlaceholderText = "Age";
            txtAge.Size = new Size(200, 23);
            txtAge.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(587, 140);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 30);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnList
            // 
            btnList.Location = new Point(710, 140);
            btnList.Name = "btnList";
            btnList.Size = new Size(90, 30);
            btnList.TabIndex = 5;
            btnList.Text = "List All";
            btnList.UseVisualStyleBackColor = true;
            btnList.Click += btnList_Click;
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.AllowUserToAddRows = false;
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Location = new Point(20, 60);
            dataGridViewStudents.MultiSelect = false;
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStudents.Size = new Size(550, 400);
            dataGridViewStudents.TabIndex = 6;
            dataGridViewStudents.CellContentClick += dataGridViewStudents_CellContentClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(20, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by name";
            txtSearch.Size = new Size(400, 23);
            txtSearch.TabIndex = 8;
            txtSearch.TextChanged += textBox1_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(423, 20);
            btnSearch.Margin = new Padding(0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 26);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // pnlEditStudent
            // 
            pnlEditStudent.BackColor = Color.ForestGreen;
            pnlEditStudent.BorderStyle = BorderStyle.FixedSingle;
            pnlEditStudent.Controls.Add(txtEditName);
            pnlEditStudent.Controls.Add(btnSave);
            pnlEditStudent.Controls.Add(btnCancelEdit);
            pnlEditStudent.Controls.Add(txtEditAge);
            pnlEditStudent.Location = new Point(175, 176);
            pnlEditStudent.Name = "pnlEditStudent";
            pnlEditStudent.Size = new Size(245, 263);
            pnlEditStudent.TabIndex = 10;
            pnlEditStudent.Visible = false;
            pnlEditStudent.Paint += panel1_Paint;
            // 
            // txtEditName
            // 
            txtEditName.Location = new Point(20, 31);
            txtEditName.Name = "txtEditName";
            txtEditName.PlaceholderText = "Name";
            txtEditName.Size = new Size(200, 23);
            txtEditName.TabIndex = 11;
            txtEditName.TextChanged += txtEditName_TextChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(20, 100);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 30);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancelEdit
            // 
            btnCancelEdit.Location = new Point(129, 100);
            btnCancelEdit.Name = "btnCancelEdit";
            btnCancelEdit.Size = new Size(90, 30);
            btnCancelEdit.TabIndex = 13;
            btnCancelEdit.Text = "Cancel";
            btnCancelEdit.UseVisualStyleBackColor = true;
            btnCancelEdit.Click += btnCancelEdit_Click;
            // 
            // txtEditAge
            // 
            txtEditAge.Location = new Point(19, 70);
            txtEditAge.Name = "txtEditAge";
            txtEditAge.PlaceholderText = "Age";
            txtEditAge.Size = new Size(200, 23);
            txtEditAge.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(884, 561);
            Controls.Add(pnlEditStudent);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnList);
            Controls.Add(btnAdd);
            Controls.Add(txtAge);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewStudents);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            pnlEditStudent.ResumeLayout(false);
            pnlEditStudent.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtName;
        private TextBox txtAge;
        private Button btnAdd;
        private Button btnList;
        private DataGridView dataGridViewStudents;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel pnlEditStudent;
        private TextBox txtEditName;
        private TextBox txtEditAge;
        private Button btnCancelEdit;
        private Button btnSave;
    }
}
