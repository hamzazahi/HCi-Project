create database Bakery_Management_System

create table Roles (
role_id int primary key not null,
role_name nvarchar(max)
);

insert into Roles values(1, 'Admin')
insert into Roles values(2, 'Client')

create table category ( 
cat_id int primary key identity(1,1) not null,
cat_name nvarchar(max),
cat_description nvarchar(max)
);

insert into category values('Cakes', '')
insert into category values('Beverages', '')
insert into category values('Pasteries', '')
insert into category values('Bakery Items', '')

select * from category

create table Products ( 
p_id int primary key identity(1000,1) not null,
p_name nvarchar(max),
price decimal,
quantity decimal,
p_description nvarchar(max),
cat_id int foreign key references Category(cat_id)
);

--create table adminn (
--role_id int foreign key references Roles(role_id),
--admin_id int primary key identity(11498,1) not null,
--username nvarchar(max),
--FullName nvarchar(max),
--passwordd nvarchar(max)
--);

--select * from adminn
--insert into adminn values(1, 'Tasawur', 'Tasawur Imam', 'tasawur@123')
--insert into adminn values(1, 'Saad', 'Saad Ahmed Khan', 'saad@123')

--create table clients (
--role_id int foreign key references Roles(role_id),
--client_id int primary key identity(11144,1) not null,
--username nvarchar(max),
--FullName nvarchar(50) unique,
--passwordd nvarchar(max),
--address_ nvarchar(50) unique,
--phone decimal unique,
--cnic decimal unique
--);

create table loginn (
role_id int foreign key references Roles(role_id),
id int primary key identity(11144,1) not null,
username nvarchar(50) unique,
FullName nvarchar(50) unique,
passwordd nvarchar(max),
address_ nvarchar(50) unique,
phone decimal unique,
cnic decimal unique
);

insert into loginn values(1, 'Tasawur', 'Tasawur Imam', 'tasawur@123', 'Gulistan-e-Jauhar', 03310378665, 12345678)
insert into loginn values(1, 'Saad', 'Saad Ahmed Khan', 'saad@123', 'Gulshan-e-Iqbal', 03340302008, 321178)
select * from loginn
select * from clients

create table Orders (
orderID decimal primary key identity(112544, 1) not null,
id int foreign key references loginn(id),
p_id int foreign key references Products(p_id),
t_quantity int,
FullName nvarchar(50) foreign key references loginn(FullName),
address_ nvarchar(50) foreign key references loginn(address_),
phone decimal foreign key references loginn(phone)
);

-- create proc RegUser 
 --( 
--	@roleid int,
--	@username nvarchar(max),
--	@fullname nvarchar(max),
--	@passwordd nvarchar(max),
--	@address_ nvarchar(max),
--	@phone decimal,
--	@cnic decimal
-- )
-- as 
-- begin 
-- insert into clients values (@roleid, @username, @fullname, @passwordd, @address_, @phone, @cnic)
-- end

select * from Products
select p_name from Products inner join category on Products.cat_id = category.cat_id where category.cat_id = 1 and p_id = 1000;

 create proc LoginUser 
 ( 
	@roleid int,
	@username nvarchar(max),
	@fullname nvarchar(max),
	@passwordd nvarchar(max),
	@address_ nvarchar(max),
	@phone decimal,
	@cnic decimal
 )
 as 
 begin 
 insert into loginn values (@roleid, @username, @fullname, @passwordd, @address_, @phone, @cnic)
 end

create proc adminlogin
(
  @username nvarchar(150),
  @passwordd nvarchar(150)
)

as
begin
  select username, passwordd from loginn where username=@username and passwordd=@passwordd and role_id = 1;
end

create proc clientlogin
(
	@username nvarchar(50),
	@passwordd nvarchar(50)
)
as begin
	select username, passwordd from loginn  where username=@username and passwordd=@passwordd and role_id = 2
end

--INSERT PRODUCT--
create proc InsertProduct
(
  @name nvarchar(max),
  @price decimal,
  @quantity decimal,
  @descp nvarchar(max),
  @cat_id int
  
)
as
begin
  insert into Products(p_name, price, quantity, p_description, cat_id)
  values(@name, @price, @quantity, @descp, @cat_id)
 end

 --ViewProducts--
 create proc ViewProducts 
 as begin 
 select p_id as ID, p_name as Name, category.cat_name as Category, price as Price, quantity as Quantity, p_description as Description
 from Products 
inner join category on Products.cat_id = category.cat_id 
 end

 --ViewCakes--
 create proc ViewCakes
 as begin 
 select p_id as ID, p_name as Name, category.cat_name as Category, price as Price, quantity as Quantity, p_description as Description
 from Products 
inner join category on Products.cat_id = category.cat_id where category.cat_id = 1
 end
 --ViewBevrages--
 create proc ViewBev
 as begin 
 select p_id as ID, p_name as Name, category.cat_name as Category, price as Price, quantity as Quantity, p_description as Description
 from Products 
inner join category on Products.cat_id = category.cat_id where category.cat_id = 2
 end
 --ViewPast--
 create proc ViewPast
 as begin 
 select p_id as ID, p_name as Name, category.cat_name as Category, price as Price, quantity as Quantity, p_description as Description
 from Products 
inner join category on Products.cat_id = category.cat_id where category.cat_id = 3
 end
 --ViewBI--
 create proc ViewBI
 as begin 
 select p_id as ID, p_name as Name, category.cat_name as Category, price as Price, quantity as Quantity, p_description as Description
 from Products 
inner join category on Products.cat_id = category.cat_id where category.cat_id = 4 
 end

 --UPDATE--
 create proc UpdateProduct
 (
	@p_id int,
	@p_name nvarchar(max),
	@price decimal,
	@quantity decimal,
	@p_description nvarchar(max),
	@cat_id int
 )
 as
 BEGIN
            UPDATE Products
            SET    p_name = @p_name,
                   price = @price,
                   quantity = @quantity,
                   p_description = @p_description,
				   cat_id = @cat_id
            WHERE  p_id = @p_id
END

drop proc UpdateProduct
--DELETE--
create proc DelPro
(
	@p_id int
)
as 
begin
delete from Products where p_id = @p_id
end

--View Customers--
 create proc ViewCustomers 
 as begin 
select id as ID, username as Username, FullName, passwordd as Password, address_ as Address, phone as Phone, cnic as CNIC, Roles.role_name as Role
from loginn 
inner join Roles on loginn.role_id = Roles.role_id where Roles.role_id = 2
 end