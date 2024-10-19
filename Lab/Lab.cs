using System;
using System.Collections.Generic;

public class Employee
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Position { get; set; }

    public Employee(string name, int id, string position)
    {
        Name = name;
        Id = id;
        Position = position;
    }

    public virtual decimal CalculateSalary() => 0;
}

public class Worker : Employee
{
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public Worker(string name, int id, decimal hourlyRate, int hoursWorked)
        : base(name, id, "Рабочий")
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public override decimal CalculateSalary() => HourlyRate * HoursWorked;
}

public class Manager : Employee
{
    public decimal FixedSalary { get; set; }
    public decimal Bonus { get; set; }

    public Manager(string name, int id, decimal fixedSalary, decimal bonus)
        : base(name, id, "Менеджер")
    {
        FixedSalary = fixedSalary;
        Bonus = bonus;
    }

    public override decimal CalculateSalary() => FixedSalary + Bonus;
}

public class Program
{
    public static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Worker("Алексей", 1, 500, 40),
            new Manager("Марина", 2, 30000, 5000)
        };

        foreach (var employee in employees)
        {
            Console.WriteLine($"Сотрудник: {employee.Name}, Должность: {employee.Position}, Зарплата: {employee.CalculateSalary()} руб.");
        }
    }
}
