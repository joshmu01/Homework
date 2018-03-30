--*************************************************************************--
-- Title: Characters
-- Author: Joshua Mueller
-- Desc: This file will be used to store data for D&D characters.
-- Change Log: 2018-March-12, Joshua Mueller, Created File
--**************************************************************************--
Use Master;
Go

If Exists(Select Name From SysDatabases Where Name = 'AdventuringEquipmentList')
 Begin 
  Alter Database [AdventuringEquipmentList] Set Single_user With Rollback Immediate;
  Drop Database AdventuringEquipmentList;
 End
Go

Create Database AdventuringEquipmentList;
Go

Use AdventuringEquipmentList;
Go


-- Create Tables

Create Table Categories
([CategoryID] [int] Identity(1,1) NOT NULL 
,[CategoryName] [nvarchar](50) NOT NULL
);
go

Create Table Items
([ItemID] [int] Identity(1,1) NOT NULL 
,[ItemName] [nvarchar](50) NOT NULL 
,[CategoryID] [int] NOT NULL
,[ItemPrice] [money] NOT NULL
,[ItemWeight] [decimal] (6,2) NOT NULL
);
Go

Create Table Users
([UserID] [int] Identity(1,1) NOT NULL 
,[UserFirstName] [nvarchar] (50) NOT NULL
,[UserLastName] [nvarchar] (50) NOT NULL
,[UserName] [nvarchar] (50) NOT NULL
,[UserPassword] [nvarchar] (50) NOT NULL
,[IsActive] [bit] NOT NULL
);
Go

Create Table Characters
([CharacterID] [int] Identity(1,1) NOT NULL
,[CharacterName] [nvarchar] (50) NOT NULL
,[CharacterPicture] [nvarchar] (50) NULL
,[UserID] [int] NOT NULL
,[IsActive] [bit] NOT NULL
);
Go

Create Table Proficiencies
([ProficiencyID] [int] Identity(1,1) NOT NULL
,[CharacterID] [int] NOT NULL
,[CategoryID] [int] NOT NULL
);
Go

Create Table Inventories
([InventoryID] [int] Identity(1,1) NOT NULL 
,[CharacterID] [int] NOT NULL
,[ItemID] [int]  NOT NULL
,[Quantity] [int] NOT NULL
);
Go

-- Add Constraints

Begin -- Categories
	Alter Table Categories 
		Add Constraint pkCategories 
		Primary Key (CategoryID);

	Alter Table Categories 
		Add Constraint ukCategories 
		Unique (CategoryName);
End
Go

Begin -- Items
	Alter Table Items 
		Add Constraint pkItems 
		Primary Key (ItemID);

	Alter Table Items 
		Add Constraint ukItems
		Unique (ItemName);

	Alter Table Items
		Add Constraint fkItemsToCategories
		Foreign Key (CategoryId) References Categories(CategoryId);

	Alter Table Items 
		Add Constraint ckPositiveItemPrice
		Check (ItemPrice > 0);

	Alter Table Items 
		Add Constraint ckPositiveItemWeight
		Check (ItemWeight > 0);
End
Go

Begin -- Users
	Alter Table Users 
		Add Constraint pkUsers
		Primary Key (UserID);
		
	Alter Table Users
		Add Constraint ukUserName
		Unique (UserName);

	Alter Table Users
		Add Constraint ckUserPasswordTest
		Check (Len(UserPassword) >= 8);
End
Go

Begin -- Characters
	Alter Table Characters
		Add Constraint pkCharacterID
		Primary Key (CharacterID);

	Alter Table Characters
		Add Constraint fkCharactersToUsers
		Foreign Key (UserID) References Users(UserID);
End
Go

Begin -- Proficiencies
	Alter Table Proficiencies
		Add Constraint pkProficiencyID
		Primary Key (ProficiencyID);

	Alter Table Proficiencies
		Add Constraint ukProficiencies
		Unique (CharacterID, CategoryID);
End
Go

Begin -- Inventories
	Alter Table Inventories 
		Add Constraint pkInvenoryID
		Primary Key (InventoryID);
		
	Alter Table Inventories
		Add Constraint fkInventoriesToUsers
		Foreign Key (CharacterID) References Characters(CharacterID);
		
	Alter Table Inventories
		Add Constraint fkInventoriesToItems
		Foreign Key (ItemID) References Items(ItemID);

	Alter Table Inventories
		Add Constraint ukLimitItemUser
		Unique (CharacterID, ItemID);

	Alter Table Inventories
		Add Constraint ckNonNegativeInventory
		Check (Quantity >= 0);
End
Go


-- Insert Starting Values

Insert Into Categories
(CategoryName, IsRestricted)
	Values
		('Light Armor'),
		('Medium armor'),
		('Heavy Armor'),
		('Shields'),
		('Simple Melee Weapons'),
		('Martial Melee Weapons'),
		('Simple Ranged Weapons'),
		('Martial Ranged Weapons'),
		('Musical Instruments'),
		('Arcane Gear'),
		('Artisan Gear'),
		('Domestic Gear'),
		('Illegal Gear'),
		('Religious Gear'),
		('Scholarly Gear'),
		('Common Gear')
;
Go

Insert Into Items
(ItemName, CategoryID, ItemPrice, ItemWeight)
	Values
		('Leather Armor', 1, 10.00, 10.00),
		('Padded Armor', 1, 5.00, 8.00),
		('Studded Leather Armor', 1, 45.00, 13.00),
		('Chain Shirt Armor', 2, 50.00, 20.00),
		('Breastplate Armor', 2, 400.00, 20.00),
		('Half Plate Armor', 2, 750.00, 40.00),
		('Hide Armor', 2, 10.00, 12.00),
		('Scale Mail Armor', 2, 50.00, 45.00),
		('Chain Mail Armor', 3, 75.00, 55.00),
		('Full Plate Armor', 3, 1500.00, 65.00),
		('Ring Mail Armor', 3, 30.00, 40.00),
		('Splint Armor', 3, 200.00, 60.00),
		('Metal Shield', 4, 10.00, 10.00),
		('Wood Shield', 4, 5.00, 6.00),
		('Club', 5, 0.10, 2.00),
		('Dagger', 5, 2.00, 1.00),
		('Greatclub', 5, 0.20, 10.00),
		('Handaxe', 5, 5.00, 2.00),
		('Javelin', 5, 5.00, 2.00),
		('Light Hammer', 5, 2.00, 2.00),
		('Mace', 5, 5.00, 4.00),
		('Quarterstaff', 5, 0.20, 4.00),
		('Sickle', 5, 1.00, 2.00),
		('Spear', 5, 1.00, 3.00),
		('Battleaxe', 6, 10.00, 4.00),
		('Flail', 6, 10.00, 2.00),
		('Glaive', 6, 20.00, 6.00),
		('Greataxe', 6, 30.00, 7.00),
		('Greatsword', 6, 50.00, 6.00),
		('Halberd', 6, 20.00, 6.00),
		('Lance', 6, 10.00, 6.00),
		('Longsword', 6, 15.00, 3.00),
		('Maul', 6, 10.00, 10.00),
		('Morningstar', 6, 15.00, 4.00),
		('Net', 6, 1.00, 3.00),
		('Pike', 6, 5.00, 18.00),
		('Rapier', 6, 25.00, 2.00),
		('Scimitar', 6, 25.00, 3.00),
		('Shortsword', 6, 10.00, 2.00),
		('Trident', 6, 5.00, 4.00),
		('War Pick', 6, 5.00, 2.00),
		('Warhammer', 6, 15.00, 2.00),
		('Whip', 6, 2.00, 3.00),
		('Crossbow, Light', 7, 25.00, 5.00),
		('Dart', 7, 0.05, 0.25),
		('Shortbow', 7, 25.00, 2.00),
		('Sling', 7, 0.01, 0.01),
		('Blowgun', 8, 10.00, 1.00),
		('Crossbow, Hand', 8, 75.00, 3.00),
		('Crossbow, Heavy', 8, 50.00, 18.00),
		('Longbow', 8, 50.00, 2.00),
		('Ammunition (20 Arrows)', 16, 1.00, 1.00),
		('Ammunition (50 Blowgun Needles)', 16, 1.00, 1.00),
		('Ammunition (20 Crossbow Bolts)', 16, 1.00, 1.50),
		('Ammunition (20 Sling Bullets)', 16, 1.00, 1.50),
		('Bagpipes', 9, 30.00, 6.00),
		('Drum', 9, 6.00, 3.00),
		('Dulcimer', 9, 25.00, 10.00),
		('Flute',9, 2.00, 1.00),
		('Lyre', 9, 30.00, 2.00),
		('Horn', 9, 3.00, 2.00),
		('Pan Flute', 9, 12.00, 2.00),
		('Shawm', 9, 2.00, 1.00),
		('Viola', 9, 30.00, 1.00),
		('Alchemist’s Supplies', 10, 50.00, 8.00),
		('Arcane Focus', 10, 10.00, 2.00),
		('Book, Spells', 10, 50.00, 3.00),
		('Component Pouch', 10, 25.00, 2.00),
		('Carpenter’s Tools', 11, 15.00, 6.00),
		('Glassblower’s Tools', 11, 30.00, 5.00),
		('Jeweler’s Tools', 11, 25.00, 2.00),
		('Leatherworker’s Tools', 11, 5.00, 5.00),
		('Mason’s Tools', 11, 10.00, 8.00),
		('Painter’s Supplies', 11, 10.00, 5.00),
		('Potter’s Tools', 11, 10.00, 3.00),
		('Scale, Merchant’s', 11, 5.00, 3.00),
		('Smith’s Tools', 11, 20.00, 8.00),
		('Brewer’s Tools', 12, 20.00, 9.00),
		('Cobbler’s Tools', 12, 25.00, 5.00),
		('Cook’s Utensils', 12, 5.00, 8.00),
		('Herbalism Kit', 12, 5.00, 3.00),
		('Weaver’s Tools', 12, 1.00, 5.00),
		('Woodcarver’s Tools', 12, 1.00, 5.00),
		('Disguise Kit', 13, 25.00, 3.00),
		('Forgery Kit', 13, 15.00, 5.00),
		('Poison (Vial)', 13, 100.00, 0.30),
		('Poisoner’s Kit', 13, 50.00, 2.00),
		('Thieves’ Tools', 13, 25.00, 1.00),
		('Alm’s Box, Empty', 14, 5.00, 1.00),
		('Book, Scripture', 14, 25.00, 5.00),
		('Censer', 14, 5.00, 2.00),
		('Healer’s Kit', 14, 5.00, 3.00),
		('Holy Symbol', 14, 5.00, 1.00),
		('Holy Water (flask)', 14, 25.00, 1.50),
		('Incense (1 block)', 14, 0.01, 0.10),
		('Book, Blank', 15, 25.00, 5.00),
		('Calligrapher’s Tools', 15, 10.00, 5.00),
		('Cartographer’s Tools', 15, 15.00, 6.00),
		('Ink (1-ounce bottle)', 15, 10.00, 0.10),
		('Ink Pen', 15, 0.02, 0.02),
		('Navigator’s Tools', 15, 25.00, 2.00),
		('Paper (one sheet)', 15, 0.20, 0.01),
		('Parchment (one sheet)', 15, 0.10, 0.02),
		('Tinker’s Tools', 15, 50.00, 10.00),
		('Abacus', 16, 2.00, 2.00),
		('Acid (vial)', 16, 25.00, 0.30),
		('Alchemist’s Fire (flask)', 16, 50.00, 1.50),
		('Amulet/Necklace, Exquisite', 16, 5.00, 0.15),
		('Amulet/Necklace, Mundane', 16, 5.00, 0.15),
		('Antitoxin (vial)', 16, 50.00, 0.30),
		('Backpack, Empty', 16, 2.00, 5.00),
		('Ball Bearings (Bag of 1,000)', 16, 1.00, 2.00),
		('Barrel, Empty', 16, 2.00, 70.00),
		('Basket, Empty', 16, 0.40, 2.00),
		('Bedroll', 16, 1.00, 7.00),
		('Bell', 16, 1.00, 0.01),
		('Blanket', 16, 0.50, 3.00),
		('Block and Tackle', 16, 1.00, 5.00),
		('Bottle, Glass, Empty', 16, 2.00, 2.00),
		('Bucket, Empty', 16, 0.05, 2.00),
		('Caltrops (Bag of 20)', 16, 1.00, 2.00),
		('Candle', 16, 0.01, 0.10),
		('Case, Crossbow Bolt, Empty', 16, 1.00, 1.00),
		('Case, Map or Scroll, Empty', 16, 1.00, 1.00),
		('Chain (10 feet)', 16, 5.00, 10.00),
		('Chalk (1 piece)', 16, 1.00, 0.10),
		('Chest, Empty', 16, 5.00, 25.00),
		('Climber’s Kit', 16, 25.00, 12.00),
		('Clothes, Common', 16, 0.50, 3.00),
		('Clothes, Costume', 16, 5.00, 4.00),
		('Clothes, Fine', 16, 15.00, 6.00),
		('Clothes, Traveler’s', 16, 2.00, 4.00),
		('Crowbar', 16, 2.00, 5.00),
		('Earrings, Exquisite', 16, 4.00, 0.05),
		('Earrings, Mundane', 16, 4.00, 0.05),
		('Fishing Bait', 16, 0.05, 1.00),
		('Fishing Tackle', 16, 1.00, 4.00),
		('Flask or Tankard, Empty', 16, 0.02, 0.50),
		('Gaming Set (Chess)', 16, 1.00, 0.50),
		('Gaming set (Dice Set)', 16, 0.10, 0.05),
		('Gaming Set (Playing Cards)', 16, 0.50, 0.10),
		('Grappling Hook', 16, 2.00, 4.00),
		('Hammer', 16, 1.00, 3.00),
		('Hammer, Sledge', 16, 2.00, 10.00),
		('Hourglass', 16, 25.00, 1.00),
		('Hunting Trap', 16, 5.00, 25.00),
		('Jug or Pitcher, Empty', 16, 0.02, 4.00),
		('Ladder (10-foot)', 16, 0.10, 25.00),
		('Lamp', 16, 0.50, 1.00),
		('Lantern, Bullseye', 16, 10.00, 2.00),
		('Lantern, Hooded', 16, 5.00, 2.00),
		('Lock', 16, 10.00, 1.00),
		('Manacles', 16, 2.00, 6.00),
		('Mess Kit', 16, 0.20, 1.00),
		('Mirror, Steel', 16, 5.00, 0.50),
		('Oil (flask)', 16, 0.10, 1.50),
		('Perfume (vial)', 16, 5.00, 0.30),
		('Pick, Miner’s', 16, 2.00, 10.00),
		('Piton', 16, 0.05, 0.25),
		('Pole (10-foot)', 16, 0.05, 7.00),
		('Pot, Iron', 16, 2.00, 10.00),
		('Pouch', 16, 5.00, 1.00),
		('Quiver', 16, 1.00, 1.00),
		('Ram, Portable', 16, 4.00, 35.00),
		('Rations (1-day)', 16, 5.00, 2.00),
		('Ring, Exquisite', 16, 3.00, 0.05),
		('Ring, Mundane', 16, 3.00, 0.05),
		('Robes', 16, 1.00, 4.00),
		('Rope, Hempen (50 feet)', 16, 1.00, 10.00),
		('Rope, Silk (50 feet)', 16, 10.00, 5.00),
		('Sack, Empty', 16, 0.01, 0.50),
		('Sealing Wax', 16, 0.50, 0.10),
		('Shovel', 16, 2.00, 5.00),
		('Signal Whistle', 16, 0.05, 0.10),
		('Signet Ring', 16, 5.00, 0.10),
		('Soap', 16, 0.02, 0.50),
		('Spikes, Iron (10)', 16, 1.00, 5.00),
		('Spyglass', 16, 1000.00, 1.00),
		('Tent, Two-person', 16, 2.00, 20.00),
		('Tinderbox', 16, 0.50, 1.00),
		('Torch', 16, 0.01, 1.00),
		('Vial, Empty', 16, 0.10, 0.05),
		('Waterskin, Empty', 16, 0.20, 1.00),
		('Whetstone', 16, 0.01, 1.00)
;
Go

Insert Into Users
(UserFirstName, UserLastName, UserName, UserPassword, IsActive)
	Values
		('Joshua', 'Mueller', 'JoMu0001', 'Password', 1)
;
Go

Insert Into Characters
(CharacterName, UserID, IsActive)
	Values
		('Sir Kills-a-lot', 1, 1)
;
Go

Insert Into Proficiencies
(CharacterID, CategoryID)
	Values
		(1, 5),
		(1, 7),
		(1, 16),
		(1, 1),
		(1, 2),
		(1, 3),
		(1, 4),
		(1, 6),
		(1, 8)
;
Go

Insert Into Inventories
(CharacterID, ItemID, Quantity)
	Values
		(1, 3, 1),
		(1, 5, 1),
		(1, 6, 1),
		(1, 10, 1),
		(1, 13, 1),
		(1, 16, 1),
		(1, 32, 1),
		(1, 39, 1),
		(1, 50, 1),
		(1, 54, 2),
		(1, 111, 1),
		(1, 115, 1),
		(1, 117, 1),
		(1, 119, 3),
		(1, 122, 7),
		(1, 123, 1),
		(1, 124, 1),
		(1, 126, 9),
		(1, 128, 1),
		(1, 132, 1),
		(1, 133, 1),
		(1, 138, 3),
		(1, 142, 1),
		(1, 147, 2),
		(1, 151, 1),
		(1, 153, 1),
		(1, 155, 1),
		(1, 156, 3),
		(1, 161, 1),
		(1, 162, 1),
		(1, 165, 10),
		(1, 170, 1),
		(1, 171, 2),
		(1, 176, 1),
		(1, 179, 1),
		(1, 180, 1),
		(1, 181, 5),
		(1, 182, 4),
		(1, 183, 2),
		(1, 184, 1)
;
Go

-- Add Views

-- This view will display the Categories table.
Create View vCategories
With Schemabinding
As
	Select
		CategoryID,
		CategoryName
	From
		dbo.Categories;
Go

-- This view will display the Items table.
Create View vItems
With Schemabinding
As
	Select
		ItemID,
		ItemName,
		CategoryID,
		ItemPrice,
		ItemWeight
	From
		dbo.Items;
Go

-- This view will display the Users table.
Create View vUsers
With Schemabinding
As
	Select
		UserID,
		UserFirstName,
		UserLastName,
		UserName,
		UserPassword,
		IsActive
	From
		dbo.Users;
Go

-- This view will display the Characters table.
Create View vCharacters
With Schemabinding
As
	Select
		CharacterID,
		CharacterName,
		CharacterPicture,
		UserID,
		IsActive
	From
		dbo.Characters;
Go

-- This view will display the Categories table.
Create View vInventories
With Schemabinding
As
	Select
		InventoryID,
		CharacterID,
		ItemID,
		Quantity
	From
		dbo.Inventories;
Go

-- This view will display an Inventory of all Items available to a Character.
Create View vItemsAvailableToCharacter
	As
		Select
			[Category] = Ca.CategoryName,
			[Item] = I.ItemName,
			[Price] = I.ItemPrice,
			[Weight] = I.ItemWeight
		From
			dbo.Items As I
			Inner Join dbo.Categories As Ca
			On I.CategoryID = Ca.CategoryID
			Inner Join dbo.Proficiencies As P
			On P.CategoryID = Ca.CategoryID
			Inner Join dbo.Characters As Ch
			On Ch.CharacterID = P.CharacterID;
Go	

-- This view will display an Inventory of all Items owned by a Character.
Create View vCharacterItemInventory
	As
		Select
			[Character] = Ch.CharacterName,
			[Category] = Ca.CategoryName,
			[Item] = It.ItemName,
			[Price] = It.ItemPrice,
			[Weight] = It.ItemWeight,
			[Qty.] = I.Quantity,
			[Total Price] = (It.ItemPrice * I.Quantity),
			[Total Weight] = (It.ItemWeight * I.Quantity)
		From
			dbo.Inventories As I
			Inner Join dbo.Characters As Ch
			On I.CharacterID = Ch.CharacterID
			Inner Join dbo.Items As It
			On I.ItemID = It.ItemID
			Inner Join dbo.Categories As Ca
			On It.CategoryID = Ca.CategoryID
			Inner Join dbo.Proficiencies As P
			On (P.CharacterID = Ch.CharacterID) And (P.CategoryID = Ca.CategoryID);
Go		

-- This view will display the total weight of a Character's inventory.
Create View vTotalWeightOfCharacterItemInventory
	As
		Select
			[Character],
			[Total Carried Weight] = Sum([Total Weight])
		From
			dbo.vCharacterItemInventory
		Group By
			[Character];
Go	

-- This view will display the total value of a Character's inventory.
Create View vTotalValueOfCharacterItemInventory
	As
		Select
			[Character],
			[Total Inventory Value] = Sum([Total Price])
		From
			dbo.vCharacterItemInventory
		Group By
			[Character];
Go	
	
Select * From vItemsAvailableToCharacter
Select * From vCharacterItemInventory
Select * From vTotalValueOfCharacterItemInventory
Select * From vTotalWeightOfCharacterItemInventory;
Go	

-- Add Stored Procedures

-- This procedure inserts new data entries into the Categories table.
Create Procedure pInsertCategory
(@CategoryName nvarchar(50))
As
	Begin
		Declare @RC int = 0;
		Begin Try
			Begin Transaction
				Insert Into Categories (CategoryName)
				Values (@CategoryName);
			Commit TRansaction
			Set @RC = +1
		End Try
		Begin Catch
			Rollback Transaction
			Print Error_Message()
			Set @RC = -1
		End Catch
		Return @RC;
	End
Go

-- This procedure inserts new data entries into the Items table.
Create Procedure pInsertItem
(@ItemName nvarchar(50)
,@CategoryID int
,@ItemPrice money
,@ItemWeight decimal (6,2))
As
	Begin
		Declare @RC int = 0;
		Begin Try
			Begin Transaction
				Insert Into Items (ItemName, CategoryID, ItemPrice, ItemWeight)
				Values (@ItemName, @CategoryID, @ItemPrice, @ItemWeight);
			Commit TRansaction
			Set @RC = +1
		End Try
		Begin Catch
			Rollback Transaction
			Print Error_Message()
			Set @RC = -1
		End Catch
		Return @RC;
	End
Go

-- This procedure changes the Price for am Item in the Items table.
Create Procedure pUpdateItemPrice
(@ItemPrice money
,@ItemID int)
As
	Begin
		Declare @RC int = 0;
		Begin Try
			Begin Transaction
				Update Items
				Set ItemPrice = @ItemPrice
				Where ItemID = @ItemID;
			Commit TRansaction
			Set @RC = +1
		End Try
		Begin Catch
			Rollback Transaction
			Print Error_Message()
			Set @RC = -1
		End Catch
		Return @RC;
	End
Go

-- This procedure inserts new data entries into the Items table.
Create Procedure pInsertUser
(@UserFirstName nvarchar(50)
,@UserLastName nvarchar (50)
,@UserName nvarchar (50)
,@UserPassword nvarchar (50))
As
	Begin
		Declare @RC int = 0;
		Begin Try
			Begin Transaction
				Insert Into Users(UserFirstName, UserLastName, UserName, UserPassword)
				Values (@UserFirstName, @UserLastName, @UserName, @UserPassword);
			Commit TRansaction
			Set @RC = +1
		End Try
		Begin Catch
			Rollback Transaction
			Print Error_Message()
			Set @RC = -1
		End Catch
		Return @RC;
	End
Go

-- This procedure changes the Price for an Item in the Items table.
Create Procedure pUpdateUserPassword
(@UserPassword nvarchar (50)
,@UserID int)
As
	Begin
		Declare @RC int = 0;
		Begin Try
			Begin Transaction
				Update Users
				Set UserPassword = @UserPassword
				Where UserID = @UserID;
			Commit TRansaction
			Set @RC = +1
		End Try
		Begin Catch
			Rollback Transaction
			Print Error_Message()
			Set @RC = -1
		End Catch
		Return @RC;
	End
Go

-- This procedure changes the IsActive tag for a User in the Users table.
Create Procedure pUpdateUserIsActive
(@IsActive bit
,@UserID int)
As
	Begin
		Declare @RC int = 0;
		Begin Try
			Begin Transaction
				Update Users
				Set IsActive = @IsActive
				Where UserID = @UserID;
			Commit TRansaction
			Set @RC = +1
		End Try
		Begin Catch
			Rollback Transaction
			Print Error_Message()
			Set @RC = -1
		End Catch
		Return @RC;
	End
Go

-- This procedure inserts new data entries into the Characters table.
-- It does not insert the CharacterPicture data.
Create Procedure pInsertCharacter
(@CharacterName nvarchar (50)
,@UserID int)
As
	Begin
		Declare @RC int = 0;
		Begin Try
			Begin Transaction
				Insert Into Characters(CharacterName, UserID)
				Values (@CharacterName, @UserID);
			Commit TRansaction
			Set @RC = +1
		End Try
		Begin Catch
			Rollback Transaction
			Print Error_Message()
			Set @RC = -1
		End Catch
		Return @RC;
	End
Go

-- This procedure changes the Name of a Character in the Characters table.
Create Procedure pUpdateCharacterName
(@CharacterID int
,@CharacterName nvarchar (50))
As
	Begin
		Declare @RC int = 0;
		Begin Try
			Begin Transaction
				Update Characters
				Set CharacterName = @CharacterName
				Where CharacterID = @CharacterID;
			Commit TRansaction
			Set @RC = +1
		End Try
		Begin Catch
			Rollback Transaction
			Print Error_Message()
			Set @RC = -1
		End Catch
		Return @RC;
	End
Go

-- This procedure changes the Picture of a Character in the Characters table.
Create Procedure pUpdateCharacterPicture
(@CharacterID int
,@CharacterPicture nvarchar (50))
As
	Begin
		Declare @RC int = 0;
		Begin Try
			Begin Transaction
				Update Characters
				Set CharacterPicture = @CharacterPicture
				Where CharacterID = @CharacterID;
			Commit TRansaction
			Set @RC = +1
		End Try
		Begin Catch
			Rollback Transaction
			Print Error_Message()
			Set @RC = -1
		End Catch
		Return @RC;
	End
Go

-- This procedure inserts new data entries into the Inventories table.
Create Procedure pInsertInventoryItem
(@CharacterID int
,@ItemID int
,@Quantity int)
As
	Begin
		Declare @RC int = 0;
		Begin Try
			Begin Transaction
				Insert Into Inventories(CharacterID, ItemID, Quantity)
				Values (@CharacterID, @ItemID, @Quantity);
			Commit TRansaction
			Set @RC = +1
		End Try
		Begin Catch
			Rollback Transaction
			Print Error_Message()
			Set @RC = -1
		End Catch
		Return @RC;
	End
Go

-- This procedure changes the Quantity of an Item in the Inventories table.
Create Procedure pUpdateInventoryQuantity
(@Quantity int
,@InventoryID int)
As
	Begin
		Declare @RC int = 0;
		Begin Try
			Begin Transaction
				Update Inventories
				Set Quantity = @Quantity
				Where InventoryID = @InventoryID;
			Commit TRansaction
			Set @RC = +1
		End Try
		Begin Catch
			Rollback Transaction
			Print Error_Message()
			Set @RC = -1
		End Catch
		Return @RC;
	End
Go



Select * From Categories;
Select * From Items;
Select * From Users;
Select * From Characters;
Go