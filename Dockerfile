#each line generates a layer that represents the changes happening from line to another. helps in aching in subsequent builds.

#your image is based on .net5, base is the stage
#whatever happens after this will happen in app directory

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# stage build
# comes from base image of .net sdk 5, required for build the app, not the same you need to just run which is in stage above
# 
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SecretStore.API/SecretStore.API.csproj", "SecretStore.API/"]
COPY ["src/SecretStore.Application/SecretStore.Application.csproj", "SecretStore.Application/"]
COPY ["src/SecretStore.Domain/SecretStore.Domain.csproj", "SecretStore.Domain/"]
COPY ["src/SecretStore.Infrastructure/SecretStore.Infrastructure.csproj", "SecretStore.Infrastructure/"]
RUN dotnet restore "SecretStore.API/SecretStore.API.csproj"
COPY . .
WORKDIR "/src/SecretStore.API"
RUN dotnet build "SecretStore.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SecretStore.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SecretStore.API.dll"]
