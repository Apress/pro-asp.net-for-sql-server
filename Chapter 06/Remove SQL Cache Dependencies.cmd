@echo off

set REGSQL="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_regsql.exe"
set DATABASE=AdventureWorks
set DSN="Data Source=.\SQLEXPRESS;Initial Catalog=%DATABASE%;Integrated Security=True"

%REGSQL% -C %DSN% -dd

pause
