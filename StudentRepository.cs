using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace StudentLibrary
{
    public class StudentRepository
    {//Data Access Layer
        private readonly string connectString = "Server=<your_server_name>;Database=<your_db_name>;Trusted_Connection=True;";
        public void AddStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string query = "INSERT INTO Students(Name,Age,Email) VALUES (@Name,@Age,@Email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Email", student.Email);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Student> GetAllStudent()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                string query = "Select * FROM Students";
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        Email = reader["Email"].ToString()
                    });
                }
            }
            return students;
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                string query = "UPDATE Students SET Name = @Name,Age =@Age,Email= @Email WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Email", student.Email);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                string query = "DELETE FROM Students WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
