CREATE TABLE [dbo].[Addresses]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	[Address1] varchar(255) not null,
    [Address2] varchar(255),
    [City] varchar(100) not null,
    [Country] varchar(100) not null,
    [County] varchar(100),
    [District] varchar(100),
    [State] varchar(50),
    [Zip] varchar(5),
    [ZipPlus4] varchar(4)
)
