# chili-user-management-service
Zuständig für alle Aufgaben rund um einen Benutzer bzw. Anwender im Chili-Imageboard.

## Installation guide for local development
1. Clone this repository
2. Start mysql-Server (XAMPP)
3. Go to appsettings.json and adjust the connectionstring (if needed)
4. Run `Get-Help about_EntityFrameworkCore` in `PackageManagerConsole` to check if Entity Framework Core Tools are installed
   - if not installed run `Install-Package Microsoft.EntityFrameworkCore.Tools` and `Update-Package Microsoft.EntityFrameworkCore.Tools`
5. Run `Update-Database` in PackageManagerConsole
6. Run project
