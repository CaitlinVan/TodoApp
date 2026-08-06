# To-Do App

A desktop To-Do application built with **C#**, **Avalonia UI**, and **PostgreSQL** (running in Docker). This project was primarily created to gain hands-on experience with the **MVVM (Model-View-ViewModel)** architecture and explore a more UI-focused design compared to my previous layered architecture projects.

## Technologies

* C#
* .NET
* Avalonia UI
* MVVM Architecture
* PostgreSQL
* Docker
* CommunityToolkit.Mvvm (`RelayCommand`)

## Architecture

Unlike my previous projects, which use a traditional layered architecture (three-layered), this application follows the **MVVM pattern**.

The goal was to become comfortable separating the user interface from application logic through data binding and commands. Avalonia's support for MVVM made it a natural choice for this project.

## Planning & Design

Before implementation, I planned the application by defining both functional and non-functional requirements using the **MoSCoW prioritisation method**.

From these requirements, I designed an **Entity Relationship (ER) Diagram** to model the application's data structure before building the database.

The attached requirement document and ER diagram show the design process used before development began.

## Development Process

Development was split into two major versions:

* **Version 1 (V1)** – Core functionality ("Must Have" requirements)
* **Version 2 (V2)** – Additional "Should Have" and "Could Have" features

Using separate branches allowed new functionality to be developed without affecting the stable implementation.

## Highlights

### MVVM with `RelayCommand`

The application uses `RelayCommand` from CommunityToolkit.Mvvm to bind UI actions directly to ViewModel commands.

This keeps business logic out of the code-behind and allows the interface to remain driven entirely through bindings.

### PostgreSQL with Docker

The application's data is stored in PostgreSQL running inside a Docker container.

Using Docker makes the development environment reproducible and simplifies database setup across different machines.

### Data Binding Behaviour

While implementing inline list renaming, I encountered an interesting MVVM behaviour.

Because `TextBox.Text` uses two-way binding by default, changes are immediately reflected in the ViewModel before they are explicitly saved to the database. This highlighted the distinction between application state and persisted data, and demonstrated the importance of designing clear save/cancel workflows in data-driven applications.

### Avalonia UI

During development I encountered several Avalonia-specific behaviours, particularly around bindings and UI visibility, which required adapting the implementation to fit the framework's capabilities.

## What I Learned

This project provided practical experience with:

* Building applications using the MVVM architecture
* Data binding in Avalonia
* Command-based UI interactions
* Separating presentation logic from business logic
* Working with PostgreSQL in Docker
* Designing applications from requirements and ER diagrams before implementation

## Future Improvements

* Drag-and-drop task organisation
* Due dates and reminders
* Search and filtering
* Task priorities
* Labels and categories
* Improved validation and undo/cancel functionality for editing

## ER-Diagram and Requirement list (MoSCow of functional and non-functional requirements):

[To Do (Side-project 2).docx](https://github.com/user-attachments/files/30543965/To.Do.Side-project.2.docx)

## Screenshots 

Start screen:

<img width="1950" height="1074" alt="image" src="https://github.com/user-attachments/assets/fa36de7a-4dfd-4a36-a094-de51d7eb22c8" />



