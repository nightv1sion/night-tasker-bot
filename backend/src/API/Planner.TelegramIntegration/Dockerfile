FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["API/Planner.TelegramIntegration/Planner.TelegramIntegration.csproj", "API/Planner.TelegramIntegration/"]
RUN dotnet restore "API/Planner.TelegramIntegration/Planner.TelegramIntegration.csproj"
COPY . .
WORKDIR "/src/API/Planner.TelegramIntegration"
RUN dotnet build "Planner.TelegramIntegration.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Planner.TelegramIntegration.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Planner.TelegramIntegration.dll"]
