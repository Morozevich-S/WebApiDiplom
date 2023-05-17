FROM mcr.microsoft.com/dotnet/aspnet:6.0 as base

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /src
COPY WebApiDiplom.csproj .
COPY . .
RUN dotnet restore "WebApiDiplom.csproj"

FROM build as publish
WORKDIR /src
RUN dotnet publish "WebApiDiplom.csproj" -c Debug -o /app/publish

FROM base as final
WORKDIR /app/run
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "WebApiDiplom.dll" ]