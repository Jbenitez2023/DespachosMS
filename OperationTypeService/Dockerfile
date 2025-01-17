FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["OperationTypeService.csproj","OperationTypeService/"]
RUN dotnet restore "OperationTypeService/OperationTypeService.csproj"

COPY . ./OperationTypeService
WORKDIR "/src/OperationTypeService"
RUN dotnet build "OperationTypeService.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OperationTypeService.csproj" -c %BUILD_CONFIGURATION% -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","OperationTypeService.dll"]