using GildedRose.Console.ItemServices;
using GildedRose.Console.Models;

namespace GildedRose.Console.ItemCategories
{
    public class RegularItem : BaseItemCategory
    {
        public RegularItem(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            DecreaseQuality();
            DecreaseSellIn();

            if (item.SellIn < 0)
            {
                DecreaseQuality();
            }
        }
    }

}
