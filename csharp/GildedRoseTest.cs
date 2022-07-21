using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void QualityDegradesForNormalItems()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 3; i++)
                app.UpdateQuality();

            Assert.AreEqual(17, Items[0].Quality);
        }

        [Test]
        public void QualityDegradesDoubleAfterSellByDatePassedForNormalItems()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 }
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 3; i++)
                app.UpdateQuality();

            Assert.AreEqual(15, Items[0].Quality);
        }

        [Test]
        public void QualityNeverNegativeForNormalItems()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 3 }
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 3; i++)
                app.UpdateQuality();

            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void QualityIncreasesForAgedBrie()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 7, Quality = 3 }
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 5; i++)
                app.UpdateQuality();

            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void QualityDoesNotPass50ForAgedBrie()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 7, Quality = 48 }
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 5; i++)
                app.UpdateQuality();

            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void QualityDoesNotChangeForSulfuras()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 5; i++)
                app.UpdateQuality();

            Assert.AreEqual(80, Items[0].Quality);
        }

        [Test]
        public void QualityDoesNotPass50ForBackstagePasses()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 40 }
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 13; i++)
                app.UpdateQuality();

            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void QualityIncreasesNormalForBackstagePasses()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 40 }
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 2; i++)
                app.UpdateQuality();

            Assert.AreEqual(42, Items[0].Quality);
        }

        [Test]
        public void QualityIncreasesBy2With10DaysOrLessRemainingForBackstagePasses()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 40 }
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 4; i++)
                app.UpdateQuality();

            Assert.AreEqual(46, Items[0].Quality);
        }

        [Test]
        public void QualityIncreaseBy3With10DaysOrLessRemainingForBackstagePasses()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 20 }
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 9; i++)
                app.UpdateQuality();

            Assert.AreEqual(38, Items[0].Quality);
        }

        [Test]
        public void QualityDropsTo0AfterConcertForBackstagePasses()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 20 }
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 18; i++)
                app.UpdateQuality();

            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void QualityDegradesNormalForConjured()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Conjured Mana Cake", SellIn = 12, Quality = 20 }
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 4; i++)
                app.UpdateQuality();

            Assert.AreEqual(12, Items[0].Quality);
        }

        [Test]
        public void QualityDegradesDoubleAfterSellByDatePassedForConjured()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Conjured Mana Cake", SellIn = 2, Quality = 20 }
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 5; i++)
                app.UpdateQuality();

            Assert.AreEqual(6, Items[0].Quality);
        }
    }
}
