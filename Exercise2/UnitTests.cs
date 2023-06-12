using Xunit;

namespace Exercise2;

public class UnitTests
{
    public UnitTests()
    {
        Cart = new ShoppingCart();
    }

    private ShoppingCart Cart { get; }


    [Fact]
    public void AddAnApple()
    {
        Cart.AddItem("apple");
        Assert.True(Cart.GetTotal() == 0.20m);
    }

    [Fact]
    public void ShouldNotAddUnknownProduct()
    {
        Assert.Throws<Exception>(() => { Cart.AddItem("Pluto"); });
    }


    [Fact]
    public void ShouldAddTwoApples()
    {
        Cart.AddItem("apple");
        Cart.AddItem("apple");
        Assert.True(Cart.GetTotal() == 0.40m);
    }

    [Fact]
    public void ShouldAddAnOrange()
    {
        Cart.AddItem("orange");
        Assert.True(Cart.GetTotal() == 0.40m);
    }

    [Fact]
    public void ShouldAddAnAppleAndAnOrange()
    {
        Cart.AddItem("apple");
        Cart.AddItem("orange");
        Assert.True(Cart.GetTotal() == 0.60m);
    }

    [Fact]
    public void ShouldAddABanana()
    {
        Cart.AddItem("banana");
        Assert.True(Cart.GetTotal() == 0.70m);
    }

    [Fact]
    public void ShouldAddAPineapple()
    {
        Cart.AddItem("pineapple");
        Assert.True(Cart.GetTotal() == 0.80m);
    }

    [Fact]
    public void ShouldAddACookie()
    {
        Cart.AddItem("cookie");
        Assert.True(Cart.GetTotal() == 1.23m);
    }

    [Fact]
    public void ShouldApplyBOGOFOnOranges()
    {
        Cart.AddItem("orange");
        Cart.AddItem("orange");
        Assert.True(Cart.GetTotal() == 0.40m);
    }

    [Fact]
    public void ShouldApplyBOGOFOn2OrangesAndAnApple()
    {
        Cart.AddItem("orange");
        Cart.AddItem("orange");
        Cart.AddItem("apple");
        Assert.True(Cart.GetTotal() == 0.60m);
    }

    [Fact]
    public void ShouldApplyBOGOFOn3Oranges()
    {
        Cart.AddItem("orange");
        Cart.AddItem("orange");
        Cart.AddItem("orange");
        Assert.True(Cart.GetTotal() == 0.80m);
    }

    [Fact]
    public void ShouldApplyBOGOFTwiceForFourOranges()
    {
        Cart.AddItem("orange");
        Cart.AddItem("orange");
        Cart.AddItem("orange");
        Cart.AddItem("orange");
        Assert.True(Cart.GetTotal() == 0.80m);
    }

    [Fact]
    public void ShouldApplyBOGOHPOnCookies()
    {
        Cart.AddItem("cookie");
        Cart.AddItem("apple");
        Cart.AddItem("cookie");
        Assert.True(Cart.GetTotal() == 2.05m);
    }

    [Fact]
    public void ShouldApplyBOGOFCFOnPineappleAndBanana()
    {
        Cart.AddItem("pineapple");
        Cart.AddItem("banana");
        Assert.True(Cart.GetTotal() == 0.8m);
    }

    [Fact]
    public void ShouldApplyBOGOFCFForPineappleAndBananas()
    {
        Cart.AddItem("pineapple");
        Cart.AddItem("banana");
        Cart.AddItem("banana");
        Assert.True(Cart.GetTotal() == 1.5m);
    }

    [Fact]
    public void ShouldApplyBOGOFCFAndBOGOHP()
    {
        Cart.AddItem("pineapple");
        Cart.AddItem("banana");
        Cart.AddItem("cookie");
        Cart.AddItem("cookie");
        Assert.True(Cart.GetTotal() == 2.65m);
    }

    [Fact]
    public void ShouldRemoveApples()
    {
        Cart.AddItem("apple");
        Cart.RemoveItem("apple");
        Assert.True(Cart.GetTotal() == 0);
    }

    [Fact]
    public void ShouldRemoveOranges()
    {
        Cart.AddItem("orange");
        Cart.RemoveItem("orange");
        Assert.True(Cart.GetTotal() == 0);
    }

    [Fact]
    public void ShouldRemoveOneApple()
    {
        Cart.AddItem("orange");
        Cart.AddItem("apple");
        Cart.AddItem("apple");
        Cart.RemoveItem("apple");
        Assert.True(Cart.GetTotal() == 0.6m);
    }
}