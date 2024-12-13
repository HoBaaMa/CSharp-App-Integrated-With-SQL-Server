/*
--------------------------------------------------------------------
© 2024 - By Ehab Sadiq 
--------------------------------------------------------------------
Name		: StudentManagement
GitHub Repo : https://github.com/HoBaaMa/CSharp-App-Integrated-With-SQL-Server
--------------------------------------------------------------------
*/

USE StudentManagement;

-- Execute the stored procedure
EXEC InsertStudent 
    @first_name = 'Ahmed', 
    @last_name = 'Mohamed', 
    @date_of_birth = '2002-08-09', 
    @grade = 2.40;

SELECT * FROM Students;


EXEC GetStudentsByGrade
	@grade_input = 2.60;


SELECT * FROM StudentDetails;


SELECT dbo.CalculateAge('2000-01-01') AS Age;

SELECT 
    FirstName, 
    LastName, 
    DateOfBirth, 
    dbo.CalculateAge(DateOfBirth) AS Age
FROM 
    Students;
