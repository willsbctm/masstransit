FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MassTransitWorker/MassTransitWorker.csproj", "MassTransitWorker/"]
RUN dotnet restore "MassTransitWorker/MassTransitWorker.csproj"
COPY . .
WORKDIR "/src/MassTransitWorker"
RUN dotnet build "MassTransitWorker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MassTransitWorker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MassTransitWorker.dll"]