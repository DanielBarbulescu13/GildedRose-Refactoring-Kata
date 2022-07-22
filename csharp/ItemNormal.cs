using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class ItemNormal : AbstractItem
    {
        public ItemNormal(string name, int sellIn, int quality) : base(name, sellIn, quality) {}

        public override void UpdateQuality()
        {
            if (this.SellIn < 0)
            {
                this.Quality -= 2;
            }
            else
            {
                this.Quality -= 1;
            }

            if (this.Quality < 0)
                this.Quality = 0;

            this.SellIn -= 1;
        }
    }
}
