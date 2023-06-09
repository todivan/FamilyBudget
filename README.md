# Family Budget
Demo for Family Budget

**Solution technologies**

.NET Core 6
Angular 16
Postgres DB
Docker

**Requirements for windows run**:
Visual Studio 2022
Docker desktop Installed 
.NET Core 6 Installed
Angular 16

**RUN application **

After clone open solution file with Visual Studio 2022

Set docker-compose as startup project Build solution Open terminal in folder "FamilyBudget.Appp" and run command "docker buildx build -t familybudget-app:latest ." Start solution form visual studio DB and API container should be created and running at this time

Migration is still not automated from API so in the beginning should be done manually:

While DB container is running
Go to folder FamilyBudget.Api
Run: "dotnet ef database update"
Run application form visual studio

Frontend should be avaialble on http://localhost:4200/ Backend API Swagger should be available on https://localhost:33688/swagger/index.html

Register user Login with registered user At this stage fronted has only simple crating and listing of models, later should be added desired flow and implemented FE business logic

Backend is fully ready tested and functional form swagger: 

**Using of API for business logic:**

- register user
- login over user
- create budget
  - list all users and present during budget creation for potential share
  - store new budget
  - sore budget share
- create transaction related to budget, with specific type and category

**Further tasks**
Automate migration from API
Provide helpful API endpoint that will group action in order to simplify using from front-end
Provide exception handling
Implement front-end logic based on above description
Design improvement
