FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY src/Endpoints/Endpoints.csproj Endpoints/
COPY src/Application/Application.csproj Application/
COPY src/Infrastructure/Infrastructure.csproj Infrastructure/
COPY src/Contracts/Contracts.csproj Contracts/
COPY src/Domain/Domain.csproj Domain/
RUN dotnet restore Endpoints/Endpoints.csproj

# Copy everything else and build
COPY src/. .
WORKDIR /app/Endpoints
RUN dotnet publish -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Endpoints.dll"]
EXPOSE 8080