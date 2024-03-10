FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/R7P.DeliveryCalculationService.WebApi/R7P.DeliveryCalculationService.WebApi.csproj", "R7P.DeliveryCalculationService.WebApi/"]
RUN dotnet restore "src/R7P.DeliveryCalculationService.WebApi/R7P.DeliveryCalculationService.WebApi.csproj"
COPY . .
WORKDIR "/src/R7P.DeliveryCalculationService.WebApi"
RUN dotnet build "R7P.DeliveryCalculationService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "R7P.DeliveryCalculationService.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "R7P.DeliveryCalculationService.WebApi.dll"]
