FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RabbitPublisher/RabbitPublisher.csproj", "RabbitPublisher/"]
RUN dotnet restore "RabbitPublisher/RabbitPublisher.csproj"
COPY . .
WORKDIR "/src/RabbitPublisher"
RUN dotnet build "RabbitPublisher.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RabbitPublisher.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RabbitPublisher.dll"]
