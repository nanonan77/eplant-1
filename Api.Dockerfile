#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Sketec.Api/Sketec.Api.csproj", "Sketec.Api/"]
COPY ["Sketec.Core/Sketec.Core.csproj", "Sketec.Core/"]
COPY ["Sketec.Application/Sketec.Application.csproj", "Sketec.Application/"]
COPY ["Sketec.Infrastructure/Sketec.Infrastructure.csproj", "Sketec.Infrastructure/"]
RUN dotnet restore "Sketec.Api/Sketec.Api.csproj"
RUN dotnet restore "Sketec.FileWriter/Sketec.FileWriter.csproj"
COPY . .
WORKDIR "/src/Sketec.Api"
RUN dotnet build "Sketec.Api.csproj" --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sketec.Api.csproj" -c Release -o /app/publish

FROM base AS final
RUN unlink /etc/localtime
RUN ln -s /usr/share/zoneinfo/Asia/Bangkok /etc/localtime

WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Staging
ENV TZ=Asia/Bangkok
# ENV ASPNETCORE_URLS=https://+;http://+
# ENV ASPNETCORE_Kestrel__Certificates__Default__Password=Ready123!
# ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
ENTRYPOINT ["dotnet", "Sketec.Api.dll"]
