using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MySql.Data.MySqlClient;



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
            dataGridViewStudents.ColumnCount = 2;
            dataGridViewStudents.Columns[0].Name = "Name";
            dataGridViewStudents.Columns[1].Name = "Age";

        }

        private void txtName_Keypress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
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


    }

    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
