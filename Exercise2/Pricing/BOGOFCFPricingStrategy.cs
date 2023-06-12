using System;
namespace Exercise2.Pricing
{
	public class BOGOFCFPricingStrategy : IPricingStrategy
	{
        private readonly IPricingStrategy baseStrategy;

        public BOGOFCFPricingStrategy(IPricingStrategy baseStrategy)
        {
            this.baseStrategy = baseStrategy;
        }

        public decimal CalculatePrice(int quantity)
        {
            int paidQuantity = quantity;
            if (quantity > 1)
            {
                int freeQuantity = quantity / 2;
                int remainingQuantity = quantity % 2;

                decimal basePrice = baseStrategy.CalculatePrice(1);
                decimal totalPrice = basePrice * quantity;

                decimal freePrice = basePrice * freeQuantity;
                decimal remainingPrice = basePrice * remainingQuantity;

                return totalPrice - freePrice + remainingPrice;
            }

            return baseStrategy.CalculatePrice(paidQuantity);
        }
    }
}

