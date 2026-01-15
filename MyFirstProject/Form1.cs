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
                string query = "SELECT id, Name, Age FROM Students";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridViewStudents.Rows.Add(
                        reader.GetInt32("id"),    
                        reader.GetString("Name"),
                        reader.GetInt32("Age")
                   );
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewStudents.AutoGenerateColumns = false;
            dataGridViewStudents.Columns.Clear();

            dataGridViewStudents.Columns.Add("Id", "ID");
            dataGridViewStudents.Columns["Id"].Visible = false;


            dataGridViewStudents.Columns.Add("Name", "Name");
            dataGridViewStudents.Columns.Add("Age", "Age");

            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();

            editButton.Name = "Edit";
            editButton.Text = "Edit";
            editButton.UseColumnTextForButtonValue = true;
            dataGridViewStudents.Columns.Add(editButton);

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            
            deleteButton.Name = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            dataGridViewStudents.Columns.Add(deleteButton);
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
                string query = "INSERT INTO STUDENTS (Name, Age) VALUES (@name, @age); SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);

                    object result = cmd.ExecuteScalar();
                    int newId = result != null ? Convert.ToInt32(result) : 0;

                    dataGridViewStudents.Rows.Add(newId, name, age);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewStudents.Rows[e.RowIndex];


            if (dataGridViewStudents.Columns[e.ColumnIndex].Name == "Edit")
            {
                txtEditName.Text = row.Cells["Name"].Value.ToString();
                txtEditAge.Text = row.Cells["Age"].Value.ToString();


                pnlEditStudent.Tag = e.RowIndex;
                pnlEditStudent.Visible = true;
            }

            if (dataGridViewStudents.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo);
                
                if (result == DialogResult.Yes)
                {
                    int idToDelete = Convert.ToInt32(row.Cells["Id"].Value);

                    using (var conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM students WHERE id = @id";
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", idToDelete);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    dataGridViewStudents.Rows.RemoveAt(e.RowIndex);
                    MessageBox.Show("Student deleted successfully!");
                }
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
                MessageBox.Show("No student selected.");
                return;
            }

            
            string newName = txtEditName.Text.Trim();
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Name is required.");
                return;
            }
            if (newName.Any(char.IsDigit))
            {
                MessageBox.Show("Name must not contain numbers.");
                return;
            }

            
            if (!int.TryParse(txtEditAge.Text, out int newAge))
            {
                MessageBox.Show("Age must be a valid number.");
                return;
            }

           
            int rowIndex = (int)pnlEditStudent.Tag;
            DataGridViewRow row = dataGridViewStudents.Rows[rowIndex];
            int studentId = Convert.ToInt32(row.Cells["Id"].Value);

        
            try
            {
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"UPDATE students 
                             SET Name = @newName, Age = @newAge 
                             WHERE Id = @id";

                    using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@newName", newName);
                        cmd.Parameters.AddWithValue("@newAge", newAge);
                        cmd.Parameters.AddWithValue("@id", studentId);

                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows == 0)
                        {
                            MessageBox.Show("Update failed. Student may not exist.");
                            return;
                        }
                    }
                }

                
                row.Cells["Name"].Value = newName;
                row.Cells["Age"].Value = newAge;

                pnlEditStudent.Visible = false;
                MessageBox.Show("Student updated successfully!");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error: " + ex.Message);
            }
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


                string query = @"SELECT id, Name, Age 
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
                                reader.GetInt32("id"),
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
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
