# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AccountingconceptService.csproj", "AccountingconceptService/"]
RUN dotnet restore "AccountingconceptService/AccountingconceptService.csproj"

COPY . ./AccountingconceptService
WORKDIR "/src/AccountingconceptService"
RUN dotnet build "AccountingconceptService.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AccountingconceptService.csproj" -c %BUILD_CONFIGURATION% -o /app/publish 

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccountingconceptService.dll"]