using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderTotalCalculator
{
    public class OrderValidator
    {
        public static void ValidateOrder(Order order)
        {
            var strategy = CarrierValidationStrategyFactory.CreateCarrierValidationStrategy(order.Customer);

            if (!strategy.IsValidCarrier(order.OrderLines))
                throw new Exception($"Carrier {order.Customer.Carrier} cannot fulfill the order");
        }
    }
}
