using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseTest : BaseGildedRoseTest
    {
        [Fact]
        public void AgedBrie_IncreasesInQuality()
        {
            var item = Items.Find(i => i.Name == "Aged Brie");

            App.UpdateQuality();

            Assert.Equal(1, item.Quality);
        }

        [Fact]
        public void Sulfuras_DoesNotChangeInQuality()
        {
            var item = Items.Find(i => i.Name == "Sulfuras, Hand of Ragnaros");

            App.UpdateQuality();

            Assert.Equal(80, item.Quality);
            Assert.Equal(0, item.SellIn);
        }

        [Fact]
        public void BackstagePasses_IncreaseInQualityBy1_WhenMoreThan10DaysLeft()
        {
            var item = Items.Find(i => i.Name == "Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 11;
            item.Quality = 20;

            App.UpdateQuality();

            Assert.Equal(21, item.Quality);
            Assert.Equal(10, item.SellIn);
        }

        [Fact]
        public void BackstagePasses_IncreaseInQualityBy2_When10DaysOrLessLeft()
        {
            var item = Items.Find(i => i.Name == "Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 10;
            item.Quality = 20;

            App.UpdateQuality();

            Assert.Equal(22, item.Quality);
            Assert.Equal(9, item.SellIn);
        }

        [Fact]
        public void BackstagePasses_IncreaseInQualityBy3_When5DaysOrLessLeft()
        {
            var item = Items.Find(i => i.Name == "Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 5;
            item.Quality = 20;

            App.UpdateQuality();

            Assert.Equal(23, item.Quality);
            Assert.Equal(4, item.SellIn);
        }

        [Fact]
        public void BackstagePasses_QualityDropsToZero_AfterConcert()
        {
            var item = Items.Find(i => i.Name == "Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 0;
            item.Quality = 20;

            App.UpdateQuality();

            Assert.Equal(0, item.Quality);
            Assert.Equal(-1, item.SellIn);
        }

        [Fact]
        public void BackstagePasses_QualityDoesNotExceed50()
        {
            var item = Items.Find(i => i.Name == "Backstage passes to a TAFKAL80ETC concert");
            item.SellIn = 5;
            item.Quality = 49;

            App.UpdateQuality();

            Assert.Equal(50, item.Quality); 
            Assert.Equal(4, item.SellIn);
        }

        [Fact]
        public void ConjuredItems_DegradeTwiceAsFast()
        {
            var item = Items.Find(i => i.Name.StartsWith("Conjured"));

            App.UpdateQuality();

            Assert.Equal(4, item.Quality);
            Assert.Equal(2, item.SellIn);
        }

        [Fact]
        public void RegularItem_QualityDecreases()
        {
            var item = Items.Find(i => i.Name == "Elixir of the Mongoose");

            App.UpdateQuality();

            Assert.Equal(6, item.Quality);
            Assert.Equal(4, item.SellIn);
        }
    }
}
