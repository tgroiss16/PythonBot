FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
 
FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ProjectArcher_Backend.csproj", ""]
RUN dotnet restore "ProjectArcher_Backend.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "ProjectArcher_Backend.csproj" -c Release -o /app
 
FROM build AS publish
RUN dotnet publish "ProjectArcher_Backend.csproj" -c Release -o /app
 
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProjectArcher_Backend.dll"]