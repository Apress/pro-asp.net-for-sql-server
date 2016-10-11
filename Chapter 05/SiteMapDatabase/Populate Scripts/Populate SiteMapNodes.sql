
SET NOCOUNT ON

DECLARE @RootNodeID bigint
DECLARE @AlbumsNodeID bigint

-- reset the table
--TRUNCATE TABLE sm_SiteMapNodes
--DBCC CHECKIDENT (sm_SiteMapNodes, RESEED, 0)
DELETE FROM sm_SiteMapNodes

EXEC sm_InsertSiteMapNode -1, 'Default.aspx', 'Home', 0, @RootNodeID OUTPUT
EXEC sm_InsertSiteMapNode @RootNodeID, 'Albums/Default.aspx', 'Albums', 1, @AlbumsNodeID OUTPUT

DECLARE @Albums TABLE
(
	ID int IDENTITY,
	AlbumID bigint,
	[Name] varchar(50),
	UserName nvarchar(256)
)

INSERT INTO @Albums (AlbumID, [Name], UserName)
SELECT ID, [Name], UserName
FROM pap_Albums 
WHERE IsActive = 1

DECLARE @CurID int
DECLARE @MaxID int
DECLARE @AlbumID bigint
DECLARE @AlbumNodeID bigint
DECLARE @Name varchar(50)
DECLARE @UserName nvarchar(256)
DECLARE @Url nvarchar(150)

SET @MaxID = ( SELECT MAX(ID) FROM @Albums )
SET @CurID = 1

WHILE (@CurID <= @MaxID)
BEGIN
	SET @AlbumID = ( SELECT AlbumID FROM @Albums WHERE ID = @CurID )
	SET @Name = ( SELECT Name FROM @Albums WHERE ID = @CurID )
	SET @UserName = ( SELECT UserName FROM @Albums WHERE ID = @CurID )

	SET @Url = ( 'Albums/Album.aspx?AlbumID=' + 
		CONVERT(varchar(10), @AlbumID) +
		'&UserName=' + @UserName )

--	PRINT 'Name = ' + @Name
--	PRINT 'UserName = ' + @UserName
--	PRINT 'Url = ' + @Url

	EXEC sm_InsertSiteMapNode @AlbumsNodeID, @Url, @Name, 2, @AlbumNodeID OUTPUT

	SET @CurID = @CurID + 1
END

SET NOCOUNT OFF
