namespace GildedRose;
public class Conjured : Item
{
    public override void Update()
    {
        // Degrades twice as fast
        for(int i = 0; i < 2; i++) if(Quality > 0) Quality--;
        
        UpdateSellin();
        
        for(int i = 0; i < 2; i++) if(SellIn < 0 && Quality > 0) Quality--;
    }
}