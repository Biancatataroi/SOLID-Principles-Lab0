using System;
using System.Collections.Generic;

List<Student> students = new()
{
    new Student(1, "Ana Popescu"),
    new Student(2, "Alex Rusu")
};

GradeManager manager = new GradeManager(new AverageCalculator());

while (true)
{
    Console.WriteLine("\n=== STUDENT GRADE SYSTEM ===");
    Console.WriteLine("1. View students");
    Console.WriteLine("2. Add student");
    Console.WriteLine("3. Add grade");
    Console.WriteLine("4. View grades and average");
    Console.WriteLine("0. Exit");
    Console.Write("Choose: ");
    string? choice = Console.ReadLine();

    if (choice == "0") break;

    if (choice == "1")
    {
        foreach (Student student in students)
            Console.WriteLine($"{student.Id}: {student.Name}");
    }
    else if (choice == "2")
    {
        Console.Write("Student name: ");
        string name = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty.");
            continue;
        }
        int newId = students.Count == 0 ? 1 : students[^1].Id + 1;
        students.Add(new Student(newId, name));
        Console.WriteLine($"Student added with ID {newId}.");
    }
    else if (choice == "3" || choice == "4")
    {
        Console.Write("Student ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Please enter a valid number.");
            continue;
        }
        Student? student = students.Find(s => s.Id == id);
        if (student == null)
        {
            Console.WriteLine("Student not found.");
            continue;
        }

        if (choice == "3")
        {
            Console.Write("Grade (1-10): ");
            if (!int.TryParse(Console.ReadLine(), out int grade) || grade < 1 || grade > 10)
            {
                Console.WriteLine("Grade must be a number from 1 to 10.");
                continue;
            }
            manager.AddGrade(student, grade);
            Console.WriteLine("Grade added successfully.");
        }
        else
        {
            if (student.Grades.Count == 0)
            {
                Console.WriteLine("This student has no grades yet.");
                continue;
            }
            Console.WriteLine($"Student: {student.Name}");
            Console.WriteLine("Grades: " + string.Join(", ", student.Grades));
            Console.WriteLine($"Result: {manager.GetResult(student):F2}");
        }
    }
    else
    {
        Console.WriteLine("Invalid option.");
    }
}
