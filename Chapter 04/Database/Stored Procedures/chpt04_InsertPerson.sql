IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt04_InsertPerson')
	BEGIN
		DROP  Procedure  chpt04_InsertPerson
	END

GO

CREATE Procedure dbo.chpt04_InsertPerson
(
	@FirstName varchar(50),
	@LastName varchar(50),
	@BirthDate datetime,
	@City [varchar](50),
	@Country [varchar](50)
)
AS

SET NOCOUNT OFF;

DECLARE @PersonId bigint
DECLARE @LocationId bigint

EXEC chpt04_SaveLocation @City, @Country, @LocationId OUTPUT
	
INSERT into chpt04_Person
(FirstName, LastName, BirthDate, LocationID)
values (@FirstName, @LastName, @BirthDate, @LocationID)

SET @PersonId = @@IDENTITY

SELECT p.PersonId,p.FirstName,p.LastName,p.BirthDate,l.City,l.Country 
FROM chpt04_Person AS p
JOIN chpt04_Location AS l on l.LocationId = p.LocationId
where p.PersonId = @PersonId

GO

GRANT EXEC ON chpt04_InsertPerson TO PUBLIC
GO
