FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
RUN mkdir /app
WORKDIR /app

COPY . .

RUN dotnet publish RzrSite.Admin/RzrSite.Admin.csproj -c Release -o out
COPY /Database/RzrSite.Admin.db out/

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
RUN mkdir /app
WORKDIR  /app

COPY --from=build /app/out .

EXPOSE 4747
CMD ["dotnet", "RzrSite.Admin.dll", "--urls=http://+:4747", "--rzrhost=http://rzrsite-backend.cashtusk.ru/api"]