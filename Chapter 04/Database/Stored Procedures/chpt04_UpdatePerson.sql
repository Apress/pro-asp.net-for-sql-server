IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt04_UpdatePerson')
	BEGIN
		DROP  Procedure  chpt04_UpdatePerson
	END

GO

CREATE Procedure dbo.chpt04_UpdatePerson
(
	@FirstName varchar(50),
	@LastName varchar(50),
	@BirthDate datetime,
	@City [varchar](50),
	@Country [varchar](50),
	@Original_PersonId bigint,
	@Original_FirstName varchar(50),
	@Original_LastName varchar(50),
	@Original_BirthDate datetime,
	@Original_City [varchar](50),
	@Original_Country [varchar](50)
)
AS

SET NOCOUNT OFF;

DECLARE @LocationId bigint

EXEC chpt04_SaveLocation @City, @Country, @LocationId OUTPUT

UPDATE chpt04_Person SET [FirstName] = @FirstName, [LastName] = @LastName, 
[BirthDate] = @BirthDate, [LocationId] = @LocationId WHERE 
(([PersonId] = @Original_PersonId));

SELECT p.PersonId,p.FirstName,p.LastName,p.BirthDate,l.City,l.Country 
FROM chpt04_Person AS p
JOIN chpt04_Location AS l on l.LocationId = p.LocationId
where p.PersonId = @Original_PersonId

GO

GRANT EXEC ON chpt04_UpdatePerson TO PUBLIC
GO
