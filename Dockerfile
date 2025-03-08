# Usa la imagen oficial de .NET SDK para compilar y publicar la API
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar la solución y los archivos de proyectos
COPY BancoAPI.sln .  
COPY BancoAPI.Api/*.csproj ./BancoAPI.Api/
COPY BancoAPI.Application/*.csproj ./BancoAPI.Application/
COPY BancoAPI.Domain/*.csproj ./BancoAPI.Domain/
COPY BancoAPI.Infrastructure/*.csproj ./BancoAPI.Infrastructure/

# Restaurar dependencias
RUN dotnet restore BancoAPI.sln

# Copiar el resto del código y compilar
COPY . .
WORKDIR /app/BancoAPI.Api
RUN dotnet publish -c Release -o /out

# Imagen más liviana para ejecutar la API
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /out .
EXPOSE 5000
CMD ["dotnet", "BancoAPI.Api.dll"]
