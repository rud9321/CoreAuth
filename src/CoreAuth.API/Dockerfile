FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["src/CoreAuth.API/CoreAuth.API.csproj", "src/CoreAuth.API/"]
RUN dotnet restore "src/CoreAuth.API/CoreAuth.API.csproj"
COPY . .
WORKDIR "/src/src/CoreAuth.API"
RUN dotnet build "CoreAuth.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoreAuth.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoreAuth.API.dll"]
