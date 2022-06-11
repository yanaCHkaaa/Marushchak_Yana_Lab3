using System;
using System.Collections.Generic;
//using System.Linq;

//Створити об'єкт класу Зоряна система, використовуючи класи Планета, Зірка, Супутник.
//Методи: вивести на консоль кількість планет в зоряній системі, назва зірки, додавання планети в систему.

namespace lab3_1
{
    public class StarSystem
    {
        public string Name { get; set; }
        public override string? ToString()
        {
            return $"Зоряна система: {Name}";
        }
       
        public List<Planet> planetList = new List<Planet>();

        public void addPlanet(Planet planet)
        {
            planetList.Add(planet);
        }
        public void PrintPL()
        {
            Console.Write("Планети зоряної системи: ");
            foreach (var group in planetList)
                Console.Write(group.planet + ",  ");
            
            Console.WriteLine();
        }

        public Star star;
        public void AddStar (Star star)
        {
            this.star = star;
        }
    }
    public class Suputnyk
    {
        public string suputnyk { get; set; }
        public int count2 { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is Suputnyk suputnyk) return count2 == suputnyk.count2;
            return false;
        }
        public override int GetHashCode() => count2.GetHashCode();

    }
    public class Star
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Зiрка: {Name}";
        }
    }

    public class Planet
    {
        public string planet { get; set; }
        public int count1 { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is Planet planet) return count1 == planet.count1;
            return false;
        }
        public override int GetHashCode() => count1.GetHashCode();

        public List<Suputnyk> suputnykList = new List<Suputnyk>();

        public void addSuputnyk(Suputnyk suputnyk)
        {
            suputnykList.Add(suputnyk);
        }
        public void PrintS()
        {
            Console.Write("Супутники: ");
            foreach (var s in suputnykList)
                Console.Write(s.suputnyk + ",  ");

            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StarSystem starsystem = new StarSystem { Name = "Solar system" };
            starsystem.AddStar(new Star { Name = "Sun" }); 
            Planet planetsystem = new Planet();
            planetsystem.addSuputnyk(new Suputnyk { suputnyk = "Moon" });
            planetsystem.addSuputnyk(new Suputnyk { suputnyk = "Io" });
            planetsystem.addSuputnyk(new Suputnyk { suputnyk = "Europa" });
            planetsystem.addSuputnyk(new Suputnyk { suputnyk = "Calisto" });
            planetsystem.addSuputnyk(new Suputnyk { suputnyk = "Ganimedes" });
            starsystem.addPlanet(new Planet { planet = "Mercury" });
            starsystem.addPlanet(new Planet { planet = "Venus" });
            starsystem.addPlanet(new Planet { planet = "Earth" });
            starsystem.addPlanet(new Planet { planet = "Mars" });
            starsystem.addPlanet(new Planet { planet = "Jupiter" });
            starsystem.addPlanet(new Planet { planet = "Saturn" });
            starsystem.addPlanet(new Planet { planet = "Uranus" });
            starsystem.addPlanet(new Planet { planet = "Neptune" });

            var count1 = new Planet
            {
                count1 = starsystem.planetList.Count()
            };
            var count2 = new Suputnyk
            {
                count2 = planetsystem.suputnykList.Count()
            };

            printSystem();
            printStar();
            starsystem.PrintPL();
            planetsystem.PrintS();
            printCount();
            equals();

            void printSystem()
            {
                Console.WriteLine(starsystem.ToString());
            }
            void printStar()
            {
                Console.WriteLine(starsystem.star.ToString());
            }
            void printCount()
            {
                Console.WriteLine($"Кiлькiсть планет: {count1.count1}");
            }
            void equals()
            {
                bool planetcount = count1.Equals(count2);
                Console.WriteLine(planetcount);
                Console.WriteLine(count1.GetHashCode());
            }

            Console.ReadKey();
        }
    }
}