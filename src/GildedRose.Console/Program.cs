using GildedRose.Console.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace GildedRose.Console
{
    class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            string filePath = "Items.json";

            //Load items from JSON
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
