using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_SQL_Server_Integration
{
    // Repository Interface
    internal interface IRepository
    {
        void AddStudent(string firstName, string lastName, DateTime dateOfBirth, decimal grade);
        List<Student> GetStudentDetails();
        List<Student> GetStudentsByGrade(decimal minGrade);
        int CalculateAge(DateTime dateOfBirth);
    }
}
