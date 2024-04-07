-- Create a new database called 'TodoPHPAPIBase'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'TodoPHPAPIBase'
)
CREATE DATABASE TodoPHPAPIBase
GO

USE TodoPHPAPIBase
GO

-- Create a new table called 'Categories' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Categories', 'U') IS NOT NULL
DROP TABLE dbo.Categories
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Categories
(
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, -- primary key column
    [Name] [NVARCHAR](50) NOT NULL,
    [InsertedAt] DATETIME NOT NULL,
    [UpdatedAt] DATETIME NOT NULL,
    [DeletedAt] DATETIME NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    -- specify more columns here
);
GO

-- Create a new table called 'Todos' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Todos', 'U') IS NOT NULL
DROP TABLE dbo.Todos
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Todos
(
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, -- primary key column
    [Title] [NVARCHAR](255) NOT NULL,
    [IsCompleted] BIT NOT NULL DEFAULT 0,
    [CategoryId] UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES dbo.Categories(Id),
    [InsertedAt] DATETIME NOT NULL,
    [UpdatedAt] DATETIME NOT NULL,
    [DeletedAt] DATETIME NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
);
GO

-- Insert some sample data into the 'Categories' table
INSERT INTO dbo.Categories (Id, [Name], [InsertedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES
(NEWID(), 'Work', GETDATE(), GETDATE(), NULL, 0),
(NEWID(), 'Personal', GETDATE(), GETDATE(), NULL, 0),
(NEWID(), 'Shopping', GETDATE(), GETDATE(), NULL, 0);
GO

-- Insert some sample data into the 'Todos' table
INSERT INTO dbo.Todos (Id, [Title], [IsCompleted], [CategoryId], [InsertedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES
(NEWID(), 'Finish project report', 0, (SELECT Id FROM dbo.Categories WHERE [Name] = 'Work'), GETDATE(), GETDATE(), NULL, 0),
(NEWID(), 'Buy groceries', 0, (SELECT Id FROM dbo.Categories WHERE [Name] = 'Shopping'), GETDATE(), GETDATE(), NULL, 0),
(NEWID(), 'Go for a run', 0, (SELECT Id FROM dbo.Categories WHERE [Name] = 'Personal'), GETDATE(), GETDATE(), NULL, 0);
GO