using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderTotalCalculator
{
    public class OrderCalculator
    {
        public static double CalculateTotal(Order order)
        {
            var strategy = SalesTaxStrategyFactory.CreateStrategy(order.Customer);

            var cost = order.OrderLines.Sum(x => x.Cost);
            var tax = strategy.CalculateSalesTax(order.OrderLines);

            return cost + tax;
        }
    }
}
