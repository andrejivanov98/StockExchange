# Technical Assessment - Stock Exchange Application

This repository contains my solution for a technical assessment aimed at developing a stock exchange application. The solution demonstrates my approach to software design and development, emphasizing clean architecture, design patterns, and modern technologies.

## Overview
### Approach
My approach to this assignment was methodical and focused on creating a scalable, maintainable, and efficient application. I started by understanding the requirements and then structured the application into distinct layers. Emphasis was placed on clear separation of concerns, code reusability, and implementing best practices in software development.

### Architecture and Technologies
#### Architecture: 3-Tier Architecture
##### 1. Data Context Layer:

- Manages the data interactions and serves as the data access layer of the application.
- Utilizes Entity Framework Core for the in-memory database to simulate stock exchange transactions.

##### 2. Service Layer:

- Contains business logic and handles the application's core functionality.
- Implements design patterns like Repository, CQRS (Command Query Responsibility Segregation), and Service pattern for clear separation of concerns and modularity.

##### 3. UI Layer:

- Developed using React, providing a dynamic and responsive user interface.
- Interacts with the backend services through API calls, displaying data, and submitting user inputs.

#### Technologies
- Backend: ASP.NET Core 6.0
- Frontend: React
- Database: In-Memory Database using Entity Framework Core
- Additional Tools: Custom middleware for global exception handling

## Code Tour

### Key Components

#### 1. Repository Pattern:

- Abstracts data access logic, promoting code reuse and separation from business logic.
- Implemented asynchronous methods (async/await) for efficient database operations.

#### 2. CQRS Pattern:

- Separates read (Query) and write (Command) operations, enhancing scalability and maintainability.
- Facilitates clear and concise service layer structure.

#### 3. Service Pattern:

- Encapsulates business logic, ensuring separation from the data access layer and the UI.
- Uses interfaces to define contracts for services, enabling loose coupling and easier testing.

#### 4. Global Exception Handling:

- Implemented through custom middleware in ASP.NET Core.
- Ensures consistent error responses and helps to keep controllers clean from try-catch blocks.

#### 5. React Components:

- Organized to handle different functionalities like stock selection, order preview, and order creation.
- Implements state management and hooks for reactive UI updates.

### Highlights

- Asynchronous Programming: Throughout the service and repository layers to ensure non-blocking I/O operations.
- Entity Framework Core: Used for the in-memory database to simulate real-world data interactions.
- Modular Design: Clear separation between layers and within components/services for easier maintenance and scalability.
