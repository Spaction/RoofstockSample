@echo off
cd PropertyDB
docker build -t roofstock_sample_db:1.0 --build-arg DBNAME=RoofstockDb --build-arg PASSWORD=RoofstockSample1! .
cd ..
Rem dotnet dev-certs https -ep .\https\roofstock.pfx -p RoofstockSample1! --trust

Rem copy /Y /V https\roofstock.pfx WebEndpoint\roofstock.pfx
Rem copy /Y /V https\cert.* RoofstockSampleUI\cert.*

docker build -f "E:\Users\Spaction\Desktop\WebEndpoint\WebEndpoint\Dockerfile" --force-rm -t roofstock_sample_api:1.0 "E:\Users\Spaction\Desktop\WebEndpoint"

docker build -f "E:\Users\Spaction\Desktop\WebEndpoint\RoofstockSampleUI\Dockerfile" -t roofstock_sample_ui:1.0 "E:\Users\Spaction\Desktop\WebEndpoint\RoofstockSampleUI"