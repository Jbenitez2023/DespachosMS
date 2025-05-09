FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Common.Interfaces.csproj", "Common.Interfaces/"]
RUN dotnet restore "/Common.Interfaces/Common.Interfaces.csproj"

COPY . ./Common.Interfaces
WORKDIR "/src/Common.Interfaces"
RUN dotnet build "Common.Interfaces.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Common.Interfaces.csproj" -c %BUILD_CONFIGURATION% -o /app/publish

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Common.Interfaces.dll"]