IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt03_SavePerson')
	BEGIN
		DROP  Procedure  chpt03_SavePerson
	END

GO

CREATE Procedure dbo.chpt03_SavePerson
(
	@FirstName varchar(50),
	@LastName varchar(50),
	@BirthDate datetime,
	@LocationId bigint,
	@PersonId bigint OUTPUT
)
AS
	
	INSERT into chpt03_Person
	(FirstName, LastName, BirthDate, LocationID)
	values (@FirstName, @LastName, @BirthDate, @LocationID)

	SET @PersonId = @@IDENTITY

GO

GRANT EXEC ON chpt03_SavePerson TO PUBLIC
GO
