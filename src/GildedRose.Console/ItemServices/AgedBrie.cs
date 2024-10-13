using GildedRose.Console.ItemServices;
using GildedRose.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.ItemCategories
{
    public class AgedBrie : BaseItemCategory
    {
        public AgedBrie(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            IncreaseQuality();
            DecreaseSellIn();

            if (item.SellIn < 0)
            {
                IncreaseQuality();
            }
        }
    }

}
