<p align="center">
  <img src="https://i.ibb.co/w7zcbPv/oie-jpg.png" alt="bibleAPI" width="300">
</p>
<p align="center">
  <a href="https://ragnarokapi.herokuapp.com/inicio">Ragnarok API</a> is a RESTful API of the Ragnarök Online developed with Dotnet Core + Docker + MongoDB 🚀
</p>
## ► Table of Contents

- [Why ?](#why-)
- [Setup](#setup)
- [Setup using Docker](#setup-using-docker)
- [Fair use policy](#fair-use-policy)
- [Documentation](https://github.com/marciovsena/bibleapi/blob/dev/DOCUMENTATION.md)
- [Credits and Thanks](#credits-and-thanks)
- [Contributing](#contributing)
- [Contributor](#contributor)

## Why ?

Application and site development is still a complex process for churches and religious organizations.

We know that creating unique content ends up competing with basic tasks such as making devotions, verses, comments, social networking nurture, and so many other day-to-day tasks available.

We believe that we can offer many of these services, free of charge, with the professional quality and focused on the word of God.

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

If you do not want to install Mongo, Node and Yarn, follow these steps.

### Dependencies

- [Docker](https://docs.docker.com/install/) :whale2:

### Steps

- To build and run an image of ther project in Docker, run this commands: 
1. To build a image: ` docker build --rm -f "Dockerfile" -t "RagApi:latest" .`
2. To run the image directly: `docker run -it --rm -p 5000:80 --name ragapi RagApi`

- Visit `localhost:5000/Inicio` to see the running api!
