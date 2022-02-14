# OnlineBanking

This API is developed with ASP.NET Core 3.1 Web API. MSSQL is used for database. For consistency, EF Core concurrency token is used. JWT is used for secure endpoints.
AutoHistory is used to log all changes in entities. Docker is used for containerization. Swagger is used for Open API specification. 

Swagger : https://localhost:5001/swagger/index.html


To dockerize mssql server :

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password11!" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest

when the app is up, tables will be generated using migrations.

Postman requests attached to email.
