FROM node:16 as node
COPY package.json /app/
COPY cert.crt /app/ssl/
COPY cert.key /app/ssl/

RUN npm install -g @angular/cli --unsafe

WORKDIR /app/
RUN npm install

COPY ./ /app/
RUN ng build --configuration production

FROM nginx

COPY --from=node /app/ssl/cert.crt /etc/nginx/certs/
COPY --from=node /app/ssl/cert.key /etc/nginx/certs/
COPY --from=node /app/nginx-custom.config /etc/nginx/conf.d/default.conf

COPY --from=node /app/dist/RoofstockSampleUI /usr/share/nginx/html

RUN ls /usr/share/nginx/html