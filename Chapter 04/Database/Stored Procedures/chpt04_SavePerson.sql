IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt04_SavePerson')
	BEGIN
		DROP  Procedure  chpt04_SavePerson
	END

GO

CREATE Procedure dbo.chpt04_SavePerson
(
	@FirstName varchar(50),
	@LastName varchar(50),
	@BirthDate datetime,
	--@City [varchar](50),
	--@Country [varchar](50),
	@LocationId bigint,
	@PersonId bigint OUTPUT
)
AS

--DECLARE @LocationId bigint

--EXEC chpt04_SaveLocation @City, @Country, @LocationId OUTPUT
	
INSERT into chpt04_Person
(FirstName, LastName, BirthDate, LocationID)
values (@FirstName, @LastName, @BirthDate, @LocationID)

SET @PersonId = @@IDENTITY

GO

GRANT EXEC ON chpt04_SavePerson TO PUBLIC
GO
