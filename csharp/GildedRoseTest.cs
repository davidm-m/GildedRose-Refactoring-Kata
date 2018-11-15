using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void ItemQuality_DecreasesByOne()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 10 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(9, items[0].Quality);
        }

        [Test]
        public void ItemQuality_DecreasesByTwo_PastSellIn()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(8, items[0].Quality);
        }

        [Test]
        public void ItemQuality_CannotDecreaseBelowZero()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void SulfurasQuality_IsEighty()
        {
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            var app = new GildedRose(items);
            Assert.AreEqual(80, items[0].Quality);
        }

        [Test]
        public void SulfurasQuality_DoesNotDegrade()
        {
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(80, items[0].Quality);
        }

        [Test]
        public void AgedBrieQuality_IncreasesByOne()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(1, items[0].Quality);
        }

        [Test]
        public void AgedBrieQuality_IncreasesByTwo_AfterSellIn()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(2, items[0].Quality);
        }

        [Test]
        public void ItemQuality_CannotIncreaseAboveFifty()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 49 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(50, items[0].Quality);
        }

        [Test]
        public void BackstagePassQuality_IncreasesByTwo_WithTenDaysLeft()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(12, items[0].Quality);
        }

        [Test]
        public void BackstagePassQuality_IncreasesByThree_WithFiveDaysLeft()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(13, items[0].Quality);
        }

        [Test]
        public void BackstagePassQuality_GoesToZero_AfterSellIn()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void ConjuredItemsQuality_DecreasesByTwo()
        {
            var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 10 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(8, items[0].Quality);
        }

        [Test]
        public void ConjuredItemsQuality_DecreasesByFour_AfterSellIn()
        {
            var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(6, items[0].Quality);
        }
    }
}
