# Imagen base para .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BlazorAppTest/BlazorAppTest/BlazorAppTest.csproj", "./"]
RUN dotnet restore
COPY ["BlazorAppTest/BlazorAppTest/", "./"]
RUN dotnet publish -c Release -o /app

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "BlazorAppTest.dll"]
