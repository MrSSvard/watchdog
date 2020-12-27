FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "watchdog/watchdog.csproj"
WORKDIR "/src/."
RUN dotnet build "watchdog/watchdog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "watchdog/watchdog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "watchdog.dll"]
