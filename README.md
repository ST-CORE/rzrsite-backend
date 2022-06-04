# rzrsite-backend
backend solution of the site for our friend

##Docker commands:
docker kill rzrsite-api
docker container rm rzrsite-api -f 
docker image rm aspnet-rzrsite:release -f
docker build -t aspnet-rzrsite:release .
docker run -d -t -p 4242:4242 --name rzrsite-api aspnet-rzrsite:release

##Published version

## Supported endpoints:
/Category - provides list of categories

