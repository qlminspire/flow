#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Flow.Api/Flow.Api.csproj", "src/Flow.Api/"]
COPY ["src/Flow.Infrastructure/Flow.Infrastructure.csproj", "src/Flow.Infrastructure/"]
COPY ["src/Flow.Application/Flow.Application.csproj", "src/Flow.Application/"]
COPY ["src/Flow.Domain/Flow.Domain.csproj", "src/Flow.Domain/"]
RUN dotnet restore "src/Flow.Api/Flow.Api.csproj"
COPY . .
WORKDIR "/src/src/Flow.Api"
RUN dotnet build "Flow.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Flow.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Flow.Api.dll"]