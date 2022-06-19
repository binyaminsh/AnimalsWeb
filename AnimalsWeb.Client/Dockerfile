#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AnimalsWeb.Client/AnimalsWeb.Client.csproj", "AnimalsWeb.Client/"]
COPY ["AnimalsWeb.Bl/AnimalsWeb.Bl.csproj", "AnimalsWeb.Bl/"]
COPY ["AnimalsWeb.Data/AnimalsWeb.Data.csproj", "AnimalsWeb.Data/"]
RUN dotnet restore "AnimalsWeb.Client/AnimalsWeb.Client.csproj"
COPY . .
WORKDIR "/src/AnimalsWeb.Client"
RUN dotnet build "AnimalsWeb.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AnimalsWeb.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AnimalsWeb.Client.dll"]