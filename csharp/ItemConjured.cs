using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class ItemConjured : AbstractItem
    {
        public ItemConjured(string name, int sellIn, int quality) : base(name, sellIn, quality) { }

        public override void UpdateQuality()
        {
            if (this.SellIn < 0)
            {
                this.Quality -= 4;
            }
            else
            {
                this.Quality -= 2;
            }

            if (this.Quality < 0)
                this.Quality = 0;
            this.SellIn -= 1;
        }
    }
}