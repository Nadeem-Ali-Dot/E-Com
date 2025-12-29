@echo off
REM ===============================
REM BackupDatabase.bat
REM ===============================

REM --- Configuration ---
SET SERVER=DESKTOP-0PFOLEB\\SQLEXPRESS
SET DATABASE=EComDb
SET BACKUPFOLDER=D:\Nadeem Ali\E-Com

REM --- Create backup folder if it doesn't exist ---
IF NOT EXIST "%BACKUPFOLDER%" (
    mkdir "%BACKUPFOLDER%"
)

REM --- Generate timestamp ---
FOR /F "tokens=1-5 delims=/-: " %%d IN ('echo %date% %time%') DO (
    SET TIMESTAMP=%%d_%%e_%%f_%%g_%%h_%%i
)

SET BACKUPFILE=%BACKUPFOLDER%\%DATABASE%_%TIMESTAMP%.bak

REM --- Run SQL Server backup ---
echo Backing up database %DATABASE% to %BACKUPFILE%
sqlcmd -S %SERVER% -Q "BACKUP DATABASE [%DATABASE%] TO DISK=N'%BACKUPFILE%' WITH INIT, STATS=10"

echo Backup completed!
pause
