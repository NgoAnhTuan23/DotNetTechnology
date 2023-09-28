using System;
using System.Collections.Generic;
using System.Linq;

abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Species { get; set; }

    public Animal(string name, int age, string species)
    {
        Name = name;
        Age = age;
        Species = species;
    }

    public abstract void MakeSound();
}

class Mammal : Animal
{
    public int NumberOfLegs { get; set; }

    public Mammal(string name, int age, string species, int numberOfLegs)
        : base(name, age, species)
    {
        NumberOfLegs = numberOfLegs;
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name}, a mammal, makes a mammal-specific sound.");
    }

    public virtual void GiveBirth()
    {
        Console.WriteLine($"{Name}, a mammal, gives birth.");
    }
}

interface IFlyable
{
    void Fly();
}

class Bird : Animal, IFlyable
{
    public double Wingspan { get; set; }

    public Bird(string name, int age, string species, double wingspan)
        : base(name, age, species)
    {
        Wingspan = wingspan;
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name}, a bird, makes a bird-specific sound.");
    }

    public void Fly()
    {
        Console.WriteLine($"{Name}, a bird, is flying with a wingspan of {Wingspan} units.");
    }
}

class Reptile : Animal
{
    public bool IsVenomous { get; set; }

    public Reptile(string name, int age, string species, bool isVenomous)
        : base(name, age, species)
    {
        IsVenomous = isVenomous;
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name}, a reptile, makes a reptile-specific sound.");
    }
}

class ZooKeeper
{
    private List<Animal> animals = new List<Animal>();

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
    }

    public void RemoveAnimal(string animalName)
    {
        animals.RemoveAll(animal => animal.Name == animalName);
    }

    public Animal FindAnimal(string animalName)
    {
        return animals.FirstOrDefault(animal => animal.Name == animalName);
    }

    public List<Animal> FilterAnimals(Func<Animal, bool> criteria)
    {
        return animals.Where(criteria).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ZooKeeper zooKeeper = new ZooKeeper();

        // Instantiate various animals
        Animal lion = new Mammal("Simba", 5, "Lion", 4);
        Animal eagle = new Bird("Eddie", 3, "Eagle", 6.5);
        Animal snake = new Reptile("Slytherin", 2, "Snake", true);

        // Add animals to the zoo
        zooKeeper.AddAnimal(lion);
        zooKeeper.AddAnimal(eagle);
        zooKeeper.AddAnimal(snake);

        // Demonstrate attributes and behaviors of animals
        lion.MakeSound();
        ((Mammal)lion).GiveBirth();

        eagle.MakeSound();
        ((IFlyable)eagle).Fly();

        snake.MakeSound();

        // Manage animals using ZooKeeper
        Console.WriteLine("Animals in the zoo:");
        foreach (var animal in zooKeeper.FilterAnimals(_ => true))
        {
            Console.WriteLine($"Name: {animal.Name}, Species: {animal.Species}");
        }

        zooKeeper.RemoveAnimal("Eddie");

        Console.WriteLine("Animals in the zoo after removing Eddie:");
        foreach (var animal in zooKeeper.FilterAnimals(_ => true))
        {
            Console.WriteLine($"Name: {animal.Name}, Species: {animal.Species}");
        }
    }
}
