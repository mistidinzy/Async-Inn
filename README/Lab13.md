# Async Inn

## Lab 13 - Dependency Injection & Repository Design Pattern

> ## [Home](../README.md)

---

### Problem Domain

Building off of your current project, refactor your project to allow and implement dependency injection.

We want to keep the current behavior of our API server the same, only refactoring the architecture.

---

### Application Specifications

***Repository Design Pattern***

> 1. Using Dependency Injection, refactor your `Hotels`, `Rooms`, and `Amenities Controllers` to depend on an interface, rather than the DbContext.
>
> 2. Build an interface for each of the controllers, that contains the required method signatures to all for CRUD operations to the database directly.
>
> 3. Update each of the controllers to inject the interface, rather than the DBContext.
>
> 4. Create a service for each of the controllers, that implements the appropriate interface.
>
> 5. Build out the logic to satisfy the interface, by making the appropriate calls to the db for each action.
>
> 6. Update each Controller to use the appropriate method from the interface, rather than the DBContext directly.
>
> 7. Confirm in **POSTMAN** that your controllers are returning the same logic as they did in Lab 12.

---
