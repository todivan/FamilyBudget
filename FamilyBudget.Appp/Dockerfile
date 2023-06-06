#Compile and build
FROM node:latest as build

WORKDIR /usr/local/app

COPY ./ /usr/local/app/

RUN npm install

RUN npm run build


#Serve app with nginx server
FROM nginx:latest

COPY --from=build /usr/local/app/dist/family-budget.appp /usr/share/nginx/html


EXPOSE 80
