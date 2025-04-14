FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY AuthService.sln ./
COPY AuthService.Application/*.csproj ./AuthService.Application/
COPY AuthService.Domain/*.csproj ./AuthService.Domain/
COPY AuthService.Persistence/*.csproj ./AuthService.Persistence/
COPY AuthService.Infrastructure/*.csproj ./AuthService.Infrastructure/
COPY AuthService.WebApi/*.csproj ./AuthService.WebApi/

RUN dotnet restore ./AuthService.WebApi/AuthService.WebApi.csproj

COPY . .

WORKDIR /src/AuthService.WebApi
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "AuthService.WebApi.dll"]
