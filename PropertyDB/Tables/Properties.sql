CREATE TABLE [dbo].[Properties]
(
	[Id] INT,
	[YearBuilt] varchar(4),
	[ListPrice] decimal(20,2) not null,
	[MonthlyRent] decimal(20,2) not null,
	[AddressId] int not null,
	CONSTRAINT PK_Properties PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Properties_Addresses] FOREIGN KEY (AddressId) REFERENCES [Addresses](Id)
)
