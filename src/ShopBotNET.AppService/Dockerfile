#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShopBotNET.AppService/ShopBotNET.AppService.csproj", "ShopBotNET.AppService/"]
COPY ["ShopBotNET.Infrastructure/ShopBotNET.Infrastructure.csproj", "ShopBotNET.Infrastructure/"]
COPY ["ShopBotNET.Core/ShopBotNET.Core.csproj", "ShopBotNET.Core/"]
RUN dotnet restore "ShopBotNET.AppService/ShopBotNET.AppService.csproj"
COPY . .
WORKDIR "/src/ShopBotNET.AppService"
RUN dotnet build "ShopBotNET.AppService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopBotNET.AppService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopBotNET.AppService.dll"]