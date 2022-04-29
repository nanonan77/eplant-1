FROM node:14.17.1 as build
WORKDIR /app
COPY Sketec.UI .
RUN npm install && npm run build

FROM nginx as final
COPY Sketec.UI/docker/default.conf /etc/nginx/conf.d/
COPY --from=build /app/build /usr/share/nginx/html
EXPOSE 80