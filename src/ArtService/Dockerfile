FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ArtService.sln ./
COPY ArtService.Application/*.csproj ./ArtService.Application/
COPY ArtService.Domain/*.csproj ./ArtService.Domain/
COPY ArtService.Persistence/*.csproj ./ArtService.Persistence/
COPY ArtService.WebApi/*.csproj ./ArtService.WebApi/

RUN dotnet restore ./ArtService.WebApi/ArtService.WebApi.csproj

COPY . .

WORKDIR /src/ArtService.WebApi
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "ArtService.WebApi.dll"]
