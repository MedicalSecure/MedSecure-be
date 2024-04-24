

# Project Backend: Microservices Architecture on .NET 8 with Applying Command Query Responsibility Segregation (CQRS), Clean Architecture, and Domain-Driven Design (DDD)

This project is built upon a microservices architecture using .NET 8. It adheres to the principles of Command Query Responsibility Segregation (CQRS), Clean Architecture, and Domain-Driven Design (DDD). The backend services are designed to be modular and scalable, ensuring flexibility and maintainability.

### Architecture

The backend follows a Microservices Architecture on .NET 8 with the following principles:
- Command Query Responsibility Segregation (CQRS)
- Clean Architecture
- Domain-Driven Design (DDD)

### Technologies Used

- .NET Core 8
- MediatR library for implementing DDD and CQRS
- Entity Framework Core ORM
- RabbitMQ for event queue with MassTransit-RabbitMQ Configuration
- SQL Server database connection and containerization
- FluentValidation for validation
- AutoMapper for object-object mapping
- Ocelot or Yarp for API Gateway
- SeriLog for logging
- Elastic Stack (ELK) for centralized distributed logging (Elasticsearch, Logstash, Kibana)
- HealthChecks feature for monitoring microservices health
- IdentityServer4 for securing Angular apps with OpenID Connect and OAuth2

### Development Practices

- SOLID Principles
- KISS Principle
- YAGNI Principle
- SoC (Separation of Concerns)
- Dependency Inversion Principle (DIP)

### Deployment

Docker File and Docker Compose are used for deployment, ensuring consistency across environments.

## API Gateway Microservice

### Features

- Implements API Gateways using Ocelot or Yarp
- Sample microservices/containers are rerouted through the API Gateways
- Runs multiple different API Gateway/BFF container types
- Utilizes the Gateway aggregation pattern

## Microservices Cross-Cutting Implementations

### Logging

Centralized Distributed Logging is implemented using Elastic Stack (ELK) with Elasticsearch, Logstash, Kibana, and SeriLog for Microservices.

### Health Monitoring

HealthChecks feature is used in backend ASP.NET microservices to monitor their health. Watchdog is implemented in a separate service to watch health and load across services and report health about the microservices by querying with the HealthChecks.

# Comprehensive overview of microservices architecture using ASP.NET Core, along with a comparison to monolithic architecture and an introduction to Docker containers. 

Microservices Using ASP.NET Core
---------------------------------------

The term microservices portrays a software development style that has
grown from contemporary trends to set up practices that are meant to
increase the speed and efficiency of developing and managing software
solutions at scale. Microservices is more about applying a certain
number of principles and architectural patterns as architecture. Each
microservice lives independently, but on the other hand, also all rely
on each other. All microservices in a project get deployed in production
at their own pace, on-premise on the cloud, independently, living side
by side.

Microservices Architecture
--------------------------

The following picture from [MicrosoftDocs](https://learn.microsoft.com/en-us/azure/architecture/guide/architecture-styles/microservices)
shows the microservices architecture style.
![MicrosoftDocs](https://www.codeproject.com/KB/Articles/1276639/image001.png)

There are various components in a microservices architecture apart from
microservices themselves.

**Management**. Maintains the nodes for the service.

**Identity Provider**. Manages the identity information and provides
authentication services within a distributed network.

**Service Discovery**. Keeps track of services and service addresses and
endpoints.

**API Gateway**. Serves as client’s entry point. Single point of contact
from the client which in turn returns responses from underlying
microservices and sometimes an aggregated response from multiple
underlying microservices.

**CDN**. A content delivery network to serve static resources for e.g.
pages and web content in a distributed network

**Static Content** The static resources like pages and web content

Microservices are deployed independently with their own database per
service so the underlying microservices look as shown in the following picture.
![following picture](https://www.codeproject.com/KB/Articles/1276639/image002.png)
 

Monolithic vs Microservices Architecture
----------------------------------------

Monolithic applications are more of a single complete package having all
the related needed components and services encapsulated in one package.

Following is the diagrammatic representation of monolithic architecture
being package completely or being service based.

![Microservice Using ASP.NETCore](https://www.codeproject.com/KB/Articles/1276639/image003.png)

Microservice is an approach to create small services each running in
their own space and can communicate via messaging. These are independent
services directly calling their own database.

Following is the diagrammatic representation of microservices
architecture.

![Microservice Using ASP.NETCore](https://www.codeproject.com/KB/Articles/1276639/image004.png) 

In monolithic architecture, the database remains the same for all the
functionalities even if an approach of service-oriented architecture is
followed, whereas in microservices each service will have its own
database.

Docker Containers and Docker installation
-----------------------------------------

Containers like Dockers and others slice the operating system resources,
for e.g. the network stack, processes namespace, file system hierarchy
and the storage stack. Dockers are more like virtualizing the operating
system. Learn more about dockers
[here](https://www.docker.com/resources/what-container). Open
[this](https://docs.docker.com/docker-for-windows/install/) URL and
click on Download from Docker hub. Once downloaded, login to
the Docker
and follow instructions to install Docker for Windows.


For more details
-----------------
[Microservice Using ASP.NET Core](https://learn.microsoft.com/fr-fr/dotnet/architecture/microservices/)

![Microservice Using ASP.NET Core](https://learn.microsoft.com/fr-fr/dotnet/architecture/microservices/media/cover-large.png)


