# rzrsite-backend
backend solution of the site for our friend

##Docker commands:
docker kill rzrsite-api
docker container rm rzrsite-api -f 
docker image rm aspnet-rzrsite:v0.1 -f
docker build -t aspnet-rzrsite:v0.1 .
docker run -d -t -p 4242:4242 --name rzrsite-api aspnet-rzrsite:v0.1

##Published version
http://194.58.119.151:4242  (done by teamcity)

## Supported endpoints:
/Category - provides list of categories

