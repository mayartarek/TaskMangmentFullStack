# Task Manager

A simple Full Stack Task Manager application built with ASP.NET Core Web API, Angular, and SQL Server.

## Technologies

### Backend
- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Repository Pattern
- Service Layer
- Dependency Injection
- Global Exception Handling

### Frontend
- Angular
- Bootstrap
- Reactive Forms

## Features

- Manage Projects
- Manage Tasks
- Assign Tasks to Projects
- Update Task Status
- Filter Tasks by Status
- Pagination
- CRUD Operations

## Database

The application uses SQL Server with Entity Framework Core Code First.

Run the following command to create the database:

```bash
dotnet ef database update
```

## How to Run

### Backend

```bash
cd BackEnd
dotnet restore
dotnet ef database update
dotnet run
```

The API will be available at:

```
https://localhost:7026/swagger
```

### Frontend

```bash
cd FrontEnd
npm install
ng serve
```

Open:

```
http://localhost:4200
```

## Architecture

The solution follows a simplified Clean Architecture:

```
Demo.Api
Demo.Application
Demo.Domain
Demo.Infrastructure
```

It includes:

- Repository Pattern
- Service Layer
- Dependency Injection
- Validation
- Global Exception Middleware

## API Endpoints

### Projects

- GET /api/projects
- GET /api/projects/{id}
- POST /api/projects
- PUT /api/projects/{id}
- DELETE /api/projects/{id}

### Tasks

- GET /api/taskItem
- GET /api/taskItem/{id}
- POST /api/taskItem
- PUT /api/taskItem/{id}
- DELETE /api/taskItem/{id}
- GET /api/taskItem?status=ToDo

## Assumptions

- Each Task belongs to exactly one Project.
- Task status can be:
  - ToDo
  - InProgress
  - Done

## Future Improvements

- Authentication & Authorization
- Unit Tests
- Docker Support
- Search
- Sorting
- File Attachments