using GildedRose.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (item.Quality < 50)
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

