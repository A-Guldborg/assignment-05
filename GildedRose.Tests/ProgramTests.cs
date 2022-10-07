namespace GildedRose.Tests;
using GildedRose;

public class ProgramTests
{
    Program _app;
    ProgramTests() {
        _app = new(){
            Items = new List<Item>(){}
        };
    }

    [Fact]
    public void TestTheTruth()
    {
        true.Should().BeTrue();
    }

    [Fact]
    public void Test_Brie_Q_above_50_should_not_alter_Q()
    {
        //Given
        _app.Items.Add(new Item{Name = "Aged Brie", Quality = 51});

        //When
        _app.UpdateQuality();

        //Then
    }

    [Fact]
    public void Test_Brie_Q_is_40_gives_Q_equals_42()
    {
        // Given
        var brie = new Item{ Name = "Aged Brie", SellIn = 4, Quality = 40 };
        _app.Items.Add(brie);
    
        // When
        _app.UpdateQuality();
    
        // Then
        brie.SellIn.Should().Be(3);
        brie.Quality.Should().Be(42);
    }

    [Fact]
    public void Test_Brie_Q_equals_49_Gives_Q_equals_50()
    {
        // Given
        var brie = new Item{ Name = "Aged Brie", SellIn = 4, Quality = 49 };
        _app.Items.Add(brie);
    
        // When
        _app.UpdateQuality();
    
        // Then
        brie.SellIn.Should().Be(3);
        brie.Quality.Should().Be(50);
    }

    [Fact]
    public void Sulfuras_Doesnt_Age()
    {
        // Given
        var sulfurasAge0 = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        var sulfurasAge10 = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
        var sulfurasAgeMinus1 = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 };
        _app.Items.Add(sulfurasAge0);
        _app.Items.Add(sulfurasAge10);
        _app.Items.Add(sulfurasAgeMinus1);
    
        // When
        _app.UpdateQuality();
    
        // Then
        sulfurasAge0.SellIn.Should().Be(0);
        sulfurasAge10.SellIn.Should().Be(10);
        sulfurasAgeMinus1.SellIn.Should().Be(-1);
    }

    [Fact]
    public void Test_Sulfuras()
    {
        // Given
    
        // When
    
        // Then
    }

    [Fact]
    public void BackstagePass_SellIn_MoreThan6_LessThan11_Q_LessThan50_Should_Increment_Q_1()
    {
        // Given
        var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 40};
        _app.Items.Add(item);

        // When
        _app.UpdateQuality();
    
        // Then
        item.Quality.Should().Be(41);
    }

    [Fact]
    public void BackstagePass_SellIn_LessThan6_LessThan50_Should_Increment_Q_2()
    {
        // Given
        var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 40};
        _app.Items.Add(item);
    
        // When
        _app.UpdateQuality();
    
        // Then
        item.Quality.Should().Be(42);
    }

    [Fact]
    public void Test_Brie_Q_()
    {
        // Given
    
        // When
    
        // Then
    }
}