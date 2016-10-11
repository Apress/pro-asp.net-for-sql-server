IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt02_SavePerson')
	BEGIN
		DROP  Procedure  chpt02_SavePerson
	END

GO

CREATE Procedure dbo.chpt02_SavePerson
(
	@FirstName varchar(50),
	@LastName varchar(50),
	@BirthDate datetime,
	@LocationId bigint,
	@PersonId bigint OUTPUT
)
AS
	
	INSERT into chpt02_Person
	(FirstName, LastName, BirthDate, LocationID)
	values (@FirstName, @LastName, @BirthDate, @LocationID)

	SET @PersonId = @@IDENTITY

GO

GRANT EXEC ON chpt02_SavePerson TO PUBLIC
GO
