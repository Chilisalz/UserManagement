# chili-user-management-service
Zuständig für alle Aufgaben rund um einen Benutzer bzw. Anwender im Chili-Imageboard.

## Installation guide for local development
1. Clone this repository
2. Build project
3. Start PostGres-Server
4. Run project 

## Troubleshooting
1. Check the connectionstring (appsettings.json => PG-Server password)
2. Check if EntityFrameworkCore.Tools is installed by typing `Get-Help about_EntityFrameworkCore`
   - if not installed run `Install-Package Microsoft.EntityFrameworkCore.Tools` and `Update-Package Microsoft.EntityFrameworkCore.Tools`

## Testing Hint
After setup there will be the following dataseeds
### Roles
#### Admin
- ID: 39bf46f0-cc42-438f-866c-c20c393a307b
- Name: Admin
#### DefaultChiliUser
- ID: 372a7671-ab69-4450-b77f-306aeb4eb8f1
- Name: DefaultChiliUser
### Users
#### ChiliSuperAdmin - Admin
- ID: 0da09c36-50ac-44fb-a102-8b528bcbad51
- Username: ChiliSuperAdmin
- Email: adminuser@chiliboard.de
- Password: admin
#### CasualUser69420
- ID: bf9657c5-0827-44bb-b902-f627d24c0313
- Username: CasualUser69420
- Email: casualUser@web.de
- Password: casual
#### CatLover123 - DefaultChiliUser
- ID: 8c8dd0dd-a6b6-478d-a298-1011cb5bf060
- Username: CatLover123
- Email: catlover@gmail.com
- Password: cats
