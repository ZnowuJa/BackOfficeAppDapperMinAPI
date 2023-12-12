CREATE TABLE [dbo].[Users](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](50) NOT NULL,
	[LastName] [nchar](50) NOT NULL,
	[ADLogonName] [nchar](50) NULL,
	[ThirdPartyId] [nchar](50) NULL,
	[Email] [nchar](50) NULL,
	[MobileNumber] [nchar](20) NULL,
	[PhoneNumber] [nchar](20) NULL,
	[isDeactivated] [bit] Not Null Default 'false',
	[isDeactivatedDate] smalldatetime not null default '1900-01-01 00:00:00'
)
GO
