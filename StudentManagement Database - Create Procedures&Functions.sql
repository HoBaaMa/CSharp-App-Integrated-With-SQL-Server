/*
--------------------------------------------------------------------
© 2024 - By Ehab Sadiq 
--------------------------------------------------------------------
Name		: StudentManagement
GitHub Repo : https://github.com/HoBaaMa/CSharp-App-Integrated-With-SQL-Server
--------------------------------------------------------------------
*/

USE StudentManagement;

CREATE PROCEDURE InsertStudent 
    @first_name NVARCHAR(50), 
    @last_name NVARCHAR(50), 
    @date_of_birth DATE, 
    @grade DECIMAL(5, 2)
AS
BEGIN
    -- Ensure column names are explicitly mentioned in the INSERT statement
    INSERT INTO Students (FirstName, LastName, DateOfBirth, Grade)
    VALUES (@first_name, @last_name, @date_of_birth, @grade);
END;

CREATE PROCEDURE GetStudentsByGrade
@grade_input AS DECIMAL(3,2)
AS
BEGIN
	SELECT *
	FROM Students
	WHERE grade > @grade_input;
END;

CREATE FUNCTION CalculateAge (@date_of_birth DATE)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(YEAR, @date_of_birth, GETDATE());
END;