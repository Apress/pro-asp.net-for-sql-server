@echo off

set REGSQL="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_regsql.exe"
set DSN="Data Source=.\SQLEXPRESS;Initial Catalog=Chapter01;Integrated Security=True"

%REGSQL% -C %DSN% -R mrpc

pause
