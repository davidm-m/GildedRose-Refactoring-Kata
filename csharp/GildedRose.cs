using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        public const int MaxQuality = 50;
        public const int MinQuality = 0;
        public const string SulfurasName = "Sulfuras, Hand of Ragnaros";
        public const string AgedBrieName = "Aged Brie";
        public const string BackstagePassName = "Backstage passes to a TAFKAL80ETC concert";
        IList<Item> Items;
        public GildedRose(IList<Item> items)
        {
            this.Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case SulfurasName:
                        UpdateSulfuras(item);
                        break;
                    case AgedBrieName:
                        UpdateAgedBrie(item);
                        break;
                    case BackstagePassName:
                        UpdateBackstagePass(item);
                        break;
                    default:
                        if (item.Name.StartsWith("Conjured "))
                        {
                            UpdateConjuredItem(item);
                        }
                        else
                        {
                            UpdateNormalItem(item);
                        }
                        break;
                }
                UpdateSellIn(item);
            }
        }

        private void ChangeQuality(Item item, int delta)
        {
            item.Quality += delta;
            if (item.Quality < MinQuality)
            {
                item.Quality = MinQuality;
            }
            else if (item.Quality > MaxQuality)
            {
                item.Quality = MaxQuality;
            }
        }

        private void UpdateSellIn(Item item)
        {
            if (item.Name != SulfurasName)
            {
                item.SellIn -= 1;
            }
        }

        private void UpdateSulfuras(Item item)
        {
            item.Quality = 80;
        }

        private void UpdateAgedBrie(Item item)
        {
            ChangeQuality(item, item.SellIn <= 0 ? 2 : 1);
        }

        private void UpdateBackstagePass(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            else if (item.SellIn < 6)
            {
                ChangeQuality(item, 3);
            }
            else if (item.SellIn < 11)
            {
                ChangeQuality(item, 2);
            }
            else
            {
                ChangeQuality(item, 1);
            }
        }

        private void UpdateConjuredItem(Item item)
        {
            UpdateNormalItem(item);
            UpdateNormalItem(item);
        }

        private void UpdateNormalItem(Item item)
        {
            if (item.SellIn <= 0)
            {
                ChangeQuality(item, -2);
            }
            else
            {
                ChangeQuality(item, -1);
            }
        }
    }
}
