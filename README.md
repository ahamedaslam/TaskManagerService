# 🚀 Task Manager Service


<img width="1006" height="553" alt="Image" src="https://github.com/user-attachments/assets/62837525-e787-48bb-a59c-a6737d1e1a53" />

A scalable and secure **Multi-Tenant Task Management System** built with **ASP.NET Core**. The service is designed to support multiple organizations (tenants) while ensuring strict data isolation, role-based security, and enterprise-grade architecture.

---

## 📖 Overview

Task Manager Service is part of a modern microservices-based task management platform. It enables organizations to manage tasks efficiently while maintaining complete tenant isolation and secure access controls.

The service is built following clean architecture principles and supports enterprise features such as:

* Multi-Tenant Architecture
* Role-Based Authorization (RBAC)
* JWT Authentication
* AI-Powered Task Assistant
* Structured Logging
* Advanced Task Filtering & Pagination

---

## 🛠 Technology Stack

| Technology            | Description                |
| --------------------- | -------------------------- |
| ASP.NET Core 8        | Backend API Framework      |
| Entity Framework Core | ORM & Data Access          |
| SQL Server            | Relational Database        |
| Angular               | Frontend Application       |
| JWT Authentication    | Secure User Authentication |
| ASP.NET Identity      | User & Role Management     |
| Serilog               | Structured Logging         |
| Swagger/OpenAPI       | API Documentation          |
| Ocelot API Gateway    | API Gateway & Routing      |
| Azure SQL             | Cloud Database             |
| IIS + Kestrel         | Hosting Infrastructure     |

---

## 🏗 Architecture

The application follows a layered architecture to ensure maintainability, scalability, and separation of concerns.

### Layers

* Controllers
* Services
* Repositories
* DTOs
* Middleware
* Helpers

### Design Patterns

* Repository Pattern
* Service Pattern
* Dependency Injection
* Multi-Tenant Architecture
* Clean Architecture Principles

---

## 🔐 Security Features

### Authentication

* JWT Access Tokens
* Refresh Token Support
* OTP Verification
* ASP.NET Identity Integration

### Authorization

Role-based access control:

#### Admin

* Create Tasks
* Update Tasks
* Delete Tasks
* View All Tenant Tasks
* Manage Users

#### Normal User

* View Assigned Tasks
* Update Task Status
* Access Personal Dashboard

---

## 🏢 Multi-Tenancy

The system supports multiple tenants while maintaining strict data isolation.

### Tenant Isolation

Every request is scoped by:

* Tenant ID
* User ID
* User Role

This ensures:

* No cross-tenant data leakage
* Secure access boundaries
* Enterprise-grade security

---

## ✨ Key Features

### Task Management

* Create Tasks
* Update Tasks
* Delete Tasks
* View Tasks
* Task Assignment
* Task Completion Tracking

### Advanced Search

* Filtering
* Sorting
* Pagination
* Search by Status
* Search by User

### Dashboard Analytics

* Task Statistics
* Completion Metrics
* Pending Tasks
* Productivity Insights

### AI Assistant

Integrated AI assistant capable of:

* Task Summarization
* Task Insights
* Productivity Assistance
* Context-Aware Responses

### Structured Logging

Every operation includes:

* Request Tracking
* Correlation IDs
* Tenant Context
* User Context
* Unique Log Identifier

---

## 🌐 API Gateway Integration

The platform uses **Ocelot API Gateway** for centralized request routing.

### Request Flow

```text
Angular Frontend
        │
        ▼
Ocelot API Gateway
        │
        ▼
Task Manager Service
        │
        ▼
SQL Server
```

### Example Endpoint

```http
GET /gateway/taskmanager/dashboard/taskAnalytics
```

Forwarded To:

```http
GET /api/taskmanager/dashboard/taskAnalytics
```

---

## 📌 API Endpoints

### Authentication

| Method | Endpoint                |
| ------ | ----------------------- |
| POST   | /api/auth/login         |
| POST   | /api/auth/register      |
| POST   | /api/auth/verify-otp    |
| POST   | /api/auth/refresh-token |

---

### Task Management

| Method | Endpoint                                             |
| ------ | ---------------------------------------------------- |
| POST   | /api/taskmanager/taskmanager/create                  |
| POST   | /api/taskmanager/taskmanager/getTasks                |
| POST   | /api/taskmanager/taskmanager/getTask                 |
| PUT    | /api/taskmanager/taskmanager/update                  |
| DELETE | /api/taskmanager/taskmanager/delete                  |
| PATCH  | /api/taskmanager/taskmanager/setTaskCompletionStatus |

---

### Dashboard

| Method | Endpoint                                 |
| ------ | ---------------------------------------- |
| GET    | /api/taskmanager/dashboard/taskAnalytics |

---

### Tenant

| Method | Endpoint                           |
| ------ | ---------------------------------- |
| POST   | /api/taskmanager/tenant/create     |
| GET    | /api/taskmanager/tenant/getTenants |

---

### AI Chat

| Method | Endpoint                     |
| ------ | ---------------------------- |
| POST   | /api/taskmanager/aichat/chat |

---

## 📂 Project Structure

```text
TaskManagerService
│
├── Controllers
│   ├── TaskManagerController
│   ├── DashboardController
│   ├── TenantController
│   └── AIChatController
│
├── Services
│
├── Repositories
│
├── DTOs
│
├── Entity
│
├── Middleware
│
├── Helper
│
└── Context
```

---

## 🧱 System Architecture


### Request Flow

1. Angular frontend sends HTTPS request.
2. Ocelot API Gateway receives the request.
3. Gateway routes request to TaskManagerService.
4. Middleware validates JWT and Tenant Context.
5. Service layer executes business logic.
6. Entity Framework communicates with SQL Server.
7. Response is returned to the client.

---

## 📊 Logging & Monitoring

The service uses Serilog for structured logging.

Features:

* Correlation ID Tracking
* Request Logging
* Exception Logging
* Tenant Context Logging
* User Context Logging

Example:

```text
[RequestId: 1f34ab]
[TenantId: Tenant001]
[UserId: User001]
Tasks retrieved successfully.
```

---

## 🚀 Running Locally

### Clone Repository

```bash
git clone https://github.com/ahamedaslam/TaskManagerService.git
```

### Restore Packages

```bash
dotnet restore
```

### Apply Database Migrations

```bash
dotnet ef database update
```

### Run Application

```bash
dotnet run
```

### Swagger

```text
https://localhost:7002/swagger
```

---

## 🔮 Upcoming Enhancements

* Redis Distributed Caching
* Docker Containerization
* Swagger Aggregation
* Rate Limiting
* Centralized Logging
* Distributed Tracing
* Event-Driven Architecture
* Message Queues (RabbitMQ/Azure Service Bus)

---

## 👨‍💻 Author

### Ahamed Aslam

Full-Stack Software Engineer

Technologies:

* ASP.NET Core
* Angular
* Spring Boot
* SQL Server
* Entity Framework Core
* Microservices
* Ocelot API Gateway
* JWT Authentication
* Azure
* Python

LinkedIn:
https://linkedin.com/in/aslam-softwareengineer

Portfolio:
https://portfolioaslam.netlify.app/
