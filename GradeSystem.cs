using System;
using System.Collections.Generic;
using System.Linq;

// SRP - This class only holds student information and grades
public class Student
{
    public int Id { get; }
    public string Name { get; }
    public List<int> Grades { get; } = new();

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

// OCP - we can add a new grade calculator without changing GradeManager.
public interface IGradeCalculator
{
    double Calculate(List<int> grades);
}

public class AverageCalculator : IGradeCalculator
{
    public double Calculate(List<int> grades)
    {
        return grades.Average();
    }
}

public class HighestCalculator : IGradeCalculator
{
    public double Calculate(List<int> grades)
    {
        return grades.Max();
    }
}

// DIP-GradeManager depends on the interface, not on AverageCalculator
// SRP-GradeManager handles grade operations, not menu input or calculations
public class GradeManager
{
    private readonly IGradeCalculator _calculator;

    public GradeManager(IGradeCalculator calculator)
    {
        _calculator = calculator;
    }

    public void AddGrade(Student student, int grade)
    {
        student.Grades.Add(grade);
    }

    public double GetResult(Student student)
    {
        return _calculator.Calculate(student.Grades);
    }
}
