﻿using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using System.Collections.Generic;
using NUnit.Framework.Internal;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<AbstractItem> Items = new List<AbstractItem> { new ItemNormal("foo", 0, 0) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void QualityDegradesForNormalItems()
        {
            IList<AbstractItem> Items = new List<AbstractItem>
            {
                new ItemNormal("+5 Dexterity Vest", 10, 20)
            };
            var app = new GildedRose(Items);

            for (var i = 0; i < 3; i++)
                app.UpdateQuality();

            Assert.AreEqual(17, Items[0].Quality);
        }

        [Test]
        public void QualityDegradesDoubleAfterSellByDatePassedForNormalItems()
        {
            IList<AbstractItem> Items = new List<AbstractItem>
            {
                new ItemNormal("+5 Dexterity Vest", 0, 20)
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 3; i++)
                app.UpdateQuality();

            Assert.AreEqual(15, Items[0].Quality);
        }

        [Test]
        public void QualityNeverNegativeForNormalItems()
        {
            IList<AbstractItem> Items = new List<AbstractItem>
            {
                new ItemNormal("+5 Dexterity Vest", 0, 3)
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 3; i++)
                app.UpdateQuality();

            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void QualityIncreasesForAgedBrie()
        {
            IList<AbstractItem> Items = new List<AbstractItem>
            {
                new ItemAgedBrie("Aged Brie", 7, 3)
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 5; i++)
                app.UpdateQuality();

            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void QualityDoesNotPass50ForAgedBrie()
        {
            IList<AbstractItem> Items = new List<AbstractItem>
            {
                new ItemAgedBrie("Aged Brie", 7, 48)
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 5; i++)
                app.UpdateQuality();

            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void QualityDoesNotChangeForSulfuras()
        {
            IList<AbstractItem> Items = new List<AbstractItem>
            {
                new ItemSulfuras("Sulfuras, Hand of Ragnaros", 0, 80)
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 5; i++)
                app.UpdateQuality();

            Assert.AreEqual(80, Items[0].Quality);
        }

        [Test]
        public void QualityDoesNotPass50ForBackstagePasses()
        {
            IList<AbstractItem> Items = new List<AbstractItem>
            {
                new ItemBackstage("Backstage passes to a TAFKAL80ETC concert", 15, 40)
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 13; i++)
                app.UpdateQuality();

            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void QualityIncreasesNormalForBackstagePasses()
        {
            IList<AbstractItem> Items = new List<AbstractItem>
            {
                new ItemBackstage("Backstage passes to a TAFKAL80ETC concert", 15, 40)
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 2; i++)
                app.UpdateQuality();

            Assert.AreEqual(42, Items[0].Quality);
        }

        [Test]
        public void QualityIncreasesBy2With10DaysOrLessRemainingForBackstagePasses()
        {
            IList<AbstractItem> Items = new List<AbstractItem>
            {
                new ItemBackstage("Backstage passes to a TAFKAL80ETC concert", 12, 40)
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 4; i++)
                app.UpdateQuality();

            Assert.AreEqual(46, Items[0].Quality);
        }

        [Test]
        public void QualityIncreaseBy3With10DaysOrLessRemainingForBackstagePasses()
        {
            IList<AbstractItem> Items = new List<AbstractItem>
            {
                new ItemBackstage("Backstage passes to a TAFKAL80ETC concert", 12, 20)
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 9; i++)
                app.UpdateQuality();

            Assert.AreEqual(38, Items[0].Quality);
        }

        [Test]
        public void QualityDropsTo0AfterConcertForBackstagePasses()
        {
            IList<AbstractItem> Items = new List<AbstractItem>
            {
                new ItemBackstage("Backstage passes to a TAFKAL80ETC concert", 12, 20)
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 18; i++)
                app.UpdateQuality();

            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void QualityDegradesNormalForConjured()
        {
            IList<AbstractItem> Items = new List<AbstractItem>
            {
                new ItemConjured("Conjured Mana Cake", 12, 20 )
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 4; i++)
                app.UpdateQuality();

            Assert.AreEqual(12, Items[0].Quality);
        }

        [Test]
        public void QualityDegradesDoubleAfterSellByDatePassedForConjured()
        {
            IList<AbstractItem> Items = new List<AbstractItem>
            {
                new ItemConjured("Conjured Mana Cake", 2, 20 )
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 5; i++)
                app.UpdateQuality();

            Assert.AreEqual(6, Items[0].Quality);
        }
    }
}
