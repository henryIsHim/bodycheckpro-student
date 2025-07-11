# Use the official .NET runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY BodyCheckWebAPI.csproj .
RUN dotnet restore BodyCheckWebAPI.csproj

# Copy the entire source code
COPY . .

# Build the application
RUN dotnet publish BodyCheckWebAPI.csproj -c Release -o /app/publish

# Build the runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Create Data directory for SQLite database
RUN mkdir -p Data

ENTRYPOINT ["dotnet", "BodyCheckWebAPI.dll"]