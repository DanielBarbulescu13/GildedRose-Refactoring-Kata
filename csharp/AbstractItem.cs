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

        private string Name;
        private int SellIn;
        private int Quality;

        public string getName()
        {
            return this.Name;
        }
        public int getSellin()
        {
            return this.SellIn;
        }
        public int getQuality()
        {
            return this.Quality;
        }

        public void setName(string name)
        {
            this.Name = name;
        }

        public void setQuality(int quality)
        {
            this.Quality = quality;
        }

        public void setSellin(int sellIn)
        {
            this.SellIn = sellIn;
        }
        public string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }
        public abstract void UpdateQuality();
    }
}
