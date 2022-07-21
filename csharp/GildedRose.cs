using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                int quality_points_lost = 0;
                if (!Items[i].Name.Contains("Aged Brie") && !Items[i].Name.Contains("Backstage passes") &&
                    !Items[i].Name.Contains("Sulfuras"))
                    if (Items[i].Name.Contains("Conjured"))
                        quality_points_lost += 2;
                    else
                        quality_points_lost += 1;
                else if (Items[i].Quality < 50 && !Items[i].Name.Contains("Sulfuras"))
                {
                    Items[i].Quality += 1;

                    if (Items[i].Name.Contains("Backstage passes"))
                    {
                        if (Items[i].SellIn < 11)
                        {
                            quality_points_lost -= 1;

                            if (Items[i].SellIn < 6)
                                quality_points_lost -= 1;
                        }
                    }
                }

                if (Items[i].SellIn < 0 && quality_points_lost > 0)
                    quality_points_lost *= 2;

                if (Items[i].Quality - quality_points_lost < 0)
                    Items[i].Quality = 0;
                else if (Items[i].Quality - quality_points_lost > 50 && !Items[i].Name.Contains("Sulfuras"))
                    Items[i].Quality = 50;
                else if (Items[i].Name.Contains("Backstage passes") && Items[i].SellIn < 0)
                    Items[i].Quality = 0;
                else Items[i].Quality -= quality_points_lost;


                if (!Items[i].Name.Contains("Sulfuras"))
                    Items[i].SellIn -= 1;
            }
        }
    }
}
