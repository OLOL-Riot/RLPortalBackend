#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
#ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RLPortalBackend/RLPortalBackend.csproj", "RLPortalBackend/"]
RUN dotnet restore "RLPortalBackend/RLPortalBackend.csproj"
COPY . .
WORKDIR "/src/RLPortalBackend"
RUN dotnet build "RLPortalBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RLPortalBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false
#, "--environment=Development"
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RLPortalBackend.dll"]