FROM node:16 AS build
WORKDIR /app
COPY ./package.json ./package-lock.json ./
RUN npm install
COPY . ./
RUN npm run build --prod

FROM nginx:1.19.0-alpine
COPY --from=build /app/dist/password-checker/ /usr/share/nginx/html
