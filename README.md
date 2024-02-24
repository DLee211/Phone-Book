# Phone Book Application using Entity Framework

## Introduction
Welcome to the Phone Book Application using Entity Framework in the .NET ecosystem. This projects uses the basics of Entity Framework. The project involves creating a simple Phone Book application where users can perform operations such as Add, Delete, Update, and Read contacts with their phone numbers.

## Project Overview
This project implements a console-based application to interact with a database using Entity Framework. The main functionalities include:

1. **Add Contact:** Users can add new contacts with their name, email, and phone number. The application validates email and phone number formats.

2. **Delete Contact:** Contacts can be deleted from the database.

3. **Update Contact:** Users can update the information of existing contacts.

4. **Read Contacts:** The application allows users to view the list of contacts stored in the database.

## Code Structure
The project follows the Code-First Approach, meaning that Entity Framework will generate the database schema based on the code. It utilizes a base `Contact` class with properties such as `Id`, `Name`, `Email`, and `PhoneNumber`. The application ensures the validation of email and phone number formats, providing feedback to users about the expected formats.

## Requirements
To run this application, make sure you have the following:

- .NET SDK installed on your machine.
- SQL Server for the database (ensure the connection string is correctly configured in the project).

## Getting Started
1. Clone or download the repository to your local machine.
2. Open the project in your preferred C# development environment (Visual Studio, VS Code, etc.).
3. Configure the connection string to point to your SQL Server instance.
4. Run the application and follow the console prompts to perform various operations on the Phone Book.

## Technologies Used
- C# programming language
- Entity Framework for data access
- SQL Server for database storage

## Notes
- The application uses a Code-First Approach, allowing Entity Framework to create the database schema based on the defined classes.
