#Roofstock Sample

Project is split into multiple pieces:

Property.EntityFramework contains the models and contexts for EF Core.
PropertyDB is the database project which will produce a DacPac for database deployment.
RoofstockSampleUI is the angular app.
WebEndpoint contains the Core endpoint.

##How to Execute:

###Docker:
#### Requires only Docker Desktop\Docker installed
All of the applications are set-up to run through docker in a docker network called roofstock-network for DNS naming resolution
The PropertyDB will have its dacpac applied to a SQL Server express image. Running on Port 1433, username: sa, pwd: RoofstockSample1!
WebEndpoint will have its image runing against Kestrel engine. Running on Port 8081 for Https.
The Angular application will run in a nginx server. Running on port 4433 for https.

The only step needed is to trust the pfx located in the https folder of the project. This is a simple localhost cert that is used throughout the docker images.

First step would be running build.bat.

This will create the local images and only requires Docker to be installed locally

After that completes, running run.bat will create the network, and refresh any containers if run multiple times.

Once done, running clean.bat will stop and remove the containers and images


###Individually:
#### Requires Angular, .Net Core, SQl Server, Node.js \ npm

Install the Dacpac on a SQL Server instance. It is expected to have the name RoofstockDb, if not, the connection strin in the API will need to be adjusted (in the appsettings.development.json file).
Open the visual studio project and run it through WebEndpoint (Note, local virus scanner\firewall might block the API connection to the DB).
Open the angular project and run npm install.
After the node_modules folder is restored, run ng serve.

The different layers will run on:

API port localhost:5001.
UI: localhost:4200.