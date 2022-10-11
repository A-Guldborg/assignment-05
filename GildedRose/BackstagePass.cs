namespace GildedRose;

public class BackstagePass : Item
{
    public override void Update()
    {
        if (Quality < 50) Quality++;

        if (SellIn < 11 && Quality < 50) Quality++;
        if (SellIn < 6 && Quality < 50) Quality++;

        UpdateSellin();

        if (SellIn < 0) Quality = 0;
    }
}