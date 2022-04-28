#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
RUN apt update
RUN apt install -y curl
RUN curl -fsSL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get install -y nodejs
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
RUN apt update
RUN apt install -y curl
RUN curl -fsSL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY ["Sketec.IdentityServer/Sketec.IdentityServer.csproj", "Sketec.IdentityServer/"]
COPY ["Sketec.Core/Sketec.Core.csproj", "Sketec.Core/"]
COPY ["Sketec.Application/Sketec.Application.csproj", "Sketec.Application/"]
COPY ["Sketec.Infrastructure/Sketec.Infrastructure.csproj", "Sketec.Infrastructure/"]
RUN dotnet restore "Sketec.IdentityServer/Sketec.IdentityServer.csproj"
COPY . .
WORKDIR "/src/Sketec.IdentityServer"
RUN dotnet build "Sketec.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sketec.IdentityServer.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
RUN unlink /etc/localtime
RUN ln -s /usr/share/zoneinfo/Asia/Bangkok /etc/localtime

WORKDIR /https
COPY certs/aspnetapp.pfx .
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
#Set ENV To Production if you need to deploy for production server
ENV ASPNETCORE_ENVIRONMENT=Staging
ENV TZ=Asia/Bangkok
#ENV ASPNETCORE_URLS=https://+;http://+
#ENV ASPNETCORE_Kestrel__Certificates__Default__Password=Ready123!
#ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
ENTRYPOINT ["dotnet", "Sketec.IdentityServer.dll"]

