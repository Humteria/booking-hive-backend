#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BookingHive.Api/BookingHive.Api.csproj", "BookingHive.Api/"]
RUN dotnet restore "BookingHive.Api/BookingHive.Api.csproj"
COPY . .
WORKDIR "/src/BookingHive.Api"
RUN dotnet build "BookingHive.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingHive.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:443;http://+:80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingHive.Api.dll"]