# Hasin Phone Book API

In-memory phone book API implemented with .NET 8, Clean Architecture, DDD building blocks, MediatR, FluentValidation, Swagger, and xUnit tests.

## Architecture

- `Hasin.Domain`: aggregate root, entities, value objects, and domain validation.
- `Hasin.Application`: feature-based use cases, MediatR commands/queries, validators, application service contracts, and validation pipeline.
- `Hasin.Infrastructure`: in-memory repository implementation.
- `Hasin.Api`: REST controllers, Swagger, dependency wiring, and exception handling middleware.
- `Hasin.Tests`: domain, application service, and MediatR validation tests.

## Domain Model

- `Contact` is the aggregate root for one phone book row.
- `PersonName`, `PhoneNumber`, and `ContactTag` are value objects.
- `IContactRepository` works with aggregate roots and is implemented in Infrastructure.

## Endpoints

- `POST /api/contacts`
- `PUT /api/contacts/{id}`
- `GET /api/contacts?tag={tag}`
- `DELETE /api/contacts/{id}`

## Run

```powershell
dotnet run --project src\Hasin.Api\Hasin.Api.csproj
```

Swagger is available at:

```text
/swagger
```

## Test

```powershell
dotnet test Hasin.sln
```

## Notes

Data is intentionally kept in memory because persistence was not required for the task. A database-backed implementation can be added by replacing `IContactRepository` in the Infrastructure layer.
