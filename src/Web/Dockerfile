FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Zowari/Zowari.csproj", "Zowari/"]
RUN dotnet restore "Zowari/Zowari.csproj"
COPY . .
WORKDIR "/src/Zowari"
RUN dotnet build "Zowari.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Zowari.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zowari.dll"]
