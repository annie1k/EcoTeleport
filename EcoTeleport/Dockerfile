FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EcoTeleport/EcoTeleport.csproj", "EcoTeleport/"]
RUN dotnet restore "EcoTeleport/EcoTeleport.csproj"
COPY . .
WORKDIR "/src/EcoTeleport"
RUN dotnet build "EcoTeleport.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EcoTeleport.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EcoTeleport.dll"]
