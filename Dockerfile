# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar solo el csproj para aprovechar cache
COPY ["Distribucion/Distribucion.csproj", "Distribucion/"]
RUN dotnet restore "Distribucion/Distribucion.csproj"

# Luego copiamos todo el código
COPY . .

WORKDIR "/src/Distribucion"
RUN dotnet build "Distribucion.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Distribucion.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Distribucion.dll"]
