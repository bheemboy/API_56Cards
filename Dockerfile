# Use the following commands to build and push
# docker build -t bheemboy/api_56cards:latest -t bheemboy/api_56cards:$(Get-Date -Format "yyyy.MM.dd") .
# docker push --all-tags bheemboy/api_56cards

# Stage 1 ##############################################################################
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /build
COPY . .
RUN dotnet publish API_56Cards.sln -c Release -o /webapi

# Stage 2 ##############################################################################
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

EXPOSE 8080
ENV TZ=America/Los_Angeles
# ENV ASPNETCORE_URLS=http://+:8080

RUN apt-get update; apt-get install -y curl

WORKDIR /webapi
COPY --from=build /webapi .

CMD ["dotnet", "/webapi/API_56Cards.dll"]

HEALTHCHECK CMD curl --fail http://localhost:80/health || exit
