create database ProductInventoryDb
use ProductInventoryDb

Create Table ProductInventory
(ProductId int Primary Key,
ProductName nvarchar(50),
Price decimal(10,2),
Quantity int,
MfDate date,
ExpDate date)

INSERT INTO ProductInventory (ProductId, ProductName, Price, Quantity, MfDate, ExpDate) VALUES
(1, 'Fresho',450, 2, '2001-01-15', '2003-01-14'),
(2, 'Rose', 500, 8, '2001-03-02', '2004-03-11'),
(3, 'Mphmi', 89, 9, '2001-04-14', '2004-04-11'),
(4, 'Flower Seeds', 45, 3, '2001-01-02', '2002-05-20'),
(5, 'Ariya Rare',50, 1, '2001-11-05', '2003-02-03')

Select * From ProductInventory