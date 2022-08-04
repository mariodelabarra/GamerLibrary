#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/GamerLibrary.Games.API/GamerLibrary.Game.API.csproj", "src/GamerLibrary.Games.API/"]
COPY ["src/GamerLibrary.Games.Domain/GamerLibrary.Game.Domain.csproj", "src/GamerLibrary.Games.API/"]
COPY ["src/GamerLibrary.Games.Service/GamerLibrary.Game.Service.csproj", "src/GamerLibrary.Games.API/"]
COPY ["src/GamerLibrary.Games.Repository/GamerLibrary.Game.Repository.csproj", "src/GamerLibrary.Games.API/"]
RUN dotnet restore "src/GamerLibrary.Games.API/GamerLibrary.Game.API.csproj"
COPY . .
WORKDIR "/src/src/GamerLibrary.Games.API"
RUN dotnet build "GamerLibrary.Game.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GamerLibrary.Game.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GamerLibrary.Game.API.dll"]