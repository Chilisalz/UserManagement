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

## Deployment
   - Service is deployed to https://chili-user-management-service.herokuapp.com/
   - Swagger can be found under https://chili-user-management-service.herokuapp.com/swagger

# Authentication
## Register a new User
### Request
`POST /api/Authentication/Register`

      curl -X POST "https://chili-user-management-service.herokuapp.com/api/Authentication/Register" -H  "accept: */*" -H  "Content-Type: application/json" -d "     {\"userName\":\"Test12345\",\"password\":\"49py72YX!?!?!\",\"email\":\"user@example.com\",\"secretQuestion\":\"f3124fb0-79ce-403b-8cd4-eceafaf2a0ff\",\"secretAnswer\":\"Pizza\"}"
      
### Response
      {
        "status": "success",
        "data": {
          "id": "eb53e650-f202-4166-bae2-cfe02fb86056",
          "userName": "Test12345",
          "email": "user@example.com",
          "registrationDate": "2021-12-14T11:16:02.132037+00:00",
          "chiliUserRoleId": "372a7671-ab69-4450-b77f-306aeb4eb8f1",
          "secretQuestionId": "f3124fb0-79ce-403b-8cd4-eceafaf2a0ff"
        },
        "error": null
      }
      
## Login as User
### Request
`POST /api/Authentication/Login`

      curl -X POST "https://chili-user-management-service.herokuapp.com/api/Authentication/Login" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"userName\":\"Test12345\",\"password\":\"49py72YX!?!?!\"}"
      
### Response      
      {
        "status": "success",
        "data": {
          "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJUZXN0MTIzNDUiLCJqdGkiOiI5MDI1ZDI0Yi0zNDJiLTRjOTMtODJiYS00ZDRiNjBjNjBlYzkiLCJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJpZCI6ImViNTNlNjUwLWYyMDItNDE2Ni1iYWUyLWNmZTAyZmI4NjA1NiIsIm5iZiI6MTYzOTQ4MDY2MCwiZXhwIjoxNjM5NDgxNTYwLCJpYXQiOjE2Mzk0ODA2NjB9.IPA4FG9luWYP6eqPR1XwMp3zoNJleQZP1O57f4_QE70",
          "refreshToken": "df16d56f-c84a-4c15-8b09-a0822e2c177f"
        },
        "error": null
      }
      
## Refresh Authenticationtoken
### Request
`POST /api/Authentication/Token/Refresh`

      curl -X POST "https://chili-user-management-service.herokuapp.com/api/Authentication/Token/Refresh" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"token\":\"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJUZXN0MTIzNDUiLCJqdGkiOiI5MDI1ZDI0Yi0zNDJiLTRjOTMtODJiYS00ZDRiNjBjNjBlYzkiLCJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJpZCI6ImViNTNlNjUwLWYyMDItNDE2Ni1iYWUyLWNmZTAyZmI4NjA1NiIsIm5iZiI6MTYzOTQ4MDY2MCwiZXhwIjoxNjM5NDgxNTYwLCJpYXQiOjE2Mzk0ODA2NjB9.IPA4FG9luWYP6eqPR1XwMp3zoNJleQZP1O57f4_QE70\",\"refreshToken\":\"df16d56f-c84a-4c15-8b09-a0822e2c177f\"}"
      
### Response
      {
        "status": "error",
        "data": null,
        "error": "This token hasn't expired yet"
      }
      
## Verify Authenticationtoken
### Request
`POST /api/Authentication/Token/Verify`

      curl -X POST "https://chili-user-management-service.herokuapp.com/api/Authentication/Token/Verify" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"token\":\"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJUZXN0MTIzNDUiLCJqdGkiOiI5MDI1ZDI0Yi0zNDJiLTRjOTMtODJiYS00ZDRiNjBjNjBlYzkiLCJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJpZCI6ImViNTNlNjUwLWYyMDItNDE2Ni1iYWUyLWNmZTAyZmI4NjA1NiIsIm5iZiI6MTYzOTQ4MDY2MCwiZXhwIjoxNjM5NDgxNTYwLCJpYXQiOjE2Mzk0ODA2NjB9.IPA4FG9luWYP6eqPR1XwMp3zoNJleQZP1O57f4_QE70\"}"
      
### Response
      {
        "status": "success",
        "data": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJUZXN0MTIzNDUiLCJqdGkiOiI5MDI1ZDI0Yi0zNDJiLTRjOTMtODJiYS00ZDRiNjBjNjBlYzkiLCJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJpZCI6ImViNTNlNjUwLWYyMDItNDE2Ni1iYWUyLWNmZTAyZmI4NjA1NiIsIm5iZiI6MTYzOTQ4MDY2MCwiZXhwIjoxNjM5NDgxNTYwLCJpYXQiOjE2Mzk0ODA2NjB9.IPA4FG9luWYP6eqPR1XwMp3zoNJleQZP1O57f4_QE70",
        "error": null
      }
   
# User
## Get user by userid
### Request
`GET /api/ChiliUser/{userId}`

      curl -X GET "https://chili-user-management-service.herokuapp.com/api/ChiliUser/0da09c36-50ac-44fb-a102-8b528bcbad51" -H  "accept: */*"
      
### Response
      {
        "status": "success",
        "data": {
          "id": "0da09c36-50ac-44fb-a102-8b528bcbad51",
          "userName": "admin",
          "email": "adminuser@chiliboard.de",
          "registrationDate": "2021-11-30T08:46:16.484351",
          "chiliUserRoleId": "39bf46f0-cc42-438f-866c-c20c393a307b",
          "secretQuestionId": "f7f78ebd-22d5-4861-893e-7dceee4ee4fe"
        },
        "error": null
      }
      
## Change user information
### Request
`PUT /api/ChiliUser/{userId}`

      curl -X PUT "https://chili-user-management-service.herokuapp.com/api/ChiliUser/0da09c36-50ac-44fb-a102-8b528bcbad51" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"userName\":\"superadmin\"}"

### Response
      {
        "status": "success",
        "data": {
          "id": "0da09c36-50ac-44fb-a102-8b528bcbad51",
          "userName": "superadmin",
          "email": "adminuser@chiliboard.de",
          "registrationDate": "0001-01-01T00:00:00",
          "chiliUserRoleId": "39bf46f0-cc42-438f-866c-c20c393a307b",
          "secretQuestionId": "f7f78ebd-22d5-4861-893e-7dceee4ee4fe"
        },
        "error": null
      }
      
## Get list of all users
### Request
`GET /api/ChiliUser`

      curl -X GET "https://chili-user-management-service.herokuapp.com/api/ChiliUser" -H  "accept: */*"
      
### Response
      {
        "status": "success",
        "data": [
          {
            "id": "0da09c36-50ac-44fb-a102-8b528bcbad51",
            "userName": "admin",
            "email": "adminuser@chiliboard.de",
            "registrationDate": "2021-11-30T08:46:16.484351",
            "chiliUserRoleId": "39bf46f0-cc42-438f-866c-c20c393a307b",
            "secretQuestionId": "f7f78ebd-22d5-4861-893e-7dceee4ee4fe"
          },
          {
            "id": "8c8dd0dd-a6b6-478d-a298-1011cb5bf060",
            "userName": "CatLover123",
            "email": "catlover@gmail.com",
            "registrationDate": "2021-11-30T08:46:16.487067",
            "chiliUserRoleId": "372a7671-ab69-4450-b77f-306aeb4eb8f1",
            "secretQuestionId": "f3124fb0-79ce-403b-8cd4-eceafaf2a0ff"
          },
          {
            "id": "bf9657c5-0827-44bb-b902-f627d24c0313",
            "userName": "CasualUser69420",
            "email": "casualUser@web.de",
            "registrationDate": "2021-11-30T08:46:16.487063",
            "chiliUserRoleId": "372a7671-ab69-4450-b77f-306aeb4eb8f1",
            "secretQuestionId": "5e1e640d-17cc-4d36-8e50-81deaeb6b215"
          },
          {
            "id": "eb53e650-f202-4166-bae2-cfe02fb86056",
            "userName": "Test12345",
            "email": "user@example.com",
            "registrationDate": "2021-12-14T11:16:02.132037",
            "chiliUserRoleId": "372a7671-ab69-4450-b77f-306aeb4eb8f1",
            "secretQuestionId": "f3124fb0-79ce-403b-8cd4-eceafaf2a0ff"
          }
        ],
        "error": null
      }
      
## Delete a user
### Request
`DELETE /api/ChiliUser/{userId}`

      curl -X DELETE "https://chili-user-management-service.herokuapp.com/api/ChiliUser/eb53e650-f202-4166-bae2-cfe02fb86056" -H  "accept: */*"
      
### Response
      {
        "status": "success",
        "data": "eb53e650-f202-4166-bae2-cfe02fb86056",
        "error": null
      }
      
## Change a users password
### Request

`PUT /api/ChiliUser/{userId}/ChangePassword`

      curl -X PUT "https://chili-user-management-service.herokuapp.com/api/ChiliUser/0da09c36-50ac-44fb-a102-8b528bcbad51/ChangePassword" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"oldPassword\":\"admin\",\"newPassword\":\"admin123!A123\"}"
      
### Response
      {
        "status": "success",
        "data": "0da09c36-50ac-44fb-a102-8b528bcbad51",
        "error": null
      }
      
## Get all available secret questions      
### Request
`GET /api/ChiliUser/SecretQuestion`
      
      curl -X GET "https://chili-user-management-service.herokuapp.com/api/ChiliUser/Secretquestion" -H  "accept: */*"
      
### Response
      {
        "status": "success",
        "data": [
          {
            "id": "f3124fb0-79ce-403b-8cd4-eceafaf2a0ff",
            "question": "Was ist Ihr Lieblingsessen?"
          },
          {
            "id": "5e1e640d-17cc-4d36-8e50-81deaeb6b215",
            "question": "Wie lautet der Geburtsname Ihrer Mutter?"
          },
          {
            "id": "f7f78ebd-22d5-4861-893e-7dceee4ee4fe",
            "question": "Wie lautet Ihre Lieblingsprimzahl?"
          }
        ],
        "error": null
      }
      
## Validate a users SecretAnswer
### Request
`POST /api/ChiliUser/ValidateSecretAnswer`

      curl -X POST "https://chili-user-management-service.herokuapp.com/api/ChiliUser/ValidateSecretAnswer" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"userId\":\"8c8dd0dd-a6b6-478d-a298-1011cb5bf060\",\"secretAnswer\":\"Katzen\"}"
      
### Response
      {
        "status": "success",
        "data": "8c8dd0dd-a6b6-478d-a298-1011cb5bf060",
        "error": null
      }
      
## Get a users secretquestion by his email
### Request
`GET /api/ChiliUser/{email}/Secretquestion`

      curl -X GET "https://chili-user-management-service.herokuapp.com/api/ChiliUser/adminuser%40chiliboard.de/Secretquestion" -H  "accept: */*"
      
### Response
      {
        "status": "success",
        "data": {
          "id": "f7f78ebd-22d5-4861-893e-7dceee4ee4fe",
          "question": "Wie lautet Ihre Lieblingsprimzahl?"
        },
        "error": null
      }
