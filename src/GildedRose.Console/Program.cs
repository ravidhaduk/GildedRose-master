using GildedRose.Console.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GildedRose.Console
{
    class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            string filePath = "Items.json";
            System.Console.WriteLine("Current Directory: " + Directory.GetCurrentDirectory());

            IList<Item> Items = LoadItems(filePath);

            var app = new Actions.GildedRose(Items);
            app.UpdateQuality();
        
        }

        private static IList<Item> LoadItems(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file {filePath} does not exist.");
            }

            string jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Item>>(jsonData);
        }

    }

}
