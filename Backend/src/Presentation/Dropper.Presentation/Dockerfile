FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Presentation/Dropper.Presentation/Dropper.Presentation.csproj", "src/Presentation/Dropper.Presentation/"]
RUN dotnet restore "src/Presentation/Dropper.Presentation/Dropper.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Presentation/Dropper.Presentation"
RUN dotnet build "Dropper.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Dropper.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dropper.Presentation.dll"]
