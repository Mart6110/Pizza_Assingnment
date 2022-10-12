/* Creating a database called ZBCPizza */
CREATE DATABASE ZBCPizza;

/* Doing so we use the database ZBCPizza */
USE ZBCPizza;

/* Creating Price table */
CREATE TABLE Price
(
	Price_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Price INT
);

/* Creating Pizza table */
CREATE TABLE Pizza
(
	Pizza_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(255) NOT NULL,
	Tomato_Sauce BIT NOT NULL,
	Cheese BIT NOT NULL,
	Topping_1 VARCHAR(255) NULL,
	Topping_2 VARCHAR(255) NULL,
	Topping_3 VARCHAR(255) NULL,
	Topping_4 VARCHAR(255) NULL,
	Topping_5 VARCHAR(255) NULL,
	Price_id INT FOREIGN KEY REFERENCES Price(Price_id)
);

/* Creating Drink table */
CREATE TABLE Drink
(
	Drink_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(255) NOT NULL,
	Size INT,
	Price_id INT FOREIGN KEY REFERENCES Price(Price_id)
);

/* Creating Toppings table */
CREATE TABLE Toppings
(
	Toppings_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Topping VARCHAR(255),
	Price_id INT FOREIGN KEY REFERENCES Price(Price_id)
);

/* Creating Menu table */
CREATE TABLE Menu
(
	Menu_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Pizza_id INT FOREIGN KEY REFERENCES Pizza(Pizza_id),
	Drink_id INT FOREIGN KEY REFERENCES Drink(Drink_id),
	Toppings_id INT FOREIGN KEY REFERENCES Toppings(Toppings_id)
);

/* Creating stored procedures for Price */
/* Using CRUD */
/* Creating a stored procedure to create prices */
CREATE PROCEDURE spAddPrice
(
	@Price INT
)
AS
BEGIN
	INSERT INTO Price (Price)
	VALUES (@Price)
END

/* Creating a stored procedure to update prices */
CREATE PROCEDURE spUpdatePrice
(
	@Price_id INT,
	@Price INT
)
AS
BEGIN
	UPDATE Price
	SET Price = @Price
	WHERE Price_id = @Price_id
END

/* Creating a stored procedure to delete prices */
CREATE PROCEDURE spDeletePrice
(
	@Price_id INT
)
AS
BEGIN
	DELETE FROM Price WHERE Price_id = @Price_id
END

/* Creating a stored procedure to read the prices */
CREATE PROCEDURE spGetAllPrice
AS
BEGIN
	SELECT * FROM Price ORDER BY Price_id
END

/* Creating stored procedures for Pizza */
/* Using CRUD */
/* Creating a stored procedure to create pizzas */
CREATE PROCEDURE spAddPizza
(
	@Name VARCHAR(255),
	@Tomato_Sauce BIT,
	@Cheese BIT,
	@Topping_1 VARCHAR(255) = null,
	@Topping_2 VARCHAR(255) = null,
	@Topping_3 VARCHAR(255) = null,
	@Topping_4 VARCHAR(255) = null,
	@Topping_5 VARCHAR(255) = null,
	@Price_id INT
)
AS
BEGIN
	INSERT INTO Pizza (Name, Tomato_Sauce, Cheese, Topping_1, Topping_2, Topping_3, Topping_4, Topping_5, Price_id)
	VALUES (@Name, @Tomato_Sauce, @Cheese, @Topping_1, @Topping_2, @Topping_3, @Topping_4, @Topping_5, @Price_id)
END

/* Creating a stored procedure to update pizzas */
CREATE PROCEDURE spUpdatePizza
(
	@Pizza_id INT,
	@Name VARCHAR(255),
	@Tomato_Sauce BIT,
	@Cheese BIT,
	@Topping_1 VARCHAR(255) = null,
	@Topping_2 VARCHAR(255) = null,
	@Topping_3 VARCHAR(255) = null,
	@Topping_4 VARCHAR(255) = null,
	@Topping_5 VARCHAR(255) = null,
	@Price_id INT
)
AS
BEGIN
	UPDATE Pizza
	SET Name = @Name,
	Tomato_Sauce = @Tomato_Sauce,
	Cheese = @Cheese,
	Topping_1 = @Topping_1,
	Topping_2 = @Topping_2,
	Topping_3 = @Topping_3,
	Topping_4 = @Topping_4,
	Topping_5 = @Topping_5,
	Price_id = @Price_id
	WHERE Pizza_id = @Pizza_id
END

/* Creating a stored procedure to delete pizzas */
CREATE PROCEDURE spDeletePizza
(
	@Pizza_id INT
)
AS
BEGIN
	DELETE FROM Pizza WHERE Pizza_id = @Pizza_id
END

/* Creating a stored procedure to read pizzas */
CREATE PROCEDURE spGetAllPizza
AS
BEGIN
	SELECT * FROM Pizza ORDER BY Pizza_id
END

/* Creating stored procedures for Drink */
/* CRUD */
/* Creating a stored procedure to create drinks */
CREATE PROCEDURE spAddDrink
(
	@Name VARCHAR(255),
	@Size INT,
	@Price_id INT
)
AS
BEGIN
	INSERT INTO Drink (Name, Size, Price_id)
	VALUES (@Name, @Size, @Price_id)
END

/* Creating a stored procedure to update drinks */
CREATE PROCEDURE spUpdateDrink
(
	@Drink_id INT,
	@Name VARCHAR(255),
	@Size INT,
	@Price_id INT
)
AS
BEGIN
	UPDATE Drink
	SET Name = @Name,
	Size = @Size,
	Price_id = @Price_id
	WHERE Drink_id = @Drink_id
END

/* Creating a stored procedure to delete drinks */
CREATE PROCEDURE spDeleteDrink
(
	@Drink_id INT
)
AS
BEGIN
	DELETE FROM Drink WHERE Drink_id = @Drink_id
END

/* Creating a stored procedure to read drinks */
CREATE PROCEDURE spGetAllDrink
AS
BEGIN
	SELECT * FROM Drink ORDER BY Drink_id
END

/* Creating stored procedures for Toppings */
/* CRUD */
/* Creating a stored procedure to create toppings */
CREATE PROCEDURE spAddTopping
(
	@Topping VARCHAR(255),
	@Price_id INT
)
AS
BEGIN
	INSERT INTO Toppings (Topping, Price_id)
	VALUES (@Topping, @Price_id)
END

/* Creating a stored procedure to update toppings */
CREATE PROCEDURE spUpdateTopping
(
	@Toppings_id INT,
	@Topping VARCHAR(255),
	@Price_id INT
)
AS
BEGIN
	UPDATE Toppings
	SET Topping = @Topping,
	Price_id = @Price_id
	WHERE Toppings_id = @Toppings_id
END

/* Creating a stored procedure delete toppings */
CREATE PROCEDURE spDeleteTopping
(
	@Toppings_id INT
)
AS
BEGIN
	DELETE FROM Toppings WHERE Toppings_id = @Toppings_id
END

/* Creating a stored procedure to read toppings */
CREATE PROCEDURE spGetAllTopping
AS
BEGIN
	SELECT * FROM Toppings ORDER BY Toppings_id
END

/*Creating stored procedure for Pizza menu*/
CREATE PROCEDURE spGetAllMenuPizza
AS
BEGIN
	SELECT Pizza_id, Name, 
	/* A concat that has all the toppings in it */
	CONCAT( 
	/* A case where if 1 then is will show Tomat and if 0 it will show nothing */
	CASE 
		WHEN Tomato_Sauce = 1 THEN 'Tomat'
		WHEN Tomato_Sauce = 0 THEN ''
		ELSE ''
	END,' ',
	/* A case where if 1 then is will show Tomat and if 0 it will show nothing */
	CASE 
		WHEN Cheese = 1 THEN 'Ost'
		WHEN Cheese = 0 THEN ''
		ELSE ''
	END,' ', Topping_1,' ', Topping_2, ' ', Topping_3, ' ', Topping_4,' ', Topping_5) AS 'Toppings', Price
	FROM Pizza
	/* An inner join to price on price.id */
	INNER JOIN Price
	ON Pizza.Price_id = Price.Price_id
	/* We order the table after id */
	ORDER BY Pizza.Pizza_id;
END


/*Creating stored procedure for Drink menu*/
CREATE PROCEDURE spGetAllMenuDrink
AS
BEGIN
	SELECT Drink_id, Name, Size, Price
	FROM Drink
	/* An inner join to price on price.id */
	INNER JOIN Price
	ON Drink.Price_id = Price.Price_id
	/* We order the table after id */
	ORDER BY Drink.Drink_id;
END