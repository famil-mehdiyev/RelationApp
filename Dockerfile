# Use the official image for ASP.NET Core runtime as the base image
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#WORKDIR /app

#EXPOSE 8080
#EXPOSE 8081 

# Use the .NET SDK image to build the application
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /src

# Copy the .csproj file and restore dependencies (via dotnet restore)
#COPY ["OneToManyRelation.csproj", "OneToManyRelation/"]
#RUN dotnet restore "./OneToManyRelation/OneToManyRelation.csproj"

# Copy the entire project and build the application

#WORKDIR "/src/OneToManyRelation"
#COPY . .
#RUN dotnet build "OneToManyRelation.csproj" -c Release -o /app/build

# Publish the application to the /app/publish directory
#FROM build AS publish
#RUN dotnet publish "OneToManyRelation.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Define the final image with the app published
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "OneToManyRelation.dll"]


# ASP.NET Core runtime üçün rəsmi imici əsas şəkil kimi istifadə et
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

EXPOSE 8080
EXPOSE 8081 

# .NET SDK imicini istifadə edərək tətbiqi qurmaq
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# .csproj faylını köçür və asılılıqları bərpa et (dotnet restore ilə)
COPY ["OneToManyRelation/OneToManyRelation.csproj", "OneToManyRelation/"]
RUN dotnet restore "OneToManyRelation/OneToManyRelation.csproj"

# Bütün layihəni köçür və tətbiqi qur
WORKDIR "/src/OneToManyRelation"
COPY . .
RUN dotnet build "OneToManyRelation.csproj" -c Release -o /app/build

# Tətbiqi /app/publish qovluğuna dərc et
FROM build AS publish
RUN dotnet publish "OneToManyRelation.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Dərc edilmiş tətbiq ilə son imici müəyyən et
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OneToManyRelation.dll"]

