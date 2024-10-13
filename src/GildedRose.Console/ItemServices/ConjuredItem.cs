using GildedRose.Console.ItemServices;
using GildedRose.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.ItemCategories
{
    public class ConjuredItem : BaseItemCategory
    {
        public ConjuredItem(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            DecreaseQuality(2);
            DecreaseSellIn();

            if (item.SellIn < 0)
            {
                DecreaseQuality(2); 
            }
        }
    }

}
