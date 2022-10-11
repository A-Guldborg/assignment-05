namespace GildedRose;

public class DefaultItem : Item
{
    public override void Update()
    {
        if (Quality > 0) Quality--;

        UpdateSellin();

        if (SellIn < 0 && Quality > 0) Quality--; 
    }
}