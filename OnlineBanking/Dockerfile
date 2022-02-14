#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["OnlineBanking/OnlineBanking.API.csproj", "OnlineBanking/"]
COPY ["OnlineBanking.Business/OnlineBanking.Business.csproj", "OnlineBanking.Business/"]
COPY ["OnlineBanking.DataAccess/OnlineBanking.DataAccess.csproj", "OnlineBanking.DataAccess/"]
COPY ["OnlineBanking.Common/OnlineBanking.Common.csproj", "OnlineBanking.Common/"]
RUN dotnet restore "OnlineBanking/OnlineBanking.API.csproj"
COPY . .
WORKDIR "/src/OnlineBanking"
RUN dotnet build "OnlineBanking.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineBanking.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineBanking.API.dll"]