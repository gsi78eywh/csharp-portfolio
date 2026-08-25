FROM mcr.microsoft.com/dotnet/sdk:8.0.424 AS build
WORKDIR /source

COPY PortfolioWeb.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0.30 AS runtime
WORKDIR /app
COPY --from=build /app ./

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_HTTP_PORTS=8080
ENV DOTNET_HOSTBUILDER__RELOADCONFIGONCHANGE=false
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
EXPOSE 8080

ENTRYPOINT ["dotnet", "PortfolioWeb.dll"]
