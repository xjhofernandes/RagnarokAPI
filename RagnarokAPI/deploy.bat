docker build --rm -f "Dockerfile" -t "ragnarokapi:latest" .

#heroku container:login


#docker images

heroku container:push web -a ragnarokapi

heroku container:release web -a ragnarokapi