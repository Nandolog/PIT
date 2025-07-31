# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
# Etapa base para ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
# USER $APP_UID  # ⚠️ Comentar si no se define APP_UID en entorno


# This stage is used to build the service project
# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PIT.Backend/PIT.Backend.csproj", "PIT.Backend/"]
RUN dotnet restore "./PIT.Backend/PIT.Backend.csproj"
COPY . .
WORKDIR "/src/PIT.Backend"
RUN dotnet build "./PIT.Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
# Etapa de publicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PIT.Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
# Etapa final para producción
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PIT.Backend.dll"]