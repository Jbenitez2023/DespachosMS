FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["ProfileService.csproj", "ProfileService/"]
RUN dotnet restore "ProfileService/ProfileService.csproj"
COPY . ./ProfileService


WORKDIR "/src/ProfileService"
RUN dotnet build "ProfileService.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ProfileService.csproj" -c %BUILD_CONFIGURATION% -o /app/publish

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProfileService.dll"]