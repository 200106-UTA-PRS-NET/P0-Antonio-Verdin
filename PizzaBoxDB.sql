Create database Pizzabox
go
use Pizzabox
go
create schema Pizza
go
create table Pizza.Addressing(
	Id int identity(1,1),
	City varchar(25) not null,
	Address1 varchar(25) not null,
	Address2 varchar(25),
	Street varchar(25) not null,
	PhoneNumber varchar(15) not null,
	Primary key (Id)
	);
go
create table Pizza.Customer(
	Id int identity(1,1) not null,
	FirstName varchar(25) not null,
	LastName varchar(25) not null,
	_Address int Foreign key references Pizza.Addressing(Id),
	UserPassWord varchar(50)
	Primary key (Id)
	);
create table Pizza.Employee(
	Id int identity(1,1) not null,
	Username nchar(10) not null,
	EmployeePassword varchar(50),
	Primary key (Id));
go
create table Pizza.Store(
	Id int identity(1,1),
	_name varchar(20),
	_Address int Foreign key references Pizza.Addressing(Id)
	Primary key (Id)
	);

create table Pizza.Orders(
	Id int identity(1,1) not null,
	TotalPrice money,
	OrderStatus nchar(10),
	PlaceDate datetime,
	DeliveryDate datetime,
	StoreId int Foreign key References Pizza.Store(Id),
	EmployeeId int Foreign key References Pizza.Employee(Id),
    CustomerId int Foreign key References Pizza.Customer(Id)
	Primary key (Id));
go
create table Pizza.Pizza(
	Id int identity(1,1) not null,
	OrderId int Foreign key References Pizza.Orders(Id) not null,
	Amount tinyint default 1 not null,
	Primary key (Id));
go
Create table Pizza.Ingredients(
	Id int identity(1,1) not null,
	Topping varchar(25) not null,
	Price money not null,
	Amount int default 0 not null,
	_type varchar(10) not null,
	Primary key(Id),
	Check (_type IN ('Cheese','Crust','Topping','Sauce'))
	);
go
Create table Pizza.Pizza_Ingredients(
	Id int identity(1,1) not null,
	PizzaId int Foreign key References Pizza.Pizza(Id) not null,
	IngredientId int foreign key references Pizza.Ingredients(Id) not null,
	Finished bit default 0 not null,
	Primary key(Id)
	);