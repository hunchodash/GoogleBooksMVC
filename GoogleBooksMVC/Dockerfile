FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["GoogleBooksMVC.csproj", "./"]
RUN dotnet restore "GoogleBooksMVC.csproj"
COPY . .
RUN dotnet build "GoogleBooksMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GoogleBooksMVC.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "GoogleBooksMVC.dll"]