using Exercise2.Pricing;
using Xunit.Abstractions;

namespace Exercise2;

public class ShoppingCart
{
    // I would normall throw custom exceptions one lines 30 and 54 but need to keep the unit tests the same
    // Also I need more time to think about how to get BOGOFCF to work as currently banana and pineapple are evalulated by the strategy seperately
    // I have a few ideas but technically they violate the open closed principle 

    private readonly Dictionary<string, int> cartItems;
    private readonly Dictionary<string, IPricingStrategy> pricingStrategies;

    public ShoppingCart()
    {
        cartItems = new Dictionary<string, int>();
        pricingStrategies = new Dictionary<string, IPricingStrategy>
        {
            { "apple", new SingleItemPricingStrategy(0.2m) },
            { "orange", new BOGOFPricingStrategy(new SingleItemPricingStrategy(0.4m)) },
            { "banana", new BOGOFCFPricingStrategy(new SingleItemPricingStrategy(0.7m)) },
            { "pineapple", new BOGOFCFPricingStrategy(new SingleItemPricingStrategy(0.8m)) },
            { "cookie", new BOGOHPPricingStrategy(new SingleItemPricingStrategy(1.23m)) }
        };
    }
    public void AddItem(string product)
    {
        var productName = product.ToLower();
        
        if (!pricingStrategies.ContainsKey(productName))
            throw new Exception("Unknown product");

        if (cartItems.ContainsKey(productName))
            cartItems[product.ToLower()]++;
        else
            cartItems[productName] = 1;
    }

    public decimal GetTotal()
    {
        decimal total = 0;

        foreach(var item in cartItems)
        {
            string product = item.Key;
            int quantity = item.Value;

            if (pricingStrategies.ContainsKey(product))
            {
                IPricingStrategy pricingStrategy = pricingStrategies[product];
                total += pricingStrategy.CalculatePrice(quantity);
            }
            else
            {
                throw new Exception("Unknown product");
            }
        }
        return total;
    }

    public void RemoveItem(string product)
    {
        if (cartItems.ContainsKey(product))
        {
            if (cartItems[product] > 1)
            {
                cartItems[product]--;
            }
            else
            {
                cartItems.Remove(product);
            }
        }
    }
}