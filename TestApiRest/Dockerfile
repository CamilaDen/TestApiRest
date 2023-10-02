FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /ApiLibreria

EXPOSE 80
EXPOSE 5024

COPY ./*.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /ApiLibreria
COPY --from=build /ApiLibreria/out .
ENTRYPOINT ["dotnet","TestApiRest.dll"]
