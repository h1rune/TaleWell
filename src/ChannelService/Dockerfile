FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ChannelService.sln ./
COPY ChannelService.Application/*.csproj ./ChannelService.Application/
COPY ChannelService.Domain/*.csproj ./ChannelService.Domain/
COPY ChannelService.Persistence/*.csproj ./ChannelService.Persistence/
COPY ChannelService.WebApi/*.csproj ./ChannelService.WebApi/

RUN dotnet restore ./ChannelService.WebApi/ChannelService.WebApi.csproj

COPY . .

WORKDIR /src/ChannelService.WebApi
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "ChannelService.WebApi.dll"]
