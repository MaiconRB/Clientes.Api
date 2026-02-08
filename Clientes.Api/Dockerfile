# ===== Runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

# ===== Build =====
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Clientes.Api.csproj", "./"]
RUN dotnet restore "Clientes.Api.csproj"

COPY . .
RUN dotnet publish -c Release -o /app/publish

# ===== Final =====
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Clientes.Api.dll"]
