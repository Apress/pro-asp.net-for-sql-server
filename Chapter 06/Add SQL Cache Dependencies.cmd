@echo off

set REGSQL="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_regsql.exe"
set OSQL="C:\Program Files\Microsoft SQL Server\90\Tools\Binn\osql.exe"
set SCRIPTS_DIR="AdventureWorksDatabase\AspNet Scripts"
set UPDATE_SCRIPT=AspNet_SqlCacheRegisterTableStoredProcedure.sql
set DATABASE=AdventureWorks
set DSN="Data Source=.\SQLEXPRESS;Initial Catalog=%DATABASE%;Integrated Security=True"

echo Registering dependencies
%REGSQL% -C %DSN% -ed

echo Updating AspNet Stored Procedure for Schema Support
%OSQL% -S .\SQLEXPRESS -E -d %DATABASE% -i %SCRIPTS_DIR%\%UPDATE_SCRIPT%

echo Registering Production.Product table
%REGSQL% -C %DSN% -et -t Production.Product

pause
