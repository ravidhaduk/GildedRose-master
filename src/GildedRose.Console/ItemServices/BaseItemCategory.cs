using GildedRose.Console.Models;
using System.Configuration;

namespace GildedRose.Console.ItemServices
{
    public abstract class BaseItemCategory
    {
        protected Item item;

        public BaseItemCategory(Item item)
        {
            this.item = item;
        }

        public abstract void UpdateQuality();

        protected void DecreaseQuality(int amount = 1)
        {
            if (item.Quality > 0)
            {
                item.Quality -= amount;
            }
        }

        protected void IncreaseQuality(int amount = 1)
        {
            var highestQuality = int.Parse(ConfigurationManager.AppSettings["HighestQuality"]);

            if (item.Quality + amount > highestQuality)
            {
                item.Quality = highestQuality;
            } else
            {
                item.Quality += amount;
            }
        }

        protected void DecreaseSellIn()
        {
            item.SellIn--;
        }
    }

}

