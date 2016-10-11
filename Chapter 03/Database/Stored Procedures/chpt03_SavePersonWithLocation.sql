IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt03_SavePersonWithLocation')
	BEGIN
		DROP  Procedure  chpt03_SavePersonWithLocation
	END

GO

CREATE Procedure dbo.chpt03_SavePersonWithLocation
(
	@FirstName varchar(50),
	@LastName varchar(50),
	@BirthDate datetime,
	@City [varchar](50),
	@Country [varchar](50),
	@LocationId bigint OUTPUT,
	@PersonId bigint OUTPUT
)
AS

EXEC chpt03_SaveLocation @City, @Country, @LocationId OUTPUT

EXEC chpt03_SavePerson @FirstName, @LastName, @BirthDate, @LocationId, @PersonId OUTPUT

GO

GRANT EXEC ON chpt03_SavePersonWithLocation TO PUBLIC
GO


