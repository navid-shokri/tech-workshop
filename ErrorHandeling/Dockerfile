FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ErrorHandeling/ErrorHandeling.csproj", "ErrorHandeling/"]
RUN dotnet restore "ErrorHandeling/ErrorHandeling.csproj"
COPY . .
WORKDIR "/src/ErrorHandeling"
RUN dotnet build "ErrorHandeling.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ErrorHandeling.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ErrorHandeling.dll"]
