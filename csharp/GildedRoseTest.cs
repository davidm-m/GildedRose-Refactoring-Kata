using NUnit.Framework;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void SulfurasQuality_IsEighty()
        {
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            var app = new GildedRose(items);
            Assert.AreEqual(80, items[0].Quality);
        }

        [Test, TestCaseSource(nameof(UpdateQualityCases))]
        public void UpdateQualityTest(Item item, int expectedQuality)
        {
            var items = new List<Item> {item};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, items[0].Quality);
        }

        // ReSharper disable once InconsistentNaming
        public static object[] UpdateQualityCases =
        {
            new TestCaseData(new Item { Name = "foo", SellIn = 5, Quality = 10 }, 9)
                .SetName("ItemQuality_DecreasesByOne"),
            new TestCaseData(new Item { Name = "foo", SellIn = 0, Quality = 10 }, 8)
                .SetName("ItemQuality_DecreasesByTwo_PastSellIn"),
            new TestCaseData(new Item { Name = "foo", SellIn = 5, Quality = 0 }, 0)
                .SetName("ItemQuality_CannotDecreaseBelowZero"),
            new TestCaseData(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }, 80)
                .SetName("SulfurasQuality_DoesNotDegrade"),
            new TestCaseData(new Item { Name = "Aged Brie", SellIn = 5, Quality = 0 }, 1)
                .SetName("AgedBrieQuality_IncreasesByOne"),
            new TestCaseData(new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 }, 2)
                .SetName("AgedBrieQuality_IncreasesByTwo_AfterSellIn"),
            new TestCaseData(new Item { Name = "Aged Brie", SellIn = 0, Quality = 49 }, 50)
                .SetName("ItemQuality_CannotIncreaseAboveFifty"),
            new TestCaseData(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 10 }, 11)
                .SetName("BackstagePassQuality_IncreasesByOne"),
            new TestCaseData(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 }, 12)
                .SetName("BackstagePassQuality_IncreasesByTwo_WithTenDaysLeft"),
            new TestCaseData(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 }, 13)
                .SetName("BackstagePassQuality_IncreasesByThree_WithFiveDaysLeft"),
            new TestCaseData(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 }, 0)
                .SetName("BackstagePassQuality_GoesToZero_AfterSellIn"),
            new TestCaseData(new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 10 }, 8)
                .SetName("ConjuredItemsQuality_DecreasesByTwo"),
            new TestCaseData(new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 }, 6)
                .SetName("ConjuredItemsQuality_DecreasesByFour_AfterSellIn")
        };
    }
}
