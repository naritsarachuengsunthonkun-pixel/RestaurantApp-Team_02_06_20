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
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid Menu");
                        break;
                }
            }
        }

        static void AddRestaurant()
        {
            Console.Write("Restaurant name: ");
            string name = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }

            Console.Write("Type (e.g. Fast Food, Japanese): ");
            string type = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(type))
            {
                Console.WriteLine("Type cannot be empty.");
                return;
            }

            Console.Write("Rating (0 - 5): ");
            if (!double.TryParse(Console.ReadLine(), out double rating) || rating < 0 || rating > 5)
            {
                Console.WriteLine("Invalid rating. Please enter a number between 0 and 5.");
                return;
            }

            restaurants.Add(new Restaurant { Name = name, Type = type, Rating = rating });
            Console.WriteLine($"Added {name} successfully.");
        }

        // คน B รับผิดชอบ
        const double GoodRatingThreshold = 4.5;

        static void ShowGoodRating()
        {
            var good = restaurants
                .Where(r => r.Rating >= GoodRatingThreshold)
                .OrderByDescending(r => r.Rating)
                .ToList();

            Console.WriteLine($"\n--- Restaurants with rating >= {GoodRatingThreshold} ---");

            if (good.Count == 0)
            {
                Console.WriteLine("No restaurants found.");
                return;
            }

            foreach (var r in good)
            {
                Console.WriteLine($"{r.Name} ({r.Type}) - {r.Rating:F1}");
            }
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
    }

}
