using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;



namespace MyFirstProject
{

    public partial class Form1 : Form
    {
        private string connectionString = "server=localhost;user=root;password=;database=student_db";
        private List<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name is Required.");
                return;
            }
            else if (name.Any(char.IsDigit))
            {
                MessageBox.Show("Name must not contain numbers.");
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("Please Enter a valid age.");
                return;
            }

            AddStudentToDatabase(name, age);
            MessageBox.Show("Student Added!");

            students.Add(new Student { Name = name, Age = age });

            txtName.Clear();
            txtAge.Clear();


        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridViewStudents.Rows.Clear();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Name, Age FROM Students";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridViewStudents.Rows.Add(reader.GetString("Name"), reader.GetInt32("Age"));
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewStudents.AutoGenerateColumns = false;
            dataGridViewStudents.Columns.Clear();


            dataGridViewStudents.Columns.Add("Name", "Name");
            dataGridViewStudents.Columns.Add("Age", "Age");

            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();

            editButton.Name = "Edit";
            editButton.Text = "Edit";
            editButton.UseColumnTextForButtonValue = true;

            dataGridViewStudents.Columns.Add(editButton);
        }



        private void txtName_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AddStudentToDatabase(string name, int age)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO STUDENTS (Name, Age) VALUES (@name, @age)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;


            if (dataGridViewStudents.Columns[e.ColumnIndex].Name == "Edit")
            {
                DataGridViewRow row = dataGridViewStudents.Rows[e.RowIndex];

                txtEditName.Text = row.Cells["Name"].Value.ToString();
                txtEditAge.Text = row.Cells["Age"].Value.ToString();


                pnlEditStudent.Tag = e.RowIndex;
                pnlEditStudent.Visible = true;



            }

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow == null)
            {
                MessageBox.Show("Select a student to edit.");
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("Age must be a valid number.");
                return;
            }

            DataGridViewRow row = dataGridViewStudents.CurrentRow;
            row.Cells["Name"].Value = txtName.Text;
            row.Cells["Age"].Value = age;

            MessageBox.Show("Student details updated.");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEditName_TextChanged(object sender, EventArgs e)
        {

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pnlEditStudent.Tag == null)
            {
                MessageBox.Show("No Student Selected.");
                return;
            }

            string newName = txtEditName.Text.Trim();
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Name is required and must not contain numbers.");
                return;
            }

            if (newName.Any(char.IsDigit))
            {
                MessageBox.Show("Name must not contain numbers");
                return;
            }

            if (!int.TryParse(txtEditAge.Text, out int newAge))
            {
                MessageBox.Show("Age Must be a valid number.");
                return;
            }

            int rowIndex = (int)pnlEditStudent.Tag;
            DataGridViewRow row = dataGridViewStudents.Rows[rowIndex];

            //Old values
            string oldName = row.Cells["Name"].Value.ToString();
            int oldAge = Convert.ToInt32(row.Cells["Age"].Value);

            //update query
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE students 
                         SET Name = @newName, Age = @newAge 
                         WHERE Name = @oldName AND Age = @oldAge";

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@newName", newName);
                    cmd.Parameters.AddWithValue("@newAge", newAge);
                    cmd.Parameters.AddWithValue("@oldName", oldName);
                    cmd.Parameters.AddWithValue("@oldAge", oldAge);

                    cmd.ExecuteNonQuery();
                }
            }

            //update grid
            row.Cells["Name"].Value = newName;
            row.Cells["Age"].Value = newAge;

            pnlEditStudent.Visible = false;
            MessageBox.Show("Student updated successfully!");

        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            pnlEditStudent.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            dataGridViewStudents.Rows.Clear();

            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                conn.Open();


                string query = @"SELECT Name, Age 
                         FROM students 
                         WHERE Name LIKE @keyword";

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridViewStudents.Rows.Add(
                                reader.GetString("Name"),
                                reader.GetInt32("Age")
                            );
                        }
                    }
                }
            }
        }
    }
}

    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
