FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Mapster test/Mapster test.csproj", "Mapster test/"]
RUN dotnet restore "Mapster test/Mapster test.csproj"
COPY . .
WORKDIR "/src/Mapster test"
RUN dotnet build "Mapster test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mapster test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mapster test.dll"]
