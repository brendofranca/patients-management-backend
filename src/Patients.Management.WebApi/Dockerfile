#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/Patients.Management.WebApi/Patients.Management.WebApi.csproj", "src/Patients.Management.WebApi/"]
COPY ["src/Patients.Management.Application/Patients.Management.Application.csproj", "src/Patients.Management.Application/"]
COPY ["src/Patients.Management.Infrastructure/Patients.Management.Infrastructure.csproj", "src/Patients.Management.Infrastructure/"]
COPY ["src/Patients.Management.Domain/Patients.Management.Domain.csproj", "src/Patients.Management.Domain/"]
RUN dotnet restore "src/Patients.Management.WebApi/Patients.Management.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Patients.Management.WebApi"
RUN dotnet build "Patients.Management.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Patients.Management.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Patients.Management.WebApi.dll"]