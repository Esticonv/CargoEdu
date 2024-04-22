#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/DeliveryCalculationService/R7P.DeliveryCalculationService.WebApi/R7P.DeliveryCalculationService.WebApi.csproj", "src/DeliveryCalculationService/R7P.DeliveryCalculationService.WebApi/"]
COPY ["src/DeliveryCalculationService/R7P.DeliveryCalculationService.Infrastructure/R7P.DeliveryCalculationService.Infrastructure.csproj", "src/DeliveryCalculationService/R7P.DeliveryCalculationService.Infrastructure/"]
COPY ["src/DeliveryCalculationService/R7P.DeliveryCalculationService.Application/R7P.DeliveryCalculationService.Application.csproj", "src/DeliveryCalculationService/R7P.DeliveryCalculationService.Application/"]
COPY ["src/DeliveryCalculationService/R7P.DeliveryCalculationService.Domain/R7P.DeliveryCalculationService.Domain.csproj", "src/DeliveryCalculationService/R7P.DeliveryCalculationService.Domain/"]
RUN dotnet restore "./src/DeliveryCalculationService/R7P.DeliveryCalculationService.WebApi/./R7P.DeliveryCalculationService.WebApi.csproj"
COPY . .
WORKDIR "/src/src/DeliveryCalculationService/R7P.DeliveryCalculationService.WebApi"
RUN dotnet build "./R7P.DeliveryCalculationService.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./R7P.DeliveryCalculationService.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "R7P.DeliveryCalculationService.WebApi.dll"]