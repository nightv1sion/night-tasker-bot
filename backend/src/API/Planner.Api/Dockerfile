#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["API/Planner.Api/Planner.Api.csproj", "API/Planner.Api/"]
COPY ["Modules/Challenges/Planner.Challenges.Presentation/Planner.Challenges.Presentation.csproj", "Modules/Challenges/Planner.Challenges.Presentation/"]
COPY ["Modules/Challenges/Planner.Challenges.Infrastructure/Planner.Challenges.Infrastructure.csproj", "Modules/Challenges/Planner.Challenges.Infrastructure/"]
COPY ["Common/Planner.Common.Infrastructure/Planner.Common.Infrastructure.csproj", "Common/Planner.Common.Infrastructure/"]
COPY ["Common/Planner.Common.Application/Planner.Common.Application.csproj", "Common/Planner.Common.Application/"]
COPY ["Common/Planner.Common.Domain/Planner.Common.Domain.csproj", "Common/Planner.Common.Domain/"]
COPY ["Modules/Challenges/Planner.Challenges.Application/Planner.Challenges.Application.csproj", "Modules/Challenges/Planner.Challenges.Application/"]
COPY ["Modules/Challenges/Planner.Challenges.Domain/Planner.Challenges.Domain.csproj", "Modules/Challenges/Planner.Challenges.Domain/"]
RUN dotnet restore "./API/Planner.Api/Planner.Api.csproj"
COPY . .
WORKDIR "/src/API/Planner.Api"
RUN dotnet build "./Planner.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Planner.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Planner.Api.dll"]