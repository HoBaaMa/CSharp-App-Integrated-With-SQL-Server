/*
--------------------------------------------------------------------
© 2024 - By Ehab Sadiq 
--------------------------------------------------------------------
Name		: StudentManagement
GitHub Repo : https://github.com/HoBaaMa/CSharp-App-Integrated-With-SQL-Server
--------------------------------------------------------------------
*/

CREATE DATABASE StudentManagement 
ON PRIMARY
(
NAME = 'StudentManagement',
FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\StudentManagement.mdf',
SIZE = 20MB,
MAXSIZE = 40MB,
FILEGROWTH = 2MB
)

LOG ON
(
NAME = 'StudentManagement_log',
FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\StudentManagement.ldf',
SIZE = 20MB,
MAXSIZE = 40MB,
FILEGROWTH = 2MB
);


CREATE TABLE Students 
(
StudentID INT IDENTITY(1,1),
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
DateOfBirth DATE,
Grade DECIMAL(3,2) DEFAULT(0.00)

CONSTRAINT students_pk PRIMARY KEY (StudentID)
);
