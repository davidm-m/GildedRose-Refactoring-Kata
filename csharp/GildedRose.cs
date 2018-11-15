using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        public const  int MaxQuality = 50;
        public const int MinQuality = 0;
        public const string SulfurasName = "Sulfuras, Hand of Ragnaros";
        public const string AgedBrieName = "Aged Brie";
        public const string BackstagePassName = "Backstage passes to a TAFKAL80ETC concert";
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                switch (Items[i].Name)
                {
                    case SulfurasName:
                        UpdateSulfuras(i);
                        break;
                    case AgedBrieName:
                        UpdateAgedBrie(i);
                        break;
                    case BackstagePassName:
                        UpdateBackstagePass(i);
                        break;
                    default:
                        if (Items[i].Name.StartsWith("Conjured "))
                        {
                            UpdateConjuredItem(i);
                        }
                        else
                        {
                            UpdateNormalItem(i);
                        }
                        break;
                }
                UpdateSellIn(i);
            }
        }

        private void ChangeQuality(int i, int delta)
        {
            Items[i].Quality += delta;
            if (Items[i].Quality < MinQuality)
            {
                Items[i].Quality = MinQuality;
            }
            else if (Items[i].Quality > MaxQuality)
            {
                Items[i].Quality = MaxQuality;
            }
        }

        private void UpdateSellIn(int i)
        {
            if (Items[i].Name != SulfurasName)
            {
                Items[i].SellIn -= 1;
            }
        }

        private void UpdateSulfuras(int i)
        {
            return;
        }

        private void UpdateAgedBrie(int i)
        {
            if (Items[i].SellIn <= 0)
            {
                ChangeQuality(i, 2);
            }
            else
            {
                ChangeQuality(i, 1);
            }
            
        }

        private void UpdateBackstagePass(int i)
        {
            if (Items[i].SellIn <= 0)
            {
                Items[i].Quality = 0;
            }
            else if (Items[i].SellIn < 6)
            {
                ChangeQuality(i, 3);
            }
            else if (Items[i].SellIn < 11)
            {
                ChangeQuality(i, 2);
            }
            else
            {
                ChangeQuality(i, 1);
            }
        }

        private void UpdateConjuredItem(int i)
        {
            UpdateNormalItem(i);
            UpdateNormalItem(i);
        }

        private void UpdateNormalItem(int i)
        {
            if (Items[i].SellIn <= 0)
            {
                ChangeQuality(i, -2);
            }
            else
            {
                ChangeQuality(i, -1);
            }
        }
    }
}
