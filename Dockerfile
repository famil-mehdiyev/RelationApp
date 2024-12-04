# Use the official image for ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 8080
EXPOSE 8081 

# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file and restore dependencies (via dotnet restore)
COPY ["OneToManyRelation.csproj", "OneToManyRelation/"]
RUN dotnet restore ["OneToManyRelation/OneToManyRelation.csproj"]

# Copy he entire project and build the application

WORKDIR "/src/OneToManyRelation"
COPY . .
RUN dotnet build "OneToManyRelation.csproj" -c Release -o /app/build

# Publish the application to the /app/publish directory
FROM build AS publish
RUN dotnet publish "OneToManyRelation.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Define the final image with the app published
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OneToManyRelation.dll"]



