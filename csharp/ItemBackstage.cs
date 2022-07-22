using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class ItemBackstage : AbstractItem
    {
        public ItemBackstage(string name, int sellIn, int quality) : base(name, sellIn, quality) { }

        public override void UpdateQuality()
        {
            if (this.SellIn < 0)
            {
                this.Quality = 0;
            }
            else
            {
                this.Quality += 1;
                if (this.SellIn < 11)
                {
                    {
                        this.Quality += 1;
                        if (this.SellIn < 6)
                        {
                            this.Quality += 1;
                        }
                    }
                }
                if (this.Quality > 50)
                    this.Quality = 50;
            }
            this.SellIn -= 1;
        }
    }
}

