FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RabbitSubscriber/RabbitSubscriber.csproj", "RabbitSubscriber/"]
RUN dotnet restore "RabbitSubscriber/RabbitSubscriber.csproj"
COPY . .
WORKDIR "/src/RabbitSubscriber"
RUN dotnet build "RabbitSubscriber.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RabbitSubscriber.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RabbitSubscriber.dll"]
