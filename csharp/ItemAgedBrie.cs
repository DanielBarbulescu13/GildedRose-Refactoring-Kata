using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class ItemAgedBrie : AbstractItem
    {
        public ItemAgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality) { }

        public override void UpdateQuality()
        {
            this.Quality += 1;
            if (this.Quality > 50)
                this.Quality = 50;
            this.SellIn -= 1;
        }
    }
}
