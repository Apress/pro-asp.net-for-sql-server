IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt03_SaveLocation')
	BEGIN
		DROP  Procedure  chpt03_SaveLocation
	END

GO

CREATE Procedure dbo.chpt03_SaveLocation
(
	@City [varchar](50),
	@Country [varchar](50),
	@LocationId bigint OUTPUT
)
AS

IF NOT EXISTS (
	SELECT * FROM chpt03_Location
	WHERE City = @City and Country = @Country
)
BEGIN
  -- INSERT
  PRINT 'Inserting Location'
  INSERT into chpt03_Location
  (City,Country)
  values (@City, @Country)
  
  SET @LocationId = @@IDENTITY
END
ELSE
BEGIN
	-- get LocationId
	PRINT 'Location Exists'
	SET @LocationId = (
		SELECT LocationId FROM chpt03_Location
		WHERE City = @City and Country = @Country
	)
END

GO

GRANT EXEC ON chpt03_SaveLocation TO PUBLIC
GO
