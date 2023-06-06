# Family Budget
Demo for Family Budget

RUN application

Requirements for windows run:
Visual Studio 2022
Docker desktop
Installed .NET Core 6
Installed Angular 16


After clone open solution file with Visual Studio 2022

Set docker-compose as startup project
Build solution
DB and API container should be created and running at this time
Frontend angular container is temporarily disabled in compose due to some connection issues

Migration is still not automated from API so in the beginning should be done manually:
 - Go to folder FamilyBudget.Api
 - Run: "dotnet ef database update"
 
 Run application form visual studio
 
 Check API port from browser and set for apiUrl in FamilyBudget.Appp\src\environments\* file depend on development or production
 (This part is still not automated due to previously mentioned issue)
 
 Go to folder FamilyBudget.Appp and run frontend with commands:
 "npm install"
 "ng serve -o"
 
 Register user
 Login with registered user
 At this stage fronted only has listing of models, later should be added desired flow and implemented FE business logic
 
  Backend is fully ready tested and functional form swagger:
 Using of API for business logic:
 - register user
 - login over user
 - create budget
  - list all users and present during budget creation for potential share
  - store new budget
  - sore budget share
 - create transaction related to budget, with specific type and category


# Further tasks
- Automate migration from API
- Provide helpful API endpoint that will group action in order to simplify using from front-end
- Provide exception handling
- Provide interceptor
- Implement front-end login based on above description
- Solve issue with frontend container deployment
- Design improvement
