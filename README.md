# BlogManagement-CLI

A C# command-line application for managing blog entries, comments, and user interactions — built on .NET 7.

---

## Table of Contents

- [Overview](#overview)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Architecture](#architecture)
- [Planned Features](#planned-features)
- [Status](#status)

---

## Overview

BlogManagement-CLI is a terminal-based blog management system written in C#. It is designed around a clean layered architecture separating UI, application logic, and data concerns, with role-based access distinguishing regular users from administrators.

---

## Tech Stack

| | |
|---|---|
| Language | C# |
| Framework | .NET 7 |
| Interface | Console (CLI) |
| IDE | JetBrains Rider (`.idea` workspace included) |
| Nullable reference types | Enabled |
| Implicit usings | Enabled |

No external NuGet packages are currently referenced — the project relies solely on the .NET 7 base class libraries.

---

## Project Structure

```
BlogManagement-CLI/
└── BlogManagement-CLI/
    └── BlogManagement-CLI/
        ├── UI/
        │   └── Program.cs                          # Application entry point
        ├── ApplicationLogic/
        │   ├── Dashboard.cs                        # Dashboard logic (admin/user hub)
        │   ├── Authentication.cs                   # Login / auth flow
        │   ├── Services/
        │   │   └── BlogService.cs                  # Blog CRUD operations
        │   └── Validations/
        │       ├── Validation.cs                   # Base/shared validation logic
        │       └── UserValidation.cs               # User-specific input validation
        └── Database/
            ├── Models/
            │   ├── Common/
            │   │   └── Entity.cs                   # Base entity: Id + CreatedAt
            │   ├── User.cs                         # Regular user model
            │   └── Admin.cs                        # Admin user model
            ├── Enums/
            │   └── BlogStatus.cs                   # Blog post status enum (Draft, Published, etc.)
            └── Repository/
                ├── Common/
                │   └── Repository.cs               # Generic base repository
                └── UserRepository.cs               # User-specific data access
```

---

## Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)

### Run the application

```bash
git clone https://github.com/nqasanova/BlogManagement-CLI
cd BlogManagement-CLI/BlogManagement-CLI
dotnet run --project BlogManagement-CLI
```

### Build

```bash
dotnet build
```

---

## Architecture

The project is organized into three distinct layers:

### UI Layer (`UI/`)
The entry point (`Program.cs`) drives the console interface — handling menus, user input, and routing to the appropriate application logic.

### Application Logic Layer (`ApplicationLogic/`)
Contains the core business logic, split into focused classes:

- **`Authentication`** — Handles login, logout, and session state for users and admins.
- **`Dashboard`** — The main hub after login; routes the user to blog management, account settings, etc.
- **`BlogService`** — Responsible for all blog-related operations (create, read, update, delete posts, manage comments).
- **`Validation` / `UserValidation`** — Input validation helpers to keep controllers and services clean.

### Data Layer (`Database/`)
- **`Entity<TId>`** — Abstract base class all models inherit from, providing a generic `Id` and a `CreatedAt` timestamp defaulting to `DateTime.Now`.
- **`User` / `Admin`** — Domain models representing the two actor types in the system.
- **`BlogStatus`** — Enum for representing the lifecycle state of a blog post (e.g. Draft, Published, Archived).
- **`Repository` / `UserRepository`** — Data access layer following the Repository pattern, abstracting storage operations away from business logic.

---

## Features

- **User authentication** — Register, log in, and log out as a regular user or admin
- **Blog post management** — Create, edit, delete, and list blog posts with status tracking (Draft / Published / Archived)
- **Comment management** — Add and manage comments on blog posts
- **Role-based access** — Separate dashboards and permissions for users vs. admins
- **Input validation** — Validated forms for user registration and blog post creation
- **Repository pattern** — Clean separation between business logic and data storage
