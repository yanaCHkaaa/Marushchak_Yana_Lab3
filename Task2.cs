using System;
using System.Collections.Generic;
using System.Linq;

//Продуктовий магазин.Визначити ієрархію товарів. Відсортувати товари по типам та по вартості.
//Знайти товари, термін придатності яких відповідає вказаному діапазону.
//Знайти прострочені товари, та товари, виготовлені у січні 2020.

namespace lab3_2
{
    class Product
    {
        public string type { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public double term { get; set; }
        public static int new_term1;
        public static int new_term2;
        public DateTime time { get; set; }
        public DateTime new_time { get; set; }
        public class SortPrice : IComparer<Product>
        {
            public int Compare(Product p1, Product p2)
            {
                if (p1.price > p2.price)
                    return 1;
                else if (p1.price < p2.price)
                    return -1;
                else
                    return 0;
            }
        }
        public static SortPrice SortPriceAscending()
        {
            return new SortPrice();
        }
        public class SortType : IComparer<Product>
        {
            public int Compare(Product p1, Product p2)
            {
                return p1.type.CompareTo(p2.type);
            }
        }
        public static SortType SortTypeAscending()
        {
            return new SortType();
        }



        public List<Product> ProductsList = new List<Product>();
        public void Add(Product product)
        {
            ProductsList.Add(product);
        }

        public void WriteTerm()
        {
            Console.WriteLine("Введiть діапазон терміну придатності: ");
            Console.Write("Перший: ");
            new_term1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Другий: ");
            new_term2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }

        public void Term()
        {
            Console.WriteLine("Потрібий термін придатності:");
            foreach (var t in ProductsList)
            {
                if (t.term > new_term1 && t.term < new_term2)
                {
                    Console.WriteLine($"{t.name} - {t.term} днів");
                }
            }
            Console.WriteLine();
        }

        public void BadTerm()
        {
            Console.WriteLine("Термін придатності сплив:");
            foreach (var i in ProductsList)
            {
                var time = new DateTime(i.year, i.month, i.day);
                var new_time = time.AddDays(i.term);
                var now = DateTime.Now;
                if (now > new_time)
                {
                    Console.WriteLine(i.name);
                }
            }
            Console.WriteLine();
        }

        public void January()
        {
            Console.WriteLine("Товари виготовлені в січні 2020");
            foreach (var jan in ProductsList)
            {
                if (jan.month == 1 && jan.year == 2020)
                {
                    Console.WriteLine(jan.name);
                }
            }
            Console.WriteLine();
        }

    }
    
    class DairyProduct : Product { }
    class MeatProduct : Product { }
    class Fruit : Product { }
    class Vegetable : Product { }
    class Water : Product { }
    class Bread : Product { }
    class Cereals : Product { }



    class Program
    {
        static void Main(string[] args)
        {
            var grocery = new Product();

            var milk = new DairyProduct
            {
                type = "молочні продукти",
                name = "Молоко",
                price = 25,
                year = 2022,
                month = 5,
                day = 25,
                term = 14
            };

            var cheese = new DairyProduct
            {
                type = "молочні продукти",
                name = "Сир",
                price = 78,
                year = 2022,
                month = 5,
                day = 1,
                term = 2
            };
            var chicken = new MeatProduct
            {
                type = "мясні продукти",
                name = "Курятина",
                price = 100,
                year = 2022,
                month = 3,
                day = 12,
                term = 3
            };
            var sausages = new MeatProduct
            {
                type = "мясні продукти",
                name = "Сосиски",
                price = 35,
                year = 2022,
                month = 5,
                day = 23,
                term = 20
            };
            var peach = new Fruit
            {
                type = "фрукти",
                name = "Персики",
                price = 40,
                year = 2022,
                month = 5,
                day = 20,
                term = 8
            };
            var grape = new Fruit
            {
                type = "фрукти",
                name = "Виноград",
                price = 55,
                year = 2022,
                month = 5,
                day = 26,
                term = 10
            };
            var tomato = new Vegetable
            {
                type = "овочі",
                name = "Помідор",
                price = 39,
                year = 2022,
                month = 4,
                day = 17,
                term = 4
            };
            var pepper = new Vegetable
            {
                type = "овочі",
                name = "Перець",
                price = 56,
                year = 2020,
                month = 1,
                day = 6,
                term = 11
            };
            var water = new Water
            {
                type = "вода",
                name = "Моршинська",
                price = 10,
                year = 2022,
                month = 2,
                day = 23,
                term = 200
            };
            var cola = new Water
            {
                type = "вода",
                name = "Coca-cola",
                price = 14,
                year = 2020,
                month = 1,
                day = 24,
                term = 180
            };
            var pie = new Bread
            {
                type = "хліб",
                name = "Пиріг",
                price = 25,
                year = 2022,
                month = 5,
                day = 27,
                term = 3
            };
            var grechka = new Cereals
            {
                type = "крупа",
                name = "Гречка",
                price = 40,
                year = 2022,
                month = 3,
                day = 15,
                term = 100
            };

            Product[] products = new Product[] { milk, cheese, chicken, sausages, peach, grape, tomato, pepper, water, cola, grechka, pie };
            Array.Sort(products, Product.SortPriceAscending());
            foreach (Product s in products)
                Console.WriteLine($"{s.price}-{s.name}");
            
            Console.WriteLine();
            
            Array.Sort(products, Product.SortTypeAscending());
            foreach (Product t in products)
                Console.WriteLine($"{t.type}-{t.name}");

            grocery.Add(milk);
            grocery.Add(cheese);
            grocery.Add(chicken);
            grocery.Add(sausages);
            grocery.Add(peach);
            grocery.Add(grape);
            grocery.Add(tomato);
            grocery.Add(pepper);
            grocery.Add(water);
            grocery.Add(cola);
            grocery.Add(grechka);
            grocery.Add(pie);
            grocery.WriteTerm();
            grocery.Term();
            grocery.BadTerm();
            grocery.January();

            Console.ReadKey();
        }
    }
}

