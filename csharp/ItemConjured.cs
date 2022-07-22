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
            if (this.getSellin() < 0)
            {
                this.setQuality(this.getQuality() - 4);
            }
            else
            {
                this.setQuality(this.getQuality() - 2);
            }
            if (this.getQuality() < 0)
                this.setQuality(0);
            this.setSellin(this.getSellin() - 1);
        }
    }
}