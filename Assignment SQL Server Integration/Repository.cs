using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Assignment_SQL_Server_Integration
{
    internal class Repository : IRepository
    {
        private readonly string _connectionString;
        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddStudent(string firstName, string lastName, DateTime dateOfBirth, decimal grade)
        {
            using (SqlConnection conn = new SqlConnection (_connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertStudent", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@first_name", firstName);
                cmd.Parameters.AddWithValue("@last_name", lastName);
                cmd.Parameters.AddWithValue("@date_of_birth", dateOfBirth);
                cmd.Parameters.AddWithValue("@grade", grade);

                conn.Open();
                cmd.ExecuteNonQuery();

                // conn.Close(); // Not needed because using statement will close the connection

            }
        }

        public int CalculateAge(DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentDetails()
        {
            var students = new List<Student>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM StudentDetails;", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(
                            new Student
                            {
                                StudentID = reader.GetInt32(0),
                                FullName = reader.GetString(1),
                                Grade = reader.GetDecimal(2)
                            });
                    }
                }
            }

           return students ;
        }

        public List<Student> GetStudentsByGrade(decimal minGrade)
        {
            var students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetStudentsByGrade", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@grade_input", minGrade);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(
                            new Student
                            {
                                StudentID = reader.GetInt32(0),
                                FullName = reader.GetString(1) + " " + reader.GetString(2), // Concatenate FirstName and LastName
                                DateOfBirth = reader.GetDateTime(3),
                                Grade = reader.GetDecimal(4),
                            });
                    }
                }
                return students;
            }
        }
    }
}
