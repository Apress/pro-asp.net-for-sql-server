IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt04_DeletePerson')
	BEGIN
		DROP  Procedure  chpt04_DeletePerson
	END

GO

CREATE Procedure dbo.chpt04_DeletePerson
(
	@Original_PersonId bigint,
	@Original_FirstName varchar(50),
	@Original_LastName varchar(50),
	@Original_BirthDate datetime,
	@Original_City [varchar](50),
	@Original_Country [varchar](50)
)
AS

SET NOCOUNT OFF;

DELETE FROM chpt04_Person WHERE PersonId = @Original_PersonId

GO

GRANT EXEC ON chpt04_DeletePerson TO PUBLIC
GO
