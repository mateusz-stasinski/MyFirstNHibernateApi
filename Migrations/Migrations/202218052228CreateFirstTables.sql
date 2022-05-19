CREATE TABLE CarManufacturer
(
	Id int PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(16) NOT NULL
)
GO

CREATE TABLE CarModel
(
	Id int PRIMARY KEY IDENTITY(1,1),
	Manufacturer int NOT NULL,
	Name nvarchar(16) NOT NULL,
	FOREIGN KEY (Manufacturer) REFERENCES CarManufacturer(Id)
)
GO

CREATE TABLE Car
(
	Id uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
	Model int NOT NULL,
	YearOfProduction int,
	RegistrationNumber nvarchar(8) NOT NULL,
	FOREIGN KEY (Model) REFERENCES CarModel(Id)
)