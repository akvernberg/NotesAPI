# Introduction to REST APIs in ASP.NET Core 3.1

- [Introduction to REST APIs in ASP.NET Core 3.1](#introduction-to-rest-apis-in-aspnet-core-31)
  - [Prerequisites](#prerequisites)
  - [Configure endpoints](#configure-endpoints)
  - [Swagger](#swagger)
  - [Middleware](#middleware)
  - [Integration tests](#integration-tests)
  - [*Authentication*](#authentication)

## Prerequisites
- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- A text editor such as [VS Code](https://code.visualstudio.com/)
- Clone this repository

This workshop will feature a series of tasks that hopefully will provide an introduction to a number of basic features in ASP.NET Core 3.1.
We will also briefly look into best practices for setting up REST APIs.

## Configure endpoints
We will start by creating a very basic API supporting storing of notes.

The API should support basic CRUD operations by using common REST API methods (get, post, put).

To make the task easier and to allow you to focus on setting up the API you can find a simple DataAccess-project in the src-folder.

Start out by creating an API using the dotnet templates. This can be done in visual studio or through the command line:
```
mkdir src/NotesApi;
cd src/NotesAPI;
dotnet new webapi -f Target netcoreapp3.1
```

Make sure to take a look a Program.cs and Startup.cs to become familiar with what is set up.

*A solution can be found in the branch 'endpoints', but it would be useful to attempt this task yourself*

## Swagger
[Swagger](https://swagger.io/) makes documenting our API and sharing that documentation with others a whole lot easier.
Introduce Swagger to your project and try to make the documentation as specific as possible.
That includes for example return codes and types.

*A solution can be found in the branch 'swagger', but it would be useful to attempt this task yourself*

## Middleware
Middleware is a useful tool for expanding your HTTP Request Pipeline.

Implement middleware that adds a Correlation-ID to every request. This allows us to debug specific requests a whole lot easier.

*A solution can be found in the branch 'middleware', but it would be useful to attempt this task yourself*

## Integration tests
It's important to create good integration tests for your API to ensure that everything is connected in a proper manner.

Use the TestServer-functionality delivered by ASP.NET Core to test your API.

## *Authentication*
If you want an extra challenge, try to implement authentication and authorization for your API.

If you want to serve multiple users this would probably be a good idea.