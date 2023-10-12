-- 1. Introduction to Databases
-- Briefly explain what a database is and why it's important.

-- 2. SQL Basics

-- Create Database
CREATE DATABASE DemoDB;
GO

USE DemoDB;
GO

-- Create Table
CREATE TABLE Employees (
    ID INT PRIMARY KEY,
    Name VARCHAR(50),
    Age INT,
    Department VARCHAR(50)
);
GO

-- Insert Data
INSERT INTO Employees (ID, Name, Age, Department)
VALUES (1, 'Maria', 30, 'HR'),
       (2, 'Farhan', 40, 'Finance'),
       (3, 'Ali', 35, 'Development');
GO

-- 3. Hands-On Exercises

-- SELECT Command
SELECT * FROM Employees;
select * from Departments

-- UPDATE Command
UPDATE Employees
SET Age = 31
WHERE ID = 1;
GO

-- DELETE Command
DELETE FROM Employees
WHERE ID = 3;
GO

-- 4. Data Relationships

-- Create Another Table
CREATE TABLE Departments (
    DeptID INT PRIMARY KEY,
    DeptName VARCHAR(50)
);
GO

-- Insert Data
INSERT INTO Departments (DeptID, DeptName)
VALUES (1, 'HR'),
       (2, 'Finance'),
       (3, 'Development');
GO

-- Add a DepartmentID column to the Employees table:
ALTER TABLE Employees
ADD DepartmentID INT;
GO

--Update the DepartmentID values based on the existing Department names:
UPDATE Employees
SET DepartmentID = (SELECT DeptID FROM Departments WHERE DeptName = Employees.Department); --DeptName = 'HR'
GO

-- Add Foreign Key
ALTER TABLE Employees
ADD CONSTRAINT FK_Department
FOREIGN KEY (DepartmentID) REFERENCES Departments(DeptID);
GO

-- ALTER TABLE Employees
ALTER TABLE Employees
DROP COLUMN Department;
GO


-- 5. Queries and Filters

-- Simple Query
SELECT * FROM Employees
WHERE Age > 30;
GO

-- JOIN Query
SELECT E.Name, D.DeptName
FROM Employees E
JOIN Departments D ON E.DepartmentID = D.DeptID;
GO

-- 6. Aggregation Functions

-- COUNT Function
SELECT COUNT(*) FROM Employees;
GO

-- SUM Function
SELECT SUM(Age) FROM Employees;
GO


SELECT * FROM Employees;
select * from Departments

select * from Employees emp
join Departments dept on dept.DeptID = emp.DepartmentId
where dept.DeptName  = 'HR'