﻿namespace GildedRose
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args) {
            System.Console.WriteLine("OMGHAI!");
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new DefaultItem 
                    { 
                        Name = "+5 Dexterity Vest", 
                        SellIn = 10, 
                        Quality = 20 
                    },
                    new Brie 
                    { 
                        Name = "Aged Brie", 
                        SellIn = 2, 
                        Quality = 0 
                    },
                    new DefaultItem 
                    { 
                        Name = "Elixir of the Mongoose", 
                        SellIn = 5, 
                        Quality = 7 
                    },
                    new Sulfuras 
                    { 
                        Name = "Sulfuras, Hand of Ragnaros", 
                        SellIn = 0, 
                        Quality = 80 
                    },
                    new Sulfuras 
                    { 
                        Name = "Sulfuras, Hand of Ragnaros", 
                        SellIn = -1, 
                        Quality = 80 
                    },
                    new BackstagePass
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new BackstagePass
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 10,
                        Quality = 49
                    },
                    new BackstagePass
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 5,
                        Quality = 49
                    },
                    new Conjured 
                    { 
                        Name = "Conjured Mana Cake", 
                        SellIn = 3, 
                        Quality = 6 
                    }
                }
            };
            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < app.Items.Count; j++)
                {
                    Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
                Items[i].Update();
        }
    }
}