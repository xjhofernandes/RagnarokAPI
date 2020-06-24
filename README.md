# Ragnarök Online API
<p align="center">
  <img src="https://i.ibb.co/w7zcbPv/oie-jpg.png" alt="RagnarokAPI" width="300">
</p>
<p align="center">
  <a href="https://xjhofernandes.github.io/RagnarokAPIFront/">Ragnarok API</a> is a RESTful API of the Ragnarök Online developed with .NET Core + Docker + MongoDB 🚀
</p>

## ► Table of Contents

- [About](#about)
- [Setup](#setup)
- [Setup using Docker](#setup-using-docker)

## About

In construction

## Setup

### Dependencies

- [Mongodb](https://www.mongodb.com/)
- [.NET Core](https://dotnet.microsoft.com/download)
- [Visual Studio Community](https://visualstudio.microsoft.com/pt-br/vs/community/)

### Steps

- Just open the file RagnarokAPI.sln with Visual Studio
- Run the project
- If you wanna use the mongodb in localhost go to file <b>appsettings.json</b> and change the connection string to:

```
ConnectionString: "mongodb://localhost:27017"
```
- To launcher the local server go to <b>mongodb/bin</b> folder and run the command: `mongod`

## Setup using Docker

If you do wanna use the Docker follow this steps: 

### Dependencies

- [Docker](https://docs.docker.com/install/) :whale2:

### Steps

- To build and run an image of ther project in Docker, run this commands: 
1. To build a image, use this command in the root folder: ` docker build --rm -f "Dockerfile" -t "RagApi:latest" .`
2. To run the image in local: `docker run -it --rm -p 5000:80 --name ragapi RagApi`

- Visit `localhost:5000/Inicio` to see the running api status!
