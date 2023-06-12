using System;
namespace Exercise2.Pricing
{
	public interface IPricingStrategy
	{
        decimal CalculatePrice(int quantity);
    }
}

