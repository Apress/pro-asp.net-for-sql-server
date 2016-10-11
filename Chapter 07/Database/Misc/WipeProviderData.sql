--
-- WipeProviderData.sql
-- Wipes data from the provider services table so the services can be removed (and added back fresh)
-- SELECT name FROM sysobjects WHERE type = 'U' and name like 'aspnet_%'
--

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'aspnet_WebEvent_Events')
	BEGIN
		delete from dbo.aspnet_WebEvent_Events
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'aspnet_PersonalizationAllUsers')
	BEGIN
		delete from dbo.aspnet_PersonalizationAllUsers
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'aspnet_PersonalizationPerUser')
	BEGIN
		delete from dbo.aspnet_PersonalizationPerUser
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'aspnet_Membership')
	BEGIN
		delete from dbo.aspnet_Membership
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'aspnet_Profile')
	BEGIN
		delete from dbo.aspnet_Profile
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'aspnet_UsersInRoles')
	BEGIN
		delete from dbo.aspnet_UsersInRoles
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'aspnet_Users')
	BEGIN
		delete from dbo.aspnet_Users
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'aspnet_Roles')
	BEGIN
		delete from dbo.aspnet_Roles
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'aspnet_Paths')
	BEGIN
		delete from dbo.aspnet_Paths
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'aspnet_Applications')
	BEGIN
		delete from dbo.aspnet_Applications
	END
GO
