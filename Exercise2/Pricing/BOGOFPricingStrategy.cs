using System;
namespace Exercise2.Pricing
{
    public class BOGOFPricingStrategy : IPricingStrategy
    {
        private readonly IPricingStrategy baseStrategy;

        public BOGOFPricingStrategy(IPricingStrategy baseStrategy)
        {
            this.baseStrategy = baseStrategy;
        }

        public decimal CalculatePrice(int quantity)
        {
            int paidQuantity = (quantity / 2) + (quantity % 2);
            return baseStrategy.CalculatePrice(paidQuantity);
        }
    }
}

