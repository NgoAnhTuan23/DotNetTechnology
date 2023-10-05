using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class Program
{
    static void Main()
    {
        // 1. Tạo danh sách các đối tượng Person
        List<Person> people = new List<Person>
        {
            new Person("Tuan", 20),
            new Person("Phat", 19),
            new Person("Kiet", 35),
            new Person("An", 41),
            new Person("Hung", 30)
        };

        // 2. Sử dụng lambda expressions để lọc người có tuổi trên 30
        var peopleOver30 = people.Where(person => person.Age > 30);

        Console.WriteLine("People older than 30:");
        foreach (var person in peopleOver30)
        {
            Console.WriteLine($"{person.Name}, Age: {person.Age}");
        }
        Console.WriteLine("=======================");

        // 3. Sử dụng lambda expressions để sắp xếp danh sách theo tuổi
        var sortedPeople = people.OrderBy(person => person.Age);

        Console.WriteLine("\nSorted by age:");
        foreach (var person in sortedPeople)
        {
            Console.WriteLine($"{person.Name}, Age: {person.Age}");
        }
        Console.WriteLine("=======================");

        // 4. Sử dụng lambda expressions để chọn ra danh sách các tên từ danh sách Person
        var namesList = people.Select(person => person.Name).ToList();

        Console.WriteLine("\nList of Names:");
        foreach (var name in namesList)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine("=======================");

        var ageList = people.Select(person => person.Age).ToList();
        foreach (var age in ageList)
        {
            Console.WriteLine(age);
        }
        Console.WriteLine("=======================");
    }
}
