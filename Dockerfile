# Базовый образ для приложения
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Образ для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файлы проектов
COPY ./WebServiceModule/WebServiceModule.csproj ./WebServiceModule/
COPY ./WebServiceModule/DataModule/DataModule.csproj ./DataModule/

# Восстанавливаем зависимости
RUN dotnet restore ./WebServiceModule/WebServiceModule.csproj

# Копируем все файлы проекта
COPY ./WebServiceModule/ ./WebServiceModule/

# Публикуем приложение
RUN dotnet publish ./WebServiceModule/WebServiceModule.csproj -c Release -o /app/publish

# Используем минимальный образ для финальной стадии
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebServiceModule.dll"]
