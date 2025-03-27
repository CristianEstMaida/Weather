# Etapa 1: Construir el Cliente (Blazor WebAssembly)
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-client
# WORKDIR /app/client
# COPY ["BlazorAppTest/BlazorAppTest.Client/BlazorAppTest.Client.csproj", "./"]
# RUN dotnet restore "BlazorAppTest/BlazorAppTest.Client/BlazorAppTest.Client.csproj"
# COPY ["BlazorAppTest/BlazorAppTest.Client/", "./"]
# RUN dotnet publish "BlazorAppTest/BlazorAppTest.Client/BlazorAppTest.Client.csproj" -c Release -o /publish/wwwroot

# Etapa 2: Construir el Servidor (API)
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-server
# WORKDIR /app/server
# COPY ["BlazorAppTest/BlazorAppTest/BlazorAppTest.csproj", "./"]
# RUN dotnet restore "BlazorAppTest/BlazorAppTest/BlazorAppTest.csproj"
# COPY ["BlazorAppTest/BlazorAppTest/", "./"]
# RUN dotnet publish "BlazorAppTest/BlazorAppTest.csproj" -c Release -o /publish/server

# Etapa 3: Imagen Final (Servidor con Archivos del Cliente)
# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
# WORKDIR /app
# COPY --from=build-server /app/server/publish .
# COPY --from=build-client /app/publish/wwwroot wwwroot
# ENTRYPOINT ["dotnet", "BlazorAppTest.dll"]
# EXPOSE 80

# # Etapa de construcción
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /app
# COPY ["BlazorAppTest.csproj", "./"]
# RUN dotnet restore
# COPY . .
# RUN dotnet publish -c Release -o /publish

# # Etapa final (Servidor Web)
# FROM nginx:alpine AS final
# WORKDIR /usr/share/nginx/html
# COPY --from=build /publish/wwwroot . # Asumiendo que la salida de Blazor está en wwwroot
# COPY nginx.conf /etc/nginx/conf.d/default.conf
# EXPOSE 80

# Etapa de construcción
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /app
# COPY ["BlazorAppTest/BlazorAppTest.Client/BlazorAppTest.Client.csproj", "./"]
# RUN dotnet restore "BlazorAppTest/BlazorAppTest.Client/BlazorAppTest.Client.csproj"
# COPY ["BlazorAppTest/BlazorAppTest.Client/", "./"]
# RUN dotnet publish "BlazorAppTest/BlazorAppTest.Client/BlazorAppTest.Client.csproj" -c Release -o /publish/wwwroot

# # Etapa final (Servidor Web)
# FROM nginx:alpine AS final
# WORKDIR /usr/share/nginx/html
# COPY --from=build /publish/wwwroot .
# COPY BlazorAppTest/nginx.conf /etc/nginx/conf.d/default.conf
# EXPOSE 80

# Etapa 1: Construir la aplicación Blazor WebAssembly (Cliente)
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-client
# WORKDIR /app/client
# COPY ["BlazorAppTest/BlazorAppTest.Client/BlazorAppTest.Client.csproj", "/app/client/BlazorAppTest.Client.csproj"]
# RUN dotnet restore "BlazorAppTest/BlazorAppTest.Client/BlazorAppTest.Client.csproj"
# COPY ["BlazorAppTest/BlazorAppTest.Client/", "/app/client/"]
# RUN dotnet publish "BlazorAppTest/BlazorAppTest.Client/BlazorAppTest.Client.csproj" -c Release -o /publish/wwwroot

# Imagen base para .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BlazorAppTest.csproj", "./"]
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "BlazorAppTest.dll"]
