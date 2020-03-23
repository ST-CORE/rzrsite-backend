FROM mcr.microsoft.com/dotnet/core/sdk:3.1
RUN mkdir /app
WORKDIR /app

COPY . .

RUN dotnet publish -c Release -o out

COPY ./Database/RzrSite.db ./out

EXPOSE 4242/tcp

CMD ["dotnet", "out/RzrSite.API.dll", "--urls=http://localhost:4242/"]