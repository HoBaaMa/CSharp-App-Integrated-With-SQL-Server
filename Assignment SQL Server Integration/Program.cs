using System.Data;
using Microsoft.Data.SqlClient;

namespace Assignment_SQL_Server_Integration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection? sqlConnection = null;
            
            string connectionString = @"Data Source=EHAB;Initial Catalog=StudentManagement;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            IRepository repository = new Repository(connectionString);

            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                //Console.WriteLine("Connection Established Successfully.");

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("Enter an option:");
                    Console.WriteLine(
                        "1. Add Student\n" +
                        "2. View Student Details\n" +
                        "3. Filter Students By Grade\n" +
                        "4. Calculate Students Age\n" +
                        "5. Exit\n");
                    int option = int.Parse(Console.ReadLine());
                    if (option != null)
                    {
                        switch (option)
                        {
                            case 1:
                                Console.Write("Enter The Student's First Name: ");
                                string firstName = Console.ReadLine();

                                Console.Write("Enter The Student's Last Name: ");
                                string lastName = Console.ReadLine();

                                Console.Write("Enter Student's Birth Date (YY-MM-DD): ");
                                DateTime birthDate = DateTime.Parse(Console.ReadLine());

                                Console.Write("Enter The Student's Grade: ");
                                decimal grade = decimal.Parse(Console.ReadLine());

                                repository.AddStudent(firstName, lastName, birthDate, grade);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nStudent added to the database successfully!\n");
                                Console.ResetColor();
                                break;

                            case 2:
                                Console.WriteLine("All Students Details:\n");
                                foreach (Student student in repository.GetStudentDetails())
                                {
                                    Console.WriteLine($"Student ID: {student.StudentID}, Full Name: {student.FullName}, Date Of Birth: {student.DateOfBirth}, Grade: {student.Grade}");
                                }
                                Console.WriteLine();
                                
                                break;

                            case 3:
                                Console.Write("Enter The Minimum Grade: ");

                                decimal minGrade = decimal.Parse(Console.ReadLine());
                                Console.WriteLine("Students with grade greater than " + minGrade + " are:\n");

                                foreach (Student student in repository.GetStudentsByGrade(minGrade))
                                {
                                    Console.WriteLine($"Student ID: {student.StudentID}, Full Name: {student.FullName}, Date Of Birth: {student.DateOfBirth}, Grade: {student.Grade}");
                                }
                                Console.WriteLine();

                                break;

                            case 4:
                                Console.Write("Enter The Student's Birth Date (YY-MM-DD): ");

                                DateTime birthDate1 = DateTime.Parse(Console.ReadLine());

                                Console.WriteLine("The Student's Age is: " + repository.CalculateAge(birthDate1) + '\n');

                                break;

                            case 5:
                                Console.WriteLine("Exiting..");
                                exit = true;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Please Enter a valid input!");
                                Console.ResetColor();
                                break;
                        }
                    }
                    else
                    {
                        Environment.Exit(0);
                    }

                }
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Format Exception Caught: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.ToString());
            }

            //finally
            //{
            //    if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            //    {
            //        sqlConnection.Close();
            //        Console.WriteLine("Connection Closed Successfully.");
            //    }
            //}
            Console.ReadKey();
        }
    }
}
 