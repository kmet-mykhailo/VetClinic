# VetClinic

VetClinic is a demonstration project designed to explore and demonstrate different approaches to building a modern distributed system.

The project focuses on **microservices, micro frontends, authentication, inter-service communication, real-time updates, and shared infrastructure**. 
It is intended primarily as a technical playground for experimenting with architectural patterns and technologies rather than as a production-ready system.

## Architecture

The solution consists of several independent applications and shared libraries.

### Backend Services

* **Auth** — Authentication and authorization service.

  * Uses Google as the external Identity Provider.
  * The Auth service maintains its own user and permission model.
  * Authentication through Google establishes the user's identity, while authorization and application permissions are managed by VetClinic.

* **Medical Record** — Service responsible for medical records and related functionality.

* **ClientPatient** — Service responsible for clients, patients, and related functionality.

* **SignalR** — Real-time communication service responsible for pushing updates to connected front-end applications.

### Frontend

The frontend is organized as **micro frontends** using [single-spa](https://single-spa.js.org/).

Each major application area can be developed and deployed independently while being integrated into a single user experience.

The project will also demonstrate different approaches to communication between micro frontends and backend services.

## Communication

The solution will demonstrate several communication mechanisms, depending on the scenario:

* **gRPC** — synchronous service-to-service communication.
* **Kafka** — event-driven communication and asynchronous messaging.
* **Azure Service Bus** — asynchronous messaging and integration between services.
* **SignalR** — real-time server-to-client communication.

The goal is to demonstrate the differences between these approaches and how they can be used in a distributed system.

## Authentication & Authorization

Authentication uses **Google as the Identity Provider**.

The authentication flow is separated from application authorization:

1. The user authenticates with Google.
2. The Auth service identifies the user.
3. VetClinic manages the user's application-specific permissions.
4. Services use those permissions to determine what the user is allowed to access.

This separation allows the project to demonstrate the difference between **authentication (who the user is)** and **authorization (what the user is allowed to do)**.

## Shared Libraries

The solution contains common libraries used by multiple services.

These libraries are intended to contain functionality that is genuinely shared between applications while keeping service-specific business logic within the individual services.

Examples may include:

* Common contracts
* Shared infrastructure
* Authentication/authorization abstractions
* Messaging abstractions
* Common utilities

## Technologies

The technology stack will evolve as the project develops. The current planned technologies include:

### Backend

* .NET
* ASP.NET Core
* Entity Framework Core
* gRPC
* SignalR

### Frontend

* Angular
* single-spa
* Micro frontends

### Messaging

* Apache Kafka
* Azure Service Bus

### Authentication

* Google Identity / OAuth 2.0
* OpenID Connect
* ASP.NET Core Authentication & Authorization

### Cloud

* Microsoft Azure

## Goals

The main goals of the project are to demonstrate practical implementation of:

* Microservices architecture
* Micro frontends
* Authentication and authorization
* OAuth 2.0 / OpenID Connect
* Synchronous and asynchronous service communication
* Event-driven architecture
* Real-time communication
* Shared libraries and contracts
* Distributed system patterns
* Integration between independently developed components

The project is expected to evolve over time as new technologies and architectural approaches are explored.

## Project Structure

The solution is organized into applications and shared libraries:

```text
VetClinic/
│
├── Auth/
│   └── API/
│
├── MedicalRecord/
│   ├── API/
│   ├── FrontEnds/
│   └── client-patient/
│
├── ClientPatient/
│   ├── API/
│   └── FrontEnds/
│
├── SignalR/
│   ├── API/
│   └── FrontEnds/
│
├── Common/
│
└── README.md
```

The exact structure may change as the project evolves.

## Status

🚧 **Work in progress**

The project is being developed incrementally. New services, communication mechanisms, authentication scenarios, and architectural patterns will be added over time.
