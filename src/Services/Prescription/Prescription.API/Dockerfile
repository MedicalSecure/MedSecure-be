#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# intall python
RUN apt-get update && \
    apt-get install -y python3 python3-pip

# Install Python packages
RUN pip install --no-cache-dir --break-system-packages numpy==1.26.4 scikit-learn==1.4.2

USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Prescription/Prescription.API/Prescription.API.csproj", "Services/Prescription/Prescription.API/"]
RUN dotnet restore "./Services/Prescription/Prescription.API/Prescription.API.csproj"
COPY . .
WORKDIR "/src/Services/Prescription/Prescription.API"
RUN dotnet build "./Prescription.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Prescription.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prescription.API.dll"]