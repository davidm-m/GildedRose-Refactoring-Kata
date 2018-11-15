using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        public const  int MaxQuality = 50;
        public const int MinQuality = 0;
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
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

        private void ChangeSellIn(int i)
        {
            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
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
            ChangeQuality(i, 2);
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
