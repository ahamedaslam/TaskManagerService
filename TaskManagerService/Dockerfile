FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TaskManagerService/TaskManagerService.csproj", "TaskManagerService/"]
RUN dotnet restore "TaskManagerService/TaskManagerService.csproj"
COPY . .
WORKDIR "/src/TaskManagerService"
RUN dotnet build "TaskManagerService.csproj" -c Release -o /app/build /p:SelfContained=false

FROM build AS publish
RUN dotnet publish "TaskManagerService.csproj" -c Release -o /app/publish /p:UseAppHost=false /p:SelfContained=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagerService.dll"]
