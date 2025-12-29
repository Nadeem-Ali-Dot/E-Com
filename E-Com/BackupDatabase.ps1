# BackupDatabase.ps1
$serverName = "DESKTOP-0PFOLEB\\SQLEXPRESS"
$databaseName = "EComDb"
$backupFolder = "D:\Nadeem Ali\E-Com"

# Ensure folder exists
if (!(Test-Path -Path $backupFolder)) {
    New-Item -ItemType Directory -Path $backupFolder | Out-Null
}

# Generate timestamped backup file
$timestamp = Get-Date -Format "yyyy_MM_dd_HH_mm_ss"
$backupFile = Join-Path $backupFolder "$databaseName`_$timestamp.bak"

# Run SQL Server backup
$sql = "BACKUP DATABASE [$databaseName] TO DISK = N'$backupFile' WITH INIT, STATS = 10"
sqlcmd -S $serverName -Q $sql

Write-Host "Backup completed: $backupFile"
