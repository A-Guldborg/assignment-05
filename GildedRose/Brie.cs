namespace GildedRose;

public class Brie : Item
{
    public override void Update()
    {
        if(Quality < 50){
            Quality++;
        }

        UpdateSellin();

        if(SellIn < 0 && Quality < 50){
            Quality++;
        }
    }
}