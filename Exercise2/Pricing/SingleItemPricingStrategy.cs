using System;
namespace Exercise2.Pricing
{
	public class SingleItemPricingStrategy : IPricingStrategy
	{
        private readonly decimal itemPrice;

        public SingleItemPricingStrategy(decimal itemPrice)
        {
            this.itemPrice = itemPrice;
        }

        public decimal CalculatePrice(int quantity)
        {
            return itemPrice * quantity;
        }
    }
}

