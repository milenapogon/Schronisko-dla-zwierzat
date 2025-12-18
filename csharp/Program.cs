using System;
using System.Collections.Generic;

class Animal
{
    public string Name;
    public string Species;
    public bool Adopted = false;

    public Animal(string name, string species)
    {
        Name = name;
        Species = species;
    }
}

class Volunteer
{
    public string Name;

    public Volunteer(string name)
    {
        Name = name;
    }
}

class Adoption
{
    public Animal Animal;
    public Volunteer Volunteer;

    public Adoption(Animal animal, Volunteer volunteer)
    {
        Animal = animal;
        Volunteer = volunteer;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<Animal> animals = new List<Animal>();
        List<Volunteer> volunteers = new List<Volunteer>();
        List<Adoption> adoptions = new List<Adoption>();

        while (true)
        {
            Console.WriteLine("\n SCHRONISKO DLA ZWIERZĄT ");
            Console.WriteLine("1. Dodaj zwierzę");
            Console.WriteLine("2. Dodaj wolontariusza");
            Console.WriteLine("3. Adoptuj zwierzę");
            Console.WriteLine("4. Lista zwierząt");
            Console.WriteLine("0. Wyjście");

            Console.Write("Wybierz opcję: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Imię pupila: ");
                string name = Console.ReadLine();
                Console.Write("Gatunek: ");
                string species = Console.ReadLine();
                animals.Add(new Animal(name, species));
                Console.WriteLine("Pupil dodany.");
            }
            else if (choice == "2")
            {
                Console.Write("Imię wolontariusza: ");
                string name = Console.ReadLine();
                volunteers.Add(new Volunteer(name));
                Console.WriteLine("Wolontariusz dodany.");
            }
            else if (choice == "3")
            {
                if (animals.Count == 0 || volunteers.Count == 0)
                {
                    Console.WriteLine("Brak zwierząt lub wolontariuszy.");
                }
                else
                {
                    for (int i = 0; i < animals.Count; i++)
                    {
                        string status = animals[i].Adopted ? "adoptowane" : "dostępne";
                        Console.WriteLine(i + ". " + animals[i].Name + " - " + animals[i].Species + " - " + status);
                    }

                    Console.Write("Podaj numer zwierzęcia: ");
                    int index = Convert.ToInt32(Console.ReadLine());

                    if (animals[index].Adopted)
                    {
                        Console.WriteLine("To zwierzę jest już adoptowane.");
                    }
                    else
                    {
                        animals[index].Adopted = true;
                        adoptions.Add(new Adoption(animals[index], volunteers[0]));
                        Console.WriteLine("Adopcja zakończona sukcesem!");
                    }
                }
            }
            else if (choice == "4")
            {
                foreach (Animal a in animals)
                {
                    string status = a.Adopted ? "adoptowane" : "dostępne";
                    Console.WriteLine(a.Name + " - " + a.Species + " - " + status);
                }
            }
            else if (choice == "0")
            {
                Console.WriteLine("Dziękujemy, do widzenia!");
                break;
            }
            else
            {
                Console.WriteLine("Nieprawidłowy wybór");
            }
        }
    }
}
