using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using GildedRose.Console.ItemCategories;
using GildedRose.Console.Models;
using GildedRose.Console.ItemServices;

namespace GildedRose.Console.Actions
{
    public class GildedRose
    {
        private IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var category = GetItemCategory(item);
                category.UpdateQuality();
            }
        }

        private BaseItemCategory GetItemCategory(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrie(item);
                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePass(item);
                case string name when name.StartsWith("Conjured"):
                    return new ConjuredItem(item);
                default:
                    return new RegularItem(item);
            }
        }
    }

}
