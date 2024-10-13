using GildedRose.Console.ItemServices;
using GildedRose.Console.Models;

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
