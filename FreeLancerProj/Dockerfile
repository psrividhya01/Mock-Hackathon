FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FreeLancerProj/FreeLancerProj.csproj", "FreeLancerProj/"]
RUN dotnet restore "FreeLancerProj/FreeLancerProj.csproj"
COPY . .
WORKDIR "/src/FreeLancerProj"
RUN dotnet build "./FreeLancerProj.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FreeLancerProj.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FreeLancerProj.dll"]
