#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FamilyBudget.Api/FamilyBudget.Api.csproj", "FamilyBudget.Api/"]
RUN dotnet restore "FamilyBudget.Api/FamilyBudget.Api.csproj"
COPY . .
WORKDIR "/src/FamilyBudget.Api"
RUN dotnet build "FamilyBudget.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FamilyBudget.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FamilyBudget.Api.dll"]