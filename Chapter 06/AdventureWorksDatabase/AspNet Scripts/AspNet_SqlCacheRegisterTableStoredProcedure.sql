ALTER PROCEDURE [dbo].[AspNet_SqlCacheRegisterTableStoredProcedure]
             @tableName NVARCHAR(450)
         AS
         BEGIN

         DECLARE @triggerName AS NVARCHAR(3000)
         DECLARE @fullTriggerName AS NVARCHAR(3000)
         DECLARE @canonTableName NVARCHAR(3000)
         DECLARE @quotedTableName NVARCHAR(3000)
         DECLARE @schemaName NVARCHAR(3000)

         /* Detect the schema name */
         IF CHARINDEX('.', @tableName) <> 0 AND CHARINDEX('[', @tableName) = 0 OR CHARINDEX('[', @tableName) > 1
             SET @schemaName = SUBSTRING(@tableName, 1, CHARINDEX('.', @tableName) - 1)
         ELSE
             SET @schemaName = 'dbo'

         /* Create the trigger name */
         IF @schemaName <> 'dbo'
             SET @triggerName = SUBSTRING(@tableName,
                 CHARINDEX('.', @tableName) + 1, LEN(@tableName) - CHARINDEX('.', @tableName))
         ELSE
             SET @triggerName = @tableName
         SET @triggerName = REPLACE(@triggerName, '[', '__o__')
         SET @triggerName = REPLACE(@triggerName, ']', '__c__')
         SET @triggerName = @triggerName + '_AspNet_SqlCacheNotification_Trigger'
         SET @fullTriggerName = @schemaName + '.[' + @triggerName + ']'

         /* Create the cannonicalized table name for trigger creation */
         /* Do not touch it if the name contains other delimiters */
         IF (CHARINDEX('.', @tableName) <> 0 OR
             CHARINDEX('[', @tableName) <> 0 OR
             CHARINDEX(']', @tableName) <> 0)
             SET @canonTableName = @tableName
         ELSE
             SET @canonTableName = '[' + @tableName + ']'

         /* First make sure the table exists */
         IF (SELECT OBJECT_ID(@tableName, 'U')) IS NULL
         BEGIN
             RAISERROR ('00000001', 16, 1)
             RETURN
         END

         BEGIN TRAN
         /* Insert the value into the notification table */
         IF NOT EXISTS (SELECT tableName FROM dbo.AspNet_SqlCacheTablesForChangeNotification WITH (NOLOCK) WHERE tableName = @tableName)
             IF NOT EXISTS (SELECT tableName FROM dbo.AspNet_SqlCacheTablesForChangeNotification WITH (TABLOCKX) WHERE tableName = @tableName)
                 INSERT dbo.AspNet_SqlCacheTablesForChangeNotification
                 VALUES (@tableName, GETDATE(), 0)

         /* Create the trigger */
         SET @quotedTableName = QUOTENAME(@tableName, '''')
         IF NOT EXISTS (SELECT name FROM sysobjects WITH (NOLOCK) WHERE name = @triggerName AND type = 'TR')
             IF NOT EXISTS (SELECT name FROM sysobjects WITH (TABLOCKX) WHERE name = @triggerName AND type = 'TR')
                 EXEC('CREATE TRIGGER ' + @fullTriggerName + ' ON ' + @canonTableName +'
                       FOR INSERT, UPDATE, DELETE AS BEGIN
                       SET NOCOUNT ON
                       EXEC dbo.AspNet_SqlCacheUpdateChangeIdStoredProcedure N' + @quotedTableName + '
                       END
                       ')
         COMMIT TRAN
         END
 