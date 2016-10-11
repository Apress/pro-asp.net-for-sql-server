@echo off

set REGSQL="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_regsql.exe"
rem set DSN="Data Source=.\SQLEXPRESS;Initial Catalog=Chapter05;Integrated Security=True"
set DSN="Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks;Integrated Security=True"

%REGSQL% -C %DSN% -A all

pause
