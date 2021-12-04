FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Amir.Apparel.Demo.Api.Dotnet.csproj", "src/"]
RUN dotnet restore "src\Amir.Apparel.Demo.Api.Dotnet.csproj"
COPY . .
WORKDIR "/src/src"
RUN dotnet build "Amir.Apparel.Demo.Api.Dotnet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Amir.Apparel.Demo.Api.Dotnet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Amir.Apparel.Demo.Api.Dotnet.dll"]
