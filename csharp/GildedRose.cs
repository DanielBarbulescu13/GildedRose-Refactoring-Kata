using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<AbstractItem> Items;
        public GildedRose(IList<AbstractItem> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].UpdateQuality();
            }
        }
    }
}
