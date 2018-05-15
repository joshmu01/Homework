-- **************************************************************************
-- Title: LearningCenterDB
-- Author: Joshua Mueller
-- Desc: Basic database for storage of users and classes.
-- Change Log: 2018-May-5, Joshua Mueller, Created File
-- **************************************************************************


Use Master;
Go

If Exists(Select Name From SysDatabases Where Name = 'SchoolDB')
 Begin 
  Alter Database [SchoolDB] Set Single_user With Rollback Immediate;
  Drop Database SchoolDB;
 End
Go

Create Database SchoolDB;
Go

Use SchoolDB;
Go


-- **************************************************************************
-- This section includes table creation and field constraints.
-- **************************************************************************


Begin -- Users

	Create Table Users
		([UserID] [int] Identity(1,1) NOT NULL 
		,[UserName] [nvarchar](50) NOT NULL
		,[UserEmail] [nvarchar](50) NOT NULL
		,[UserPassword] [nvarchar](50) NOT NULL
		,[UserIsAdmin] [bit] NOT NULL
		);

	Alter Table Users 
		Add Constraint pkUsers 
		Primary Key (USerID);

	Alter Table Users
		Add Constraint ukUsersNames
		Unique (UserName);

	Alter Table Users
		Add Constraint ukUsersEmails
		Unique (UserEmail);

	Alter Table Users
		Add Constraint dfUsers
		Default 0 For UserIsAdmin;

End
Go

Begin -- Classes

	Create Table Classes
		([ClassID] [int] Identity(1,1) NOT NULL 
		,[ClassName] [nvarchar](50) NOT NULL
		,[ClassDescription] [nvarchar] (50) NOT NULL
		,[ClassPrice] [money] NOT NULL
		);

	Alter Table Classes 
		Add Constraint pkClasses 
		Primary Key (ClassID);

	Alter Table Classes 
		Add Constraint ukClasses
		Unique (ClassName);

	Alter Table Classes 
		Add Constraint ckPositiveClassPrice
		Check (ClassPrice > 0);

End
Go

Begin -- UserClasses

	Create Table UserClasses
		([UserID] [int] NOT NULL
		,[ClassID] [int] NOT NULL
		);

	Alter Table UserClasses
		Add Constraint pkUserClasses
		Primary Key (UserID, ClassID);

	Alter Table UserClasses
		Add Constraint fkUserClassesToUsers
		Foreign Key (UserID) References Users(UserID);

	Alter Table UserClasses
		Add Constraint fkUserClassesToClasses
		Foreign Key (ClassID) References Classes(ClassID);

End
Go


-- **************************************************************************
-- This section includes the insertion of beginning values.
-- **************************************************************************


Insert Into Users
(UserName, UserEmail, UserPassword, USerIsAdmin)
	Values
		('Joshua', 'joshua@learningcenter.com', 'password12345', 1),
		('John', 'john@learningcenter.com', 'password54321', 0),
		('Jane', 'jane@learningcenter.com', '12345password', 0)
;
Go

Insert Into Classes
(ClassName, ClassDescription, ClassPrice)
	Values
		('C# Programming', 'Learn to program using C# and .NET', 200.00),
		('Database Management', 'Learn to create and manage SQL Server databases', 250.00),
		('Mobile Apps-Android', 'Learn to develop applications for the Android OS', 300.00),
		('Mobile Apps-Apple', 'Learn to develop applications for the Apple OS', 350.00),
		('Angular', 'Learn to create dynamic web UI', 500.00)
;
Go

Insert Into UserClasses
(UserID, ClassID)
	Values
		(1, 1),
		(1, 2),
		(2, 4),
		(2, 5),
		(3, 3),
		(3, 5)
;
Go
