#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Phoneshop.WebAPI/Phoneshop.WebAPI.csproj", "Phoneshop.WebAPI/"]
COPY ["Phoneshop.Business/Phoneshop.Business.csproj", "Phoneshop.Business/"]
COPY ["Phoneshop.Data/Phoneshop.Data.csproj", "Phoneshop.Data/"]
COPY ["Phoneshop.Domain/Phoneshop.Domain.csproj", "Phoneshop.Domain/"]
COPY ["Phoneshop.Shared/Phoneshop.Shared.csproj", "Phoneshop.Shared/"]
RUN dotnet restore "Phoneshop.WebAPI/Phoneshop.WebAPI.csproj"
COPY . .
WORKDIR "/src/Phoneshop.WebAPI"
RUN dotnet build "Phoneshop.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Phoneshop.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Phoneshop.WebAPI.dll"]