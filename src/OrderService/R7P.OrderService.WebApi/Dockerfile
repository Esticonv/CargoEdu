#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/OrderService/R7P.OrderService.WebApi/R7P.OrderService.WebApi.csproj", "src/OrderService/R7P.OrderService.WebApi/"]
COPY ["src/OrderService/R7P.OrderService.Infrastructure/R7P.OrderService.Infrastructure.csproj", "src/OrderService/R7P.OrderService.Infrastructure/"]
COPY ["src/Core/R7P.Domain.Core/R7P.Domain.Core.csproj", "src/Core/R7P.Domain.Core/"]
COPY ["src/OrderService/R7P.OrderService.Application/R7P.OrderService.Application.csproj", "src/OrderService/R7P.OrderService.Application/"]
COPY ["src/OrderService/R7P.OrderService.Domain/R7P.OrderService.Domain.csproj", "src/OrderService/R7P.OrderService.Domain/"]
RUN dotnet restore "./src/OrderService/R7P.OrderService.WebApi/./R7P.OrderService.WebApi.csproj"
COPY . .
WORKDIR "/src/src/OrderService/R7P.OrderService.WebApi"
RUN dotnet build "./R7P.OrderService.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./R7P.OrderService.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "R7P.OrderService.WebApi.dll"]