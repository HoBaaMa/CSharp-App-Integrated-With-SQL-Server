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

        /// <summary>
        /// Add A New Student Into Database.
        /// </summary>
        /// <param name="firstName">Student's First Name.</param>
        /// <param name="lastName">Student's Last Name.</param>
        /// <param name="dateOfBirth">Student's Birth Date.</param>
        /// <param name="grade">Student's Grade.</param>
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


        /// <summary>
        /// Calculate The Age of A Student Based on Their Date of Birth.
        /// </summary>
        /// <param name="dateOfBirth">Brith Date of The Student.</param>
        /// <returns>Student's Age.</returns>

        public int CalculateAge(DateTime dateOfBirth)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT dbo.CalculateAge(@date_of_birth)", conn);
                
                cmd.Parameters.AddWithValue("@date_of_birth", dateOfBirth);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Retrive All Students's Details.
        /// </summary>
        /// <returns>A List of Students's Details.</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minGrade">A Specified Decimal Number For Comparing.</param>
        /// <returns>A List of Students Their Grades Less Than The Specified Value.</returns>
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
