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
            this.setQuality(this.getQuality() + 1);
            if(this.getQuality() > 50)
                this.setQuality(50);
            this.setSellin(this.getSellin() - 1);
        }
    }
}
