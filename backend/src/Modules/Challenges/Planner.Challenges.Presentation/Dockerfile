FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TaskTracker.Presentation/TaskTracker.Presentation.Api/TaskTracker.Presentation.Api.csproj", "TaskTracker.Presentation/TaskTracker.Presentation.Api/"]
COPY ["TaskTracker.Infrastructure/TaskTracker.Infrastructure.Persistence/TaskTracker.Infrastructure.Persistence.csproj", "TaskTracker.Infrastructure/TaskTracker.Infrastructure.Persistence/"]
COPY ["TaskTracker.Core/Planner.Challenges.Application/Planner.Challenges.Application.csproj", "TaskTracker.Core/Planner.Challenges.Application/"]
COPY ["TaskTracker.Core/TaskTracker.Core.Domain/TaskTracker.Core.Domain.csproj", "TaskTracker.Core/TaskTracker.Core.Domain/"]
RUN dotnet restore "TaskTracker.Presentation/TaskTracker.Presentation.Api/TaskTracker.Presentation.Api.csproj"
COPY . .
WORKDIR "/src/TaskTracker.Presentation/TaskTracker.Presentation.Api"
RUN dotnet build "TaskTracker.Presentation.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TaskTracker.Presentation.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskTracker.Presentation.Api.dll"]
