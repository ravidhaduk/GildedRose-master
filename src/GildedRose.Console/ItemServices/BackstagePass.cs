using GildedRose.Console.ItemServices;
using GildedRose.Console.Models;

namespace GildedRose.Console.ItemCategories
{
    public class BackstagePass : BaseItemCategory
    {
        public BackstagePass(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            if (item.SellIn > 10)
            {
                IncreaseQuality();
            }
            else if (item.SellIn > 5)
            {
                IncreaseQuality(2);
            }
            else if (item.SellIn > 0)
            {
                IncreaseQuality(3);
            }
            else
            {
                item.Quality = 0; 
            }

            DecreaseSellIn();
        }
    }

}
