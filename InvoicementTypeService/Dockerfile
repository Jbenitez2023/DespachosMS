FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["InvoicementTypeService.csproj", "InvoicementTypeService/"]
RUN dotnet restore "InvoicementTypeService/InvoicementTypeService.csproj"

COPY . ./InvoicementTypeService
WORKDIR "/src/InvoicementTypeService"
RUN dotnet build "InvoicementTypeService.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "InvoicementTypeService.csproj" -c %BUILD_CONFIGURATION% -o /app/publish

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InvoicementTypeService.dll"]