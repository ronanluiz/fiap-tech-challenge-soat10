FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet restore src/Soat10.TechChallenge/Soat10.TechChallenge.API/Soat10.TechChallenge.API.csproj
COPY . .
RUN dotnet publish src/Soat10.TechChallenge/Soat10.TechChallenge.API/Soat10.TechChallenge.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Soat10.TechChallenge.API.dll"]