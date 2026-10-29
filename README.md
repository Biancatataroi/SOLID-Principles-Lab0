# Technical University of Moldova
**Faculty of Computers, Informatics and Microelectronics (FCIM)**

# Laboratory Work No. 0
## Student Grade Management System
### Implementation of SOLID Principles in C#

**Student:** Tataroi Bianca-Andreea  
**Academic Group:** FAF-242  
**Discipline:** TMPS   
**Implemented Principles:** SRP, OCP, DIP

---


## 1. Objective

The objective of this laboratory work is to develop a simple C# application using Object-Oriented Programming (OOP) and demonstrate the implementation of three SOLID principles:

- Single Responsibility Principle (SRP)
- Open/Closed Principle (OCP)
- Dependency Inversion Principle (DIP)

## 2. Project Description

The Student Grade Management System is a console application developed in C# using .NET 10.

The application allows users to manage students and their academic grades through a simple interactive menu.

The main functionalities are:

1. View existing students.
2. Add a new student.
3. Assign grades to students.
4. View students' grades and calculate results.
5. Exit the application.

Student information and grades are stored in memory using lists. No database is required.

## 3. Project Structure

The application contains three files:

- **Program.cs** — The entry point of the application. Displays the menu, reads user input, and calls the required methods.
- **GradeSystem.cs** — Contains the classes and interfaces responsible for managing students, storing grades, and calculating results.
- **StudentGrades_Simple.csproj** — Contains the project configuration and specifies .NET 10 as the target framework.

## 4. Implementation of SOLID Principles

### 4.1. Single Responsibility Principle (SRP)

The Single Responsibility Principle states that a class should have only one main responsibility.

In this project:

- `Student` stores student information and grades.
- `GradeManager` manages students and their grades.
- `AverageCalculator` calculates the average grade.
- `HighestCalculator` determines the highest grade.

The responsibilities are separated into different classes, making the program easier to understand and maintain.

### 4.2. Open/Closed Principle (OCP)

The Open/Closed Principle states that software classes should be open for extension but closed for modification.

The application implements the `IGradeCalculator` interface, which can have multiple implementations:

- `AverageCalculator` calculates the average of the grades.
- `HighestCalculator` returns the highest grade.

New calculation methods can be added by creating another class that implements `IGradeCalculator`, without modifying the calculation logic inside `GradeManager`.

### 4.3. Dependency Inversion Principle (DIP)

The Dependency Inversion Principle states that high-level modules should depend on abstractions rather than concrete implementations.

The `GradeManager` class receives an `IGradeCalculator` object through its constructor.

This allows the application to use different grade calculators without modifying the `GradeManager` class.

Dependency injection makes the program more flexible and easier to extend.

## 5. Testing and Results

The application can be executed in the VS Code terminal using:

```bash
dotnet run
```

The following test scenario demonstrates the main functionality:

1. Add a new student with ID `3` and name `Maria Ionescu`.
2. Assign grades `9` and `7` to the student.
3. Display the student's grades.
4. Calculate the average.

Expected result:

```text
Student: Maria Ionescu
Grades: 9, 7
Result: 8.00
```

To demonstrate the Open/Closed Principle, the calculator can be changed from `AverageCalculator` to `HighestCalculator` in `Program.cs`.

With the same grades, the highest-grade calculator returns:

```text
Result: 9.00
```

This demonstrates how different calculation strategies can be used without modifying `GradeManager`.

## 6. Conclusion

During this laboratory work, a Student Grade Management System was developed in C# to demonstrate three SOLID principles: SRP, OCP, and DIP.

The application separates student management from grade calculations, supports different calculation methods, and uses an interface to reduce dependencies between classes.

Through this laboratory, I gained a better understanding of classes, objects, interfaces, and dependency injection in Object-Oriented Programming.

Applying SOLID principles helps make software more organized, maintainable, flexible, and easier to extend in the future.