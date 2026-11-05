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
            Console.WriteLine("Not completed");
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
            Console.Write("Type to search: ");
            string type = Console.ReadLine();

            var found = restaurants
                .Where(r => r.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (found.Count == 0)
            {
                Console.WriteLine("No restaurants found.");
                return;
            }

            Console.WriteLine($"Restaurants of type '{type}':");
            foreach (var r in found)
                Console.WriteLine($"- {r.Name} : {r.Rating}");
        }


        static void DeleteRestaurant()
        {
            Console.Write("Name to delete: ");
            string name = Console.ReadLine();

            int removed = restaurants.RemoveAll(
                r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine(removed > 0 ? "Deleted." : "Restaurant not found.");
        }
    }

}
