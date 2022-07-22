using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public abstract class AbstractItem : Item
    {
        protected AbstractItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }
        public abstract void UpdateQuality();
    }
}
