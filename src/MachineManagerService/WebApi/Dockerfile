#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/MachineManagerService/Domain/Domain.Entities/R7P.MachineManagerService.Domain.Entities.csproj", "src/MachineManagerService/Domain/Domain.Entities/"]
COPY ["src/MachineManagerService/Infrastructure/Infrastructure.EntityFramework/R7P.MachineManagerService.Infrastructure.EntityFramework.csproj", "src/MachineManagerService/Infrastructure/Infrastructure.EntityFramework/"]
COPY ["src/MachineManagerService/Application/Application.Application/R7P.MachineManagerService.Application.csproj", "src/MachineManagerService/Application/Application.Application/"]
COPY ["src/MachineManagerService/WebApi/R7P.MachineManagerService.WebApi.csproj", "src/MachineManagerService/WebApi/"]

RUN dotnet restore "./src/MachineManagerService/WebApi/R7P.MachineManagerService.WebApi.csproj"
COPY . .
WORKDIR "/src/src/MachineManagerService/R7P.MachineManagerService.WebApi"
RUN dotnet build "./R7P.MachineManagerService.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./R7P.MachineManagerService.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "R7P.MachineManagerService.WebApi.dll"]