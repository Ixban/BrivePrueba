CREATE DATABASE brive;

USE brive;

CREATE TABLE users (
  id int PRIMARY KEY IDENTITY(1, 1),
  name varchar(125),
  lastname varchar(125),
  username varchar(50),
  email varchar(50),
  password varchar(255),
  created datetime,
  edited datetime
)
GO

CREATE TABLE sucursal (
  id int PRIMARY KEY IDENTITY(1, 1),
  sucursalname varchar(125),
  telefono int,
  direction varchar(250),
  created datetime,
  edited datetime
)
GO

CREATE TABLE product (
  id int PRIMARY KEY IDENTITY(1, 1),
  name varchar(125),
  sku varchar(250),
  created datetime,
  edited datetime
)
GO

CREATE TABLE log (
  id int PRIMARY KEY IDENTITY(1, 1),
  iduser int,
  action varchar(50),
  module varchar(50),
  created datetime,
  edited datetime
)
GO

CREATE TABLE inventory (
  id int PRIMARY KEY IDENTITY(1, 1),
  amount int,
  created datetime,
  edited datetime,
  idproduct int,
  idsucursal int
)
GO

ALTER TABLE log ADD FOREIGN KEY (iduser) REFERENCES users (id)
GO

ALTER TABLE inventory ADD FOREIGN KEY (idproduct) REFERENCES product (id)
GO

ALTER TABLE inventory ADD FOREIGN KEY (idsucursal) REFERENCES sucursal (id)
GO

---STORED PROCEDURE

--usuarios
CREATE PROCEDURE LoginUsuario @email varchar(255)
AS
 SELECT * FROM [brive].[dbo].[users] as users where users.email =@email
GO	

CREATE PROCEDURE getUsuarios
AS
 SELECT * FROM [brive].[dbo].[users]
GO	

CREATE PROCEDURE userDelete @id int
AS
 DELETE FROM [brive].[dbo].[users] WHERE id = @Id;
GO	

CREATE PROCEDURE UsuarioAdd @name VARCHAR(125), @lastname VARCHAR(125), @username VARCHAR(50), @email varchar(50), @created datetime, @edited datetime
AS
 INSERT INTO [brive].[dbo].[users]
           ([name]
           ,[lastname]
           ,[username]
           ,[email]
           ,[Password]
           ,[created]
           ,[edited])
     VALUES
           (@name
           ,@lastname
           ,@username
           ,@email
           ,CONVERT(varchar(255), NEWID())
           ,@created
           ,@edited)
GO

CREATE PROCEDURE GetUsuarioId @id int
AS
	SELECT [id]
      ,[name]
      ,[lastname]
      ,[username]
      ,[email]
      ,[password]
      ,[created]
      ,[edited]
  FROM [brive].[dbo].[users] WHERE users.id = @id
GO

CREATE PROCEDURE UpdateUsuario @id INT, @name VARCHAR(125), @lastname VARCHAR(125), @username VARCHAR(50), @email varchar(50)
AS

UPDATE [brive].[dbo].[users]
   SET [name] = @name
      ,[lastname] = @lastname
      ,[username] = @username
      ,[email] = @email
	  ,[edited] = GETDATE()
 WHERE [users].id = @id


GO

---logs
CREATE PROCEDURE getLogs
AS
 SELECT * FROM [brive].[dbo].[log]
GO	

CREATE PROCEDURE logsAdd @iduser int, @action VARCHAR(50), @module VARCHAR(50)
AS
 INSERT INTO [brive].[dbo].[log]
       ([iduser]
      ,[action]
      ,[module]
      ,[created]
      ,[edited])
     VALUES
           (@iduser
           ,@action
           ,@module
           ,GETDATE()
           ,GETDATE())
GO

--sucursales
CREATE PROCEDURE getSucursales
AS
 SELECT * FROM [brive].[dbo].[sucursal]
GO	

CREATE PROCEDURE sucursalDelete @id int
AS
 DELETE FROM [brive].[dbo].[sucursal]  WHERE id = @Id;
GO	

CREATE PROCEDURE sucursalAdd @sucursalname VARCHAR(125), @telefono int, @direction VARCHAR(250)
AS
 INSERT INTO [brive].[dbo].[sucursal]
           ([sucursalname]
			,[telefono]
			,[direction]
			,[created]
			,[edited])
     VALUES
           (@sucursalname
           ,@telefono
           ,@direction
           ,GETDATE()
		   ,GETDATE()
		   )
GO

CREATE PROCEDURE getSucursalId @id int
AS
	SELECT [id]
      ,[sucursalname]
      ,[telefono]
      ,[direction]
      ,[created]
      ,[edited]
  FROM [brive].[dbo].[sucursal] WHERE sucursal.id = @id
GO

CREATE PROCEDURE updateSucursal @id INT,  @sucursalname VARCHAR(125), @telefono int, @direction VARCHAR(250)
AS

UPDATE [brive].[dbo].[sucursal]
   SET [sucursalname] = @sucursalname
      ,[telefono] = @telefono
      ,[direction] = @direction
	  ,[edited] = GETDATE()
 WHERE [sucursal].id = @id

GO

--Producto

--sucursales
CREATE PROCEDURE getProduct
AS
 SELECT * FROM [brive].[dbo].[product]
GO	

CREATE PROCEDURE productDelete @id int
AS
 DELETE FROM [brive].[dbo].[product]  WHERE id = @Id;
GO	

CREATE PROCEDURE productAdd @name VARCHAR(125), @sku VARCHAR(250)
AS
 INSERT INTO [brive].[dbo].[product]
           ([name]
			,[sku]
			,[created]
			,[edited])
     VALUES
           (@name
           ,@sku
           ,GETDATE()
		   ,GETDATE()
		   )
GO

CREATE PROCEDURE getProductId @id int
AS
	SELECT [id]
      ,[name]
      ,[sku]
      ,[created]
      ,[edited]
  FROM [brive].[dbo].[product] WHERE product.id = @id
GO

CREATE PROCEDURE productUpdate @id INT, @name VARCHAR(125), @sku VARCHAR(250)
AS
UPDATE [brive].[dbo].[product]
   SET [name] = @name
      ,[sku] = @sku
	  ,[edited] = GETDATE()
 WHERE [product].id = @id

GO



--inventory
CREATE PROCEDURE getInventory
AS
	
GO	

CREATE PROCEDURE inventoryDelete @id int
AS
 DELETE FROM [brive].[dbo].[inventory]  WHERE id = @Id;
GO	

CREATE PROCEDURE inventoryAdd @amount int, @idProduct int, @idSucursal int
AS
 INSERT INTO [brive].[dbo].[inventory]
           ([amount]
			,[idproduct]
			,[idsucursal]
			,[created]
			,[edited])
     VALUES
           (@amount
           ,@idProduct
		   ,@idSucursal
           ,GETDATE()
		   ,GETDATE()
		   )
GO

CREATE PROCEDURE getInventoryId @id int
AS
	SELECT inventory.id,amount,idproduct,idsucursal,product.name as productoNombre, sucursal.sucursalname As sucursalNombre FROM [brive].[dbo].[inventory] INNER JOIN product ON product.id = inventory.idproduct INNER JOIN sucursal ON sucursal.id = inventory.idsucursal WHERE inventory.id = @id
GO

CREATE PROCEDURE inventoryUpdate  @id int, @amount int, @idProduct int, @idSucursal int
AS
UPDATE [brive].[dbo].[inventory]
   SET [amount] = @amount
      ,[idProduct] = @idProduct
	  ,[idsucursal] = @idSucursal
	  ,[edited] = GETDATE()
 WHERE [inventory].id = @id

GO
