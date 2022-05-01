#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShopBotNET.Webhook/ShopBotNET.Webhook.csproj", "ShopBotNET.Webhook/"]
COPY ["ShopBotNET.Infrastructure/ShopBotNET.Infrastructure.csproj", "ShopBotNET.Infrastructure/"]
COPY ["ShopBotNET.Core/ShopBotNET.Core.csproj", "ShopBotNET.Core/"]
RUN dotnet restore "ShopBotNET.Webhook/ShopBotNET.Webhook.csproj"
COPY . .
WORKDIR "/src/ShopBotNET.Webhook"
RUN dotnet build "ShopBotNET.Webhook.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopBotNET.Webhook.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopBotNET.Webhook.dll"]