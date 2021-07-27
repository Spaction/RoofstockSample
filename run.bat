@echo off
echo Clearing Old Containers.. ignore errors
docker network create roofstock-network
docker container stop roofstock_sqldb
docker container rm roofstock_sqldb

docker container stop Roofstock_WebEndpointAPI
docker container rm Roofstock_WebEndpointAPI

docker container stop Roofstock_WebEndpointAPI_dev
docker container rm Roofstock_WebEndpointAPI_dev

docker container stop RoofstockSampleUI
docker container rm RoofstockSampleUI

echo Starting up new Containers

docker run -d --net roofstock-network -p 1433:1433 --name roofstock_sqldb -d roofstock_sample_db:1.0

Rem docker run -d --net roofstock-network -p 8000:80 -p 8001:443 --name Roofstock_WebEndpointAPI_dev -e ASPNETCORE_URLS="https://+;http://+"  -e "ASPNETCORE_ENVIRONMENT=Development" -e ASPNETCORE_Kestrel__Certificates__Default__Password="RoofstockSample1!" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/roofstock.pfx roofstock_sample_api:1.0

docker run -d --net roofstock-network -p 8080:80 -p 8081:443 --name Roofstock_WebEndpointAPI -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_Kestrel__Certificates__Default__Password="RoofstockSample1!" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/roofstock.pfx roofstock_sample_api:1.0

docker run -dt -p 4433:443 --name RoofstockSampleUI -t roofstock_sample_ui:1.0