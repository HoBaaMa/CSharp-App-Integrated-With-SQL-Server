# Assignment: SQL Server Integration with C# Console Application

## Objective
This assignment aims to enhance your understanding of SQL Server concepts such as Stored Procedures, Views, and Functions, and how to integrate them with a C# Console Application using Object-Oriented Programming (OOP) principles, interfaces, and generics.

---

## Requirements

### 1. Database Setup
- Create a SQL Server database named **StudentManagement**.
- Add a table named **Students** with the following schema:
  - `StudentID` (Primary Key, `INT`, Auto Increment)
  - `FirstName` (`NVARCHAR(50)`)
  - `LastName` (`NVARCHAR(50)`)
  - `DateOfBirth` (`DATE`)
  - `Grade` (`DECIMAL(3, 2)`)

### 2. SQL Components
#### Stored Procedures:
- **InsertStudent**: Inserts a new student into the `Students` table.
- **GetStudentsByGrade**: Retrieves students with a grade greater than a specified value.

#### View:
- **StudentDetails**: Displays the following:
  - `StudentID`
  - `FullName` (concatenation of `FirstName` and `LastName`)
  - `Grade`

#### Function:
- **CalculateAge**: Calculates the age of a student based on their `DateOfBirth`.

### 3. C# Console Application
#### Functionalities:
1. **Add a New Student**:
   - Use an interface to define methods for interacting with the database.
   - Implement these methods in a class.
   - Use a generic repository pattern for database operations.

2. **View Student Details**:
   - Call the `StudentDetails` view and display the results.

3. **Filter Students by Grade**:
   - Call the `GetStudentsByGrade` stored procedure and display the filtered results.

4. **Calculate Age**:
   - Call the `CalculateAge` function for each student and display their age.

### 4. Object-Oriented Programming (OOP) Principles
- **Interfaces**: Define database operations.
- **Classes**: Implement database operations.
- **Generics**: Create a reusable repository for CRUD operations.

---

## Submission Instructions
1. Submit the following files:
   - SQL script to create the database, table, stored procedures, view, and function.
   - C# Console Application project files.

2. Ensure your code is properly documented with comments.

3. Submit a report explaining the design choices for your application and database.

---

## Deliverables
1. **Database Script**: SQL file with all database objects.
2. **C# Code**: Fulfill all assignment requirements using OOP principles.
3. **Execution**: Ensure the application runs successfully and meets the objectives.

---

## Tools & Technologies Used:

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
