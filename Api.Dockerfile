FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
RUN mkdir /app
WORKDIR /app

COPY . .

RUN dotnet publish RzrSite.API/RzrSite.API.csproj -c Release -o out
COPY /Database/RzrSite.db out/

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
RUN mkdir /app
WORKDIR  /app

COPY --from=build /app/out .

EXPOSE 4242
CMD ["dotnet", "RzrSite.API.dll", "--urls=http://+:4242/"]