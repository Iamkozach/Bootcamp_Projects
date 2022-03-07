using System;
using System.Collections.Generic;
using Zacharioudakis_Assignment_3.Models;
using Zacharioudakis_Assignment_3.PaymentMethodStrategy;
using Zacharioudakis_Assignment_3.VariationStrategy;

namespace Zacharioudakis_Assignment_3.EShopContext
{
    public class EShop
    {
        private IEnumerable<IVariationStrategy> variations;
        private IPaymentMethodStrategy paymentMethod;

        public void SetPaymentMethod(IPaymentMethodStrategy method)
        {
            paymentMethod = method;
        }
        public void SetVariation(IEnumerable<IVariationStrategy> variationStrategies)
        {
            variations = variationStrategies;
        }

        public void CalculateCost(TShirt shirt)
        {
            foreach (var variation in variations)
            {
                variation.Cost(shirt);
            }
            Console.WriteLine($"T-Shirt final price is {shirt.Price} euros");
        }

        public void PayTshirt(decimal price)
        {

            if (paymentMethod.Pay(price))
            {
                Console.WriteLine("Transaction was successfull");
            }
            else
            {
                Console.WriteLine("Transaction aborted");
            }
        }

        public void Discount(TShirt shirt, decimal? percentage)
        {
            paymentMethod.Discount(shirt, percentage);
        }
    }
}
