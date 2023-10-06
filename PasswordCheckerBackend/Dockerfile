# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the .csproj file and restore any dependencies (via dotnet restore)
COPY PasswordCheckerBackend.csproj ./
RUN dotnet restore

# Publish the application to /app
COPY . .
RUN dotnet publish -c Release -o /app

# Use the ASP.NET Core runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "PasswordCheckerBackend.dll"]
