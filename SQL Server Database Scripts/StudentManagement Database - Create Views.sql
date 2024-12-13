/*
--------------------------------------------------------------------
© 2024 - By Ehab Sadiq 
--------------------------------------------------------------------
Name		: StudentManagement
GitHub Repo : https://github.com/HoBaaMa/CSharp-App-Integrated-With-SQL-Server
--------------------------------------------------------------------
*/

USE StudentManagement;

CREATE VIEW StudentDetails AS
	SELECT StudentID , (FirstName + ' ' + LastName) AS FullName, Grade
	FROM Students;