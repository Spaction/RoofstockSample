@echo off
docker container stop roofstock_sqldb
docker container rm roofstock_sqldb

docker container stop Roofstock_WebEndpointAPI
docker container rm Roofstock_WebEndpointAPI

docker container stop RoofstockSampleUI
docker container rm RoofstockSampleUI

docker network rm roofstock-network


docker image remove roofstock_sample_db:1.0

docker image remove roofstock_sample_api:1.0

docker image remove roofstock_sample_ui:1.0