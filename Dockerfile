FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8000

ENV ASPNETCORE_URLS=http://*:8000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
#RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
#USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG configuration=Release

WORKDIR /src
COPY ["src/UserPlatform.Domain/UserPlatform.Domain.csproj", "src/UserPlatform.Domain/"]
RUN dotnet restore "src/UserPlatform.Domain/UserPlatform.Domain.csproj"
COPY . .

WORKDIR /src
COPY ["src/UserPlatform.ApplicationCore/UserPlatform.ApplicationCore.csproj", "src/UserPlatform.ApplicationCore/"]
RUN dotnet restore "src/UserPlatform.ApplicationCore/UserPlatform.ApplicationCore.csproj"
COPY . .

WORKDIR /src
COPY ["src/UserPlatform.Persistence/UserPlatform.Persistence.csproj", "src/UserPlatform.Persistence/"]
RUN dotnet restore "src/UserPlatform.Persistence/UserPlatform.Persistence.csproj"
COPY . .

WORKDIR /src
COPY ["src/UserPlatform.Web/UserPlatform.Web.csproj", "src/UserPlatform.Web/"]
RUN dotnet restore "src/UserPlatform.Web/UserPlatform.Web.csproj"
COPY . .

WORKDIR "/src/src/UserPlatform.Web"
RUN dotnet build "UserPlatform.Web.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "UserPlatform.Web.csproj" -c $configuration -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserPlatform.Web.dll"]
