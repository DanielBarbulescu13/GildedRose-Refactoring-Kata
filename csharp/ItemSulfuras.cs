using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class ItemSulfuras : AbstractItem
    {
        public ItemSulfuras(string name, int sellIn, int quality) : base(name, sellIn, quality) { }

        public override void UpdateQuality()
        {
            if (this.getQuality() != 80)
            {
                this.setQuality(80);
            }
        }
    }
}
