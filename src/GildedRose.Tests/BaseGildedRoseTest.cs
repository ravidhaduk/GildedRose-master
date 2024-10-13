using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text.Json;
using GildedRose.Console.Models;

namespace GildedRose.Tests
{
    public abstract class BaseGildedRoseTest
    {
        protected List<Item> Items;
        protected Console.Actions.GildedRose App;

        public BaseGildedRoseTest()
        {
            ConfigurationManager.AppSettings["HighestQuality"] = "50";
            
            LoadItemsFromJson("TestData/items.json");
            
            App = new Console.Actions.GildedRose(Items);
        }

        private void LoadItemsFromJson(string filePath)
        {
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"The file {filePath} does not exist.");
            }

            string jsonData = File.ReadAllText(fullPath);
            Items = JsonSerializer.Deserialize<List<Item>>(jsonData);
        }
    }
}
