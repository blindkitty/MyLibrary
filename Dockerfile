# 1. build

# Берем полный образ со всеми инструментами для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app


# Сначала копируем файлы проектов и качаем nuget пакеты, потом только копируем весь остальной код
# Это надо для того, чтобы при исправлении условной одной маленькой опечатки в одном файлике пакеты не качались заново
# Пакеты будут качаться только при добавлении новой библиотеки в проект, что очень сильно ускоряет сборку образа

COPY src/MyLibrary.Api/MyLibrary.Api.csproj src/MyLibrary.Api/
COPY src/MyLibrary.Services/MyLibrary.Services.csproj src/MyLibrary.Services/
COPY src/MyLibrary.Database/MyLibrary.Database.csproj src/MyLibrary.Database/
COPY src/MyLibrary.Domain/MyLibrary.Domain.csproj src/MyLibrary.Domain/

RUN dotnet restore src/MyLibrary.Api/MyLibrary.Api.csproj

COPY src/ src/

RUN dotnet publish src/MyLibrary.Api/MyLibrary.Api.csproj -c Release -o /app/publish


# 2. runtime

# Берем неполный образ с только рантаймом
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Development

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "MyLibrary.Api.dll"]