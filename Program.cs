using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketApp
{
    public class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }

        public Item(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Name} ({Weight} kg)";
        }
    }

    public class BasketResult
    {
        public List<Item> SelectedItems { get; set; } = new();
        public double TotalWeight => SelectedItems.Sum(i => i.Weight);
        public string Message { get; set; } = string.Empty;
    }

    public class Basket
    {
        public const double MaxWeight = 20.0;

        public BasketResult FillBasket(List<Item> shoppingList)
        {
            if (shoppingList == null)
                throw new ArgumentNullException(nameof(shoppingList));

            var result = new BasketResult();

            if (shoppingList.Count == 0)
            {
                result.Message = "The shopping list is empty.";
                return result;
            }

            var validItems = shoppingList
                .Where(item => item != null && item.Weight > 0 && item.Weight <= MaxWeight)
                .OrderByDescending(item => item.Weight)
                .ToList();

            double currentWeight = 0;

            foreach (var item in validItems)
            {
                if (currentWeight + item.Weight <= MaxWeight)
                {
                    result.SelectedItems.Add(item);
                    currentWeight += item.Weight;
                }
            }

            result.Message = result.SelectedItems.Count > 0
                ? "The basket has been successfully filled."
                : "No valid items could be added to the basket.";

            return result;
        }
    }

class Program
    {
        static void Main()
        {
            var basket = new Basket();

            var regularItems = new List<Item>
        {
            new Item("Milk", 1.5),
            new Item("Watermelon", 5.0),
            new Item("Cheese", 0.8),
            new Item("Rice", 10.0),
            new Item("Flour", 3.0),
            new Item("Tomatoes", 2.0),
            new Item("Oil", 4.5),
            new Item("Sugar", 1.2)
        };

            Console.WriteLine(" Test 1: Regular shopping list --> Expected result: 3 items");
            ShowBasketResult(basket.FillBasket(regularItems));
            Console.WriteLine();

            Console.WriteLine(" Test 2: Empty shopping list ---> Expected result: 0 items");
            ShowBasketResult(basket.FillBasket(new List<Item>()));
            Console.WriteLine();

            var problematicItems = new List<Item>
        {
            new Item("Anvil", 30),
            new Item("Balloon", -1),
            new Item("Nothing", 0),
            null
        };

            Console.WriteLine("Test 3: List with invalid items ---> Expected result: 0 items");
            ShowBasketResult(basket.FillBasket(problematicItems));
            Console.WriteLine();

            var oversizedItems = new List<Item>
        {
            new Item("Fridge", 25),
            new Item("Couch", 50)
        };

            Console.WriteLine("Test 4: All items too heavy ---> Expected result: 0 items");
            ShowBasketResult(basket.FillBasket(oversizedItems));
            Console.WriteLine();
        }

        static void ShowBasketResult(BasketResult result)
        {
            Console.WriteLine(result.Message);

            if (result.SelectedItems.Count == 0)
            {
                Console.WriteLine("No items were added to the basket.");
            }
            else
            {
                Console.WriteLine("Items in the basket:");
                foreach (var item in result.SelectedItems)
                {
                    Console.WriteLine($" - {item}");
                }

                Console.WriteLine($"Total weight: {result.TotalWeight} kg");
            }
        }
    }

}