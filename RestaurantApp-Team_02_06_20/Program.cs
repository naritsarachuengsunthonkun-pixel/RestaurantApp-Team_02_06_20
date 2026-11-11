using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_Team_02_06_20
{
    class Restaurant
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Rating { get; set; }
    }

    internal class Program
    {
        static List<Restaurant> restaurants = new List<Restaurant>
    {
        new Restaurant { Name = "KFC", Type = "Fast Food", Rating = 4.2 },
        new Restaurant { Name = "MK", Type = "Suki", Rating = 4.7 },
        new Restaurant { Name = "Fuji", Type = "Japanese", Rating = 4.8 }
    };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== Restaurant Menu =====");
                Console.WriteLine("1. Add Restaurant");
                Console.WriteLine("2. Show Good Rating");
                Console.WriteLine("3. Show Summary");
                Console.WriteLine("4. Search By Type");
                Console.WriteLine("5. Delete Restaurant");
                Console.WriteLine("0. Exit");
                Console.Write("Select Menu: ");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        AddRestaurant();
                        break;
                    case "2":
                        ShowGoodRating();
                        break;
                    case "3":
                        ShowSummary();
                        break;
                    case "4":
                        SearchByType();
                        break;
                    case "5":
                        DeleteRestaurant();

                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid Menu");
                        break;
                }
            }
        }

        // คน A รับผิดชอบ
        static void AddRestaurant()
        {

        }

        // คน B รับผิดชอบ
        static void ShowGoodRating()
        {
            const double goodRating = 4.5;

            var good = restaurants
                .Where(r => r.Rating >= goodRating)
                .OrderByDescending(r => r.Rating)
                .ToList();

            Console.WriteLine($"\n--- Good Rating (>= {goodRating:F1}) ---");

            if (good.Count == 0)
            {
                Console.WriteLine("No restaurants with good rating.");
                return;
            }

            Console.WriteLine($"{"Name",-15} {"Type",-12} {"Rating"}");
            Console.WriteLine(new string('-', 36));

            foreach (var r in good)
            {
                Console.WriteLine($"{r.Name,-15} {r.Type,-12} {r.Rating:F1}");
            }

            Console.WriteLine($"\nTotal: {good.Count} restaurant(s)");
        }

        // คน C รับผิดชอบ
        static void ShowSummary()
        {
            if (restaurants.Count == 0)
            {
                Console.WriteLine("No restaurants to summarize.");
                return;
            }

            var best = restaurants.OrderByDescending(r => r.Rating).First();

            Console.WriteLine("\n--- Summary ---");
            Console.WriteLine($"Total restaurants : {restaurants.Count}");
            Console.WriteLine($"Average rating    : {restaurants.Average(r => r.Rating):F2}");
            Console.WriteLine($"Highest rated     : {best.Name} ({best.Rating:F1})");

            Console.WriteLine("\nCount by type:");
            foreach (var group in restaurants.GroupBy(r => r.Type))
            {
                Console.WriteLine($"  {group.Key}: {group.Count()}");
            }
        }


        static void SearchByType()
        {
            Console.WriteLine("Not completed");
        }


        static void DeleteRestaurant()
        {
            Console.WriteLine("Not completed");
        }
    }

}
