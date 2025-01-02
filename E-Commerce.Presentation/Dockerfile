# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["E-Commerce.Presentation/E-Commerce.Presentation.csproj", "E-Commerce.Presentation/"]
COPY ["E-Commerce.Application/E-Commerce.Application.csproj", "E-Commerce.Application/"]
COPY ["E-Commerce.Infrastucture/E-Commerce.Infrastucture.csproj", "E-Commerce.Infrastucture/"]
COPY ["E-Commerce.Domain/E-Commerce.Domain.csproj", "E-Commerce.Domain/"]
RUN dotnet restore "./E-Commerce.Presentation/E-Commerce.Presentation.csproj"
COPY . .
WORKDIR "/src/E-Commerce.Presentation"
RUN dotnet build "./E-Commerce.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./E-Commerce.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "E-Commerce.Presentation.dll"]