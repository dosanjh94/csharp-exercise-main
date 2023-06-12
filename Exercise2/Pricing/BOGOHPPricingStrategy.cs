using System;
namespace Exercise2.Pricing
{
	public class BOGOHPPricingStrategy : IPricingStrategy
	{
        private readonly IPricingStrategy baseStrategy;
        public BOGOHPPricingStrategy(IPricingStrategy baseStrategy)
        {
            this.baseStrategy = baseStrategy;
        }

        public decimal CalculatePrice(int quantity)
        {
            if (quantity <= 1)
            {
                return baseStrategy.CalculatePrice(quantity);
            }

            decimal paidQuantity = (quantity + 1) / 2;
            decimal halfQuantityPrice = baseStrategy.CalculatePrice(quantity / 2);
            decimal remainingQuantityPrice = baseStrategy.CalculatePrice(quantity % 2);
            decimal totalPrice = (1.5m * halfQuantityPrice) + remainingQuantityPrice;

            return Math.Round(totalPrice, 2, MidpointRounding.AwayFromZero);
        }
    }
}

