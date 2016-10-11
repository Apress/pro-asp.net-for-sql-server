IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt03_GetPeopleByName')
	BEGIN
		DROP  Procedure  chpt03_GetPeopleByName
	END
GO

CREATE Procedure dbo.chpt03_GetPeopleByName
(
	@FirstName varchar(50),
	@LastName varchar(50)
}
AS

SELECT * FROM chpt03_Person
WHERE FirstName = @FirstName
AND LastName = @LastName

GO

GRANT EXEC ON chpt03_GetPeopleByName TO PUBLIC
GO

