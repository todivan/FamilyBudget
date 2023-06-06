# Family Budget
Demo for Family Budget 

RUN application

After clone open solution file with Visual Studio 2022

Build solution

Migration is still not autmated from API so in the beggingin should be done manually:
 - In FamilyBudget.api/appsettings.json uncomment connection string
 - Run: dotnet ef database update
 - Comment out again connection string in FamilyBudget.api/appsettings.json
 
 
 Build frontened
 - go in folder FamilyBudget.Appp
 - docker buildx build -t familybudget-app:latest .

