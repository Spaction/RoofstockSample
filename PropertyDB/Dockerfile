From mcr.microsoft.com/mssql/server:2017-CU24-ubuntu-16.04

# Install Unzip
RUN apt-get update \
    && apt-get install unzip -y

# Install SQLPackage for Linux and make it executable
RUN wget -progress=bar:force -q -O sqlpackage.zip https://go.microsoft.com/fwlink/?linkid=2165213
RUN unzip -qq sqlpackage.zip -d /opt/sqlpackage
RUN chmod +x /opt/sqlpackage/sqlpackage

# Add the DACPAC to the image
COPY ./bin/Debug/PropertyDB.dacpac /tmp/db.dacpac

# Configure external build arguments to allow configurability.
ARG DBNAME
ARG PASSWORD

# Configure the required environmental variables
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=$PASSWORD
ENV MSSQL_PID=Express

# Launch SQL Server, confirm startup is complete, deploy the DACPAC, then terminate SQL Server.
# See https://stackoverflow.com/a/51589787/488695
RUN (/opt/mssql/bin/sqlservr & ) | grep -q "Service Broker manager has started" \
	&& /opt/sqlpackage/sqlpackage /a:Publish /tsn:. /tdn:${DBNAME} /tu:sa /tp:"$SA_PASSWORD" /sf:/tmp/db.dacpac \
	&& rm /tmp/db.dacpac \
	&& pkill sqlservr