FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Host/Astral.Membership.API/Astral.Membership.API.csproj", "src/Host/Astral.Membership.API/"]
RUN dotnet restore "./src/Host/Astral.Membership.API/Astral.Membership.API.csproj"
COPY . .
WORKDIR "/src/src/Host/Astral.Membership.API"
RUN dotnet build "./Astral.Membership.API.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Astral.Membership.API.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Astral.Membership.API.dll"]