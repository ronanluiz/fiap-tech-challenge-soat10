FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Soat10.TechChallenge/Soat10.TechChallenge.API/Soat10.TechChallenge.API.csproj", "src/Soat10.TechChallenge/Soat10.TechChallenge.API/"]
COPY ["src/Soat10.TechChallenge/Soat10.TechChallenge.Infrastructure/Soat10.TechChallenge.Infrastructure.csproj", "src/Soat10.TechChallenge/Soat10.TechChallenge.Infrastructure/"]
COPY ["src/Soat10.TechChallenge/Soat10.TechChallenge.Domain/Soat10.TechChallenge.Domain.csproj", "src/Soat10.TechChallenge/Soat10.TechChallenge.Domain/"]
COPY ["src/Soat10.TechChallenge/Soat10.TechChallenge.Application/Soat10.TechChallenge.Application.csproj", "src/Soat10.TechChallenge/Soat10.TechChallenge.Application/"]
RUN dotnet restore "src/Soat10.TechChallenge/Soat10.TechChallenge.API/Soat10.TechChallenge.API.csproj"
COPY . .
RUN dotnet publish "src/Soat10.TechChallenge/Soat10.TechChallenge.API/Soat10.TechChallenge.API.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Soat10.TechChallenge.API.dll"]