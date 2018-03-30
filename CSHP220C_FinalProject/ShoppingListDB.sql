--*************************************************************************--
-- Title: ShoppingList
-- Author: Joshua Mueller
-- Desc: CSHP220C Project Data
-- Change Log: 2018-March-28, Joshua Mueller, Created File
--**************************************************************************--
Use Master;
Go

If Exists(Select Name From SysDatabases Where Name = 'ShoppingList')
 Begin 
  Alter Database [ShoppingList] Set Single_user With Rollback Immediate;
  Drop Database ShoppingList;
 End
Go

Create Database ShoppingList;
Go

Use ShoppingList;
Go


-- Tables and Constraints

Begin -- Categories
	Create Table Categories
		([CategoryID] [int] Identity(1,1) NOT NULL 
		,[CategoryName] [nvarchar](50) NOT NULL
		);
	Alter Table Categories
		Add Constraint pkCategories
		Primary Key (CategoryID);

	Alter Table Categories
		Add Constraint ukCategoryName
		Unique (CategoryName);
End
Go

Begin -- Items
	Create Table Items
		([ItemID] [int] Identity(1,1) NOT NULL 
		,[ItemName] [nvarchar](50) NOT NULL
		,[CategoryID] [int] NOT NULL
		,[ItemPrice] [decimal] (6,2) NOT NULL
		,[ItemQuantity] [int] NOT NULL
		);

	Alter Table Items
		Add Constraint pkItems
		Primary Key (ItemID);

	Alter Table Items
		Add Constraint ukItemName
		Unique (ItemName);

	Alter Table Items
		Add Constraint fkItemsToCategories
		Foreign Key (CategoryID) References Categories(CategoryID);

	Alter Table Items 
		Add Constraint ckPositiveItemPrice
		Check (ItemPrice > 0);
		
	Alter Table Items 
		Add Constraint ckNonNegativeItemQuantity
		Check (ItemQuantity >= 0);
End
Go


-- Beginning Data

Insert Into Categories
	(CategoryName)
	Values
		('Groceries'),
		('Cleaning Supplies'),
		('Toiletries'),
		('Office Suplies')
;
Go

Insert Into Items
	(ItemName, CategoryID, ItemPrice, ItemQuantity)
	Values
		('Dozen Eggs', 1, 1.29, 2),
		('Loaf of Bread', 1, 3.49, 2),
		('Gallon of Milk', 1, 3.19, 3),
		('5lb. Bag of Rice', 1, 5.99, 2),
		('Bleach', 2, 2.39, 4),
		('Laundry Detergent', 2, 12.99, 1),
		('Dish Soap', 2, 7.59, 2),
		('Scrub Brush', 2, 3.99, 6),
		('Soap', 3, 2.19, 8),
		('Shampoo', 3, 14.89, 1),
		('Conditioner', 3, 15.79, 1),
		('Lotion', 3, 4.29, 2),
		('Ream of Paper', 4, 6.99, 3),
		('Pencils', 4, 0.79, 12),
		('Pens', 4, 1.19, 12)
;
Go

