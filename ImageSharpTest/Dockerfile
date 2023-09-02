FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MAUITest/MAUITest.csproj", "MAUITest/"]
RUN dotnet restore "MAUITest/MAUITest.csproj"
COPY . .
WORKDIR "/src/MAUITest"
RUN dotnet build "MAUITest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MAUITest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MAUITest.dll"]
