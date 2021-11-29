#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#ENV CONNECTION_STRING=UserID=postgres;Password=1234;Server=host.docker.internal;Port=3306;Database=Chili_Usermanagement;Integrated Security=true;Pooling=true;
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["UserManagement/UserManagementService.csproj", "UserManagement/"]
RUN dotnet restore "UserManagement/UserManagementService.csproj"
COPY . .
WORKDIR "/src/UserManagement"
RUN dotnet build "UserManagementService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserManagementService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManagementService.dll"]