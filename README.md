# ThunderWings API

E-Shop API with product search, add/remove items from order and order placement with order receipt response.

# Quick Start

SQL DB will be created by EF migrations and product data will be seeded from aircraft.json file if Products table is empty on app start

To run the API either:

1. Run ThunderWings.Api locally with appsettings.Development.json set to use SQL Server instance specified in the connection string:
```
  "ConnectionStrings": {
    "Database": "Server=(localdb)\\mssqllocaldb;Database=ThunderWings;Trusted_Connection=True;MultipleActiveResultSets=true",
  }
```
Or

2.  Run in Docker Compose which runs containers for SQL Server and ThunderWings.Api with appsettings.Development.json set to use SQL Server instance running in Docker container:
```
  "ConnectionStrings": {
    "Database": "Server=thunder-wings-db;Database=ThunderWings;User=sa;Password=Strong_password_123!;TrustServerCertificate=True"
  }
```

Connnect to SQL Server instance running in Docker container from Sql Server Management Studio with following credentials:
Server Name: localhost,1433
Login: sa
Password: Strong_password_123

# Postman 

A postman collection for API testing has been added to SolutionItems folder in ThunderWings.sln.

