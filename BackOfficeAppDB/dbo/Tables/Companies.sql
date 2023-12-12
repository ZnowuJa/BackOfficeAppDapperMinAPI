CREATE TABLE [dbo].[Companies] (
    [Id]   INT       PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [Name] NCHAR (30) NOT NULL, 
    [VATID] NCHAR(10) NOT NULL, 
    [Street] NCHAR(30) NULL, 
    [Building] NCHAR(10) NULL, 
    [City] NCHAR(30) NULL, 
    [PostalCode] NCHAR(10) NULL, 
    [Country] NCHAR(20) NULL, 
    [CountryCode] NCHAR(3) NULL, 
    [ContactPerson] NCHAR(30) NULL, 
    [ContactPersonMobile] NCHAR(16) NULL, 
    [ContactPersonEmail] NCHAR(50) NULL, 
    [CompanyTypeId] INT NULL,

    FOREIGN KEY ([CompanyTypeId]) REFERENCES [dbo].[CompanyTypes] ([Id])
);