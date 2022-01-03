create database dbShop
go
use dbShop
go
-- Accounts -----------------------------------------------------------------------------------
create table Accounts
(
	AccountID int NOT NULL IDENTITY(1,1),
	Phone varchar(12),
	Email nvarchar(50),
	Password nvarchar(50),
	Salt nchar(6),
	Active bit not null,
	Fullname nvarchar(150),
	RoleID int FOREIGN KEY REFERENCES Roles(RoleID),
	LastLogin datetime,
	CreateDate datetime,
	PRIMARY KEY (AccountID)
);
go
-- drop table Accounts
-- Category -----------------------------------------------------------------------------------
-- drop table Category
create table Category
(
	CatID int NOT NULL IDENTITY(1,1),
	CatName nvarchar(255),
	Description nvarchar(max),
	ParentID int,
	Levels int,
	Ordering int,
	Published  bit not null,
	Thumb nvarchar(255),
	Title nvarchar(255),
	Alias nvarchar(255),
	MetaDesc nvarchar(255),
	MetaKey nvarchar(255),
	Cover nvarchar(255),
	SchemaMarkup nvarchar(max),
	PRIMARY KEY (CatID)
);
go

-- Customer -----------------------------------------------------------------------------------
create table Customers
(
	CustomerID int NOT NULL IDENTITY(1,1),
	Fullname nvarchar(255),
	Birthday datetime,
	Avatar nvarchar(255),
	Address nvarchar(255),
	Email nvarchar(150),
	Phone varchar(12),
	LocationID nvarchar(255),
	District nvarchar(255),
	Ward nvarchar(255),
	CreateDate datetime,
	Password nvarchar(50),
	Salt nchar(8),
	LastLogin datetime,
	Active bit not null,
	PRIMARY KEY (CustomerID)
);
go
ALTER TABLE Customers
ALTER COLUMN LocationID int 
-- location -----------------------------------------------------------------------------------
create table Locations
(
	LocationID int NOT NULL IDENTITY(1,1),
	Name nvarchar(255),
	Type nvarchar(20),
	Slug nvarchar(100),
	NameWithType nvarchar(255),
	PathWithType nvarchar(255),
	ParentCode int,
	Levels int,
	PRIMARY KEY (LocationID)
);
go
-- Order -----------------------------------------------------------------------------------
create table Orders
(
	OrderID int NOT NULL IDENTITY(1,1),
	CustomerID int FOREIGN KEY REFERENCES Customers(CustomerID),
	OrderDay datetime,
	ShipDay datetime,
	TransactStatusID int FOREIGN KEY REFERENCES TransactStatus(TransactStatusID),
	Deleted bit,
	Paid bit ,
	PaymentDay datetime,
	PaymentID int,
	Note nvarchar(max),
	PRIMARY KEY (OrderID)
);
go

-- OrderDetails -----------------------------------------------------------------------------------
create table OrderDetails
(
	OrderDetailID int NOT NULL IDENTITY(1,1),
	OrderID int FOREIGN KEY REFERENCES Orders(OrderID) ,
	ProductID int,
	OrderNumber int,
	Quantity int,
	Discount int,
	Total int ,
	ShipDate datetime,
	PRIMARY KEY (OrderDetailID)
);
go
-- drop table Products
-- Pages -----------------------------------------------------------------------------------
create table Pages
(
	PageID int NOT NULL IDENTITY(1,1),
	PageName nvarchar(255),
	Contents nvarchar(max),
	Thumb nvarchar(255) ,
	Published bit not null,
	Title nvarchar(255),
	MetaDesc nvarchar(255),
	MetaKey nvarchar(255),
	Alias nvarchar(255),
	CreateAt datetime,
	Orderding int ,
	PRIMARY KEY (PageID)
);
go

-- Products -----------------------------------------------------------------------------------
create table Products
(
	ProductID int NOT NULL IDENTITY(1,1),
	ProductName nvarchar(255) not null,
	ShortDesc nvarchar(255),
	Description  nvarchar(max),
	CatID int FOREIGN KEY REFERENCES Category(CatID),
	Price int,
	Discount int ,
	Thumb nvarchar(255),
	Video nvarchar(255),
	DateCreated datetime,
	DateModified datetime,
	BestSeller bit not null,
	HomeFlag bit not null,
	Active bit not null,
	Tag nvarchar(max),
	Title nvarchar(255),
	Alias nvarchar(255),
	MetaDesc nvarchar(255),
	MetaKey nvarchar(255),
	UnitslnStock int
	PRIMARY KEY (ProductID)
);
go
ALTER TABLE Products
DROP ProductID;
-- Roles -----------------------------------------------------------------------------------
create table Roles
(
	RoleID int NOT NULL IDENTITY(1,1),
	RoleName nvarchar(255),
	Description nvarchar(255),
	PRIMARY KEY (RoleID)
);
go
insert into Roles (RoleName,Description) values 
('Admin','Admin'),
('Staff','Nhân viên')
select * from Roles
-- Shippers -----------------------------------------------------------------------------------
create table Shippers
(
	ShipperID int NOT NULL IDENTITY(1,1),
	ShipperName nvarchar(255),
	Phone nchar(15),
	Company nvarchar(255),
	PRIMARY KEY (ShipperID)
);
go

-- Posts -------------------------------------------------------------------------------------
create table Posts (
	PostID int NOT NULL IDENTITY(1,1),
	Title nvarchar(255),
	SContents nvarchar(255),
	Content nvarchar(max),
	Thumb nvarchar(255),
	Published bit ,
	Alias nvarchar(255),
	CreatedDate datetime ,
	Author nvarchar(255),
	AccountID int ,
	Tags nvarchar(max),
	CatID int ,
	isHot bit ,
	isNewFeed bit,
	MetaKey nvarchar(255),
	MetaDesc nvarchar(255),
	Views int,
	PRIMARY KEY (PostID)
);
go


-- TransactStatus -------------------------------------------------------------------------------------
create table TransactStatus (
	TransactStatusID int NOT NULL IDENTITY(1,1),
	Status nvarchar(255),
	Description nvarchar(max)
	PRIMARY KEY (TransactStatusID)
);
go

ALTER TABLE Customers
ADD CONSTRAINT fk_Location_Customers
  FOREIGN KEY (LocationID)
  REFERENCES Locations (LocationID);
  select * from Category