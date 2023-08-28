# GraphQL Sample using .NET 7 and Docker

## Requirements

- .NET 7 SDK
- Docker (optional)

## Build and Run

### Using local without a SQL Server

To run the application with an in-memory database, run the following command:

```shell
dotnet build
dotnet run
```

Built application runs on `http://localhost:5300/graphql` and `http://localhost:5300/graphql-voyager` for GUI schema
documentation.
Use port `7007` for HTTPS.

### Using Docker

To run the application, run the following command:

```shell
docker compose -f ./docker-compose.yaml -p <your-project-name> up --build -d
```

Built application runs on `http://localhost:5300/graphql` and `http://localhost:5300/graphql-voyager` for GUI schema
documentation.