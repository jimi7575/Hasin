# Cover Letter

## Overview

This project implements an in-memory phone book with RESTful APIs, Swagger, MediatR, FluentValidation, and a Clean Architecture style. The solution is intentionally split into Domain, Application, Infrastructure, API, and Test projects so each layer has one clear responsibility.

## Architecture

- `Hasin.Domain` contains the core model: `Contact`, `PersonName`, `PhoneNumber`, and `ContactTag`. `Contact` is the aggregate root for one phone book row, while name, phone number, and tag are value objects. Validation rules live here because they are business invariants, not API concerns.
- `Hasin.Application` contains feature-based use cases, DTOs, service contracts, the `ContactService`, FluentValidation validators, and MediatR commands/queries. Controllers only send requests to the mediator and do not contain business logic.
- `Hasin.Infrastructure` contains the in-memory repository implementation. It is registered as a singleton so data remains available while the application process is running.
- `Hasin.Api` exposes REST endpoints and Swagger. It also has centralized exception handling to map domain validation errors to `400`, missing rows to `404`, and successful deletes to `204`.
- `Hasin.Tests` covers domain behavior and application use cases.

## REST API

- `POST /api/contacts`: create a phone book row.
- `PUT /api/contacts/{id}`: update a row.
- `GET /api/contacts?tag={tag}`: get all rows with a specific tag.
- `DELETE /api/contacts/{id}`: delete a row.

## Implementation Process

I started by defining the domain model around the `Contact` aggregate root and its value objects, because they protect the most important rules: required names, valid phone numbers, and required tags. Then I added the application service, MediatR handlers, and a validation pipeline based on FluentValidation so invalid requests are rejected before reaching handlers. After that, I implemented the infrastructure repository with `ConcurrentDictionary` for safe in-memory access, wired dependencies in the API project, and added focused tests for the requested workflows.

The project does not persist data by design. Replacing the in-memory repository with EF Core or another database later only requires implementing `IContactRepository` in the Infrastructure layer; the API, MediatR handlers, and domain model can remain stable.
