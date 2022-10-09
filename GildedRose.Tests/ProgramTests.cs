namespace GildedRose.Tests;
using GildedRose;

public class ProgramTests
{
    Program _app;
    public ProgramTests() {
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
    public void Test_Brie_Q_above_50_S_5_should_not_alter_Q_And_SellIn_Lower_By_One()
    {
        //Given
        var brie = new Item{Name = "Aged Brie", SellIn = 5, Quality = 51};
        _app.Items.Add(brie);

        //When
        _app.UpdateQuality();

        //Then
        brie.Quality.Should().Be(51);
        brie.SellIn.Should().Be(4);
    }

    [Fact]
    public void Test_Brie_Q_is_40_gives_Q_equals_42_When_SellIn_Is_Negative()
    {
        // Given
        var brie = new Item{ Name = "Aged Brie", SellIn = -4, Quality = 40 };
        _app.Items.Add(brie);
    
        // When
        _app.UpdateQuality();
    
        // Then
        brie.SellIn.Should().Be(-5);
        brie.Quality.Should().Be(42);
    }
    
    [Fact]
    public void Test_Brie_Q_is_40_gives_Q_equals_41_When_SellIn_Is_Positive()
    {
        // Given
        var brie = new Item{ Name = "Aged Brie", SellIn = 4, Quality = 40 };
        _app.Items.Add(brie);
    
        // When
        _app.UpdateQuality();
    
        // Then
        brie.SellIn.Should().Be(3);
        brie.Quality.Should().Be(41);
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
    public void Sulfuras_Doesnt_Age_Or_Change_Quality()
    {
        // Given
        var sulfurasAge0Q80 = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        var sulfurasAge10Q40 = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 40 };
        var sulfurasAgeMinus1QMinus1 = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = -1 };
        _app.Items.Add(sulfurasAge0Q80);
        _app.Items.Add(sulfurasAge10Q40);
        _app.Items.Add(sulfurasAgeMinus1QMinus1);
    
        // When
        _app.UpdateQuality();
    
        // Then
        sulfurasAge0Q80.SellIn.Should().Be(0);
        sulfurasAge0Q80.Quality.Should().Be(80);
        sulfurasAge10Q40.SellIn.Should().Be(10);
        sulfurasAge10Q40.Quality.Should().Be(40);
        sulfurasAgeMinus1QMinus1.SellIn.Should().Be(-1);
        sulfurasAgeMinus1QMinus1.Quality.Should().Be(-1);
    }

    [Fact]
    public void BackstagePass_SellIn_MoreThan6_LessThan11_Q_LessThan50_Should_Increment_Q_2()
    {
        // Given
        var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 40};
        _app.Items.Add(item);

        // When
        _app.UpdateQuality();
    
        // Then
        item.Quality.Should().Be(42);
    }

    [Fact]
    public void BackstagePass_SellIn_LessThan6_LessThan50_Should_Increment_Q_3()
    {
        // Given
        var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 40};
        _app.Items.Add(item);
    
        // When
        _app.UpdateQuality();
    
        // Then
        item.Quality.Should().Be(43);
    }

    [Fact]
    public void Test_BackstagePass_SellIn_GreaterThan11_Should_Increment_Q_1()
    {
        // Given
        var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 40};
        _app.Items.Add(item);
    
        // When
        _app.UpdateQuality();
    
        // Then
        item.Quality.Should().Be(42);
    }

    [Fact]
    public void Test_BackstagePass_SellIn_LessThan6_Quality_Maximum_Increments_To_50()
    {
        // Given
        var passQ48 = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 48};
        var passQ49 = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 49};
        var passQ50 = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 50};
        _app.Items.Add(passQ48);
        _app.Items.Add(passQ49);
        _app.Items.Add(passQ50);
    
        // When
        _app.UpdateQuality();
    
        // Then
        passQ48.Quality.Should().Be(50);
        passQ49.Quality.Should().Be(50);
        passQ50.Quality.Should().Be(50);
    }

    [Fact]
    public void Test_BackstagePass_Negative_SellIn_Should_Set_Quality_To_0()
    {
        // Given
        var passQ60 = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -2, Quality = 60};
        var passQ40 = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -2, Quality = 40};
        var passQ0 = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -2, Quality = 0};
        var passQMinus10 = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -2, Quality = -10};
        _app.Items.Add(passQ60);
        _app.Items.Add(passQ40);
        _app.Items.Add(passQ0);
        _app.Items.Add(passQMinus10);

        // When
        _app.UpdateQuality();
    
        // Then
        passQ60.Quality.Should().Be(0);
        passQ40.Quality.Should().Be(0);
        passQ0.Quality.Should().Be(0);
        passQMinus10.Quality.Should().Be(0);
    }

    [Fact]
    public void Test_Default_Item_With_Positive_SellIn_Decrements_Q_And_SellIn_By_1()
    {
        // Given
        var item = new Item {Name = "Default Sword", SellIn = 3, Quality = 12};
        _app.Items.Add(item);
    
        // When
        _app.UpdateQuality();
    
        // Then
        item.Quality.Should().Be(11);
        item.SellIn.Should().Be(2);
    }

    [Fact]
    public void Test_Default_Item_With_Negative_SellIn_Decrements_Q_By_2()
    {
        // Given
        var item = new Item {Name = "Default Sword", SellIn = -1, Quality = 8};
        _app.Items.Add(item);
    
        // When
        _app.UpdateQuality();
    
        // Then
        item.Quality.Should().Be(6);
        item.SellIn.Should().Be(-2);
    }
}