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
            if (this.getSellin() < 0)
            {
                this.setQuality(0);
            }
            else
            {
                this.setQuality(this.getQuality()+1);
                if (this.getSellin() < 11)
                {
                    {
                        this.setQuality(this.getQuality() + 1);
                        if (this.getSellin() < 6)
                        {
                            this.setQuality(this.getQuality() + 1);
                        }
                    }
                }
                if (this.getQuality() > 50)
                    this.setQuality(50);
            }
            this.setSellin(this.getSellin() - 1);
        }
    }
}

