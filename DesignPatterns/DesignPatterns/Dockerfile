﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DesignPatterns/DesignPatterns.csproj", "DesignPatterns/"]
RUN dotnet restore "DesignPatterns/DesignPatterns.csproj"
COPY . .
WORKDIR "/src/DesignPatterns"
RUN dotnet build "DesignPatterns.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesignPatterns.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesignPatterns.dll"]
