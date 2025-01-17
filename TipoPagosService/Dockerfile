FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["TipoPagosService.csproj","TipoPagosService/"]
RUN dotnet restore "TipoPagosService/TipoPagosService.csproj"

COPY . ./TipoPagosService
WORKDIR "/src/TipoPagosService"
RUN dotnet build "TipoPagosService.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build as publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TipoPagosService.csproj"  -c %BUILD_CONFIGURATION% -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","TipoPagosService.dll"]


