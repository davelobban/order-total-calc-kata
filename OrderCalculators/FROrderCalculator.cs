using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderCalculators
{
    public class FROrderCalculator : IOrderCalculator
    {
        private const decimal NonFoodTaxMultiplier = 1.18m;

        private readonly IOrderCalculator m_NextOrderCalculator;

        public FROrderCalculator(IOrderCalculator nextOrderCalculator)
        {
            m_NextOrderCalculator = nextOrderCalculator;
        }

        public decimal CalculateOrderTotal(Order order)
        {
            return (order.Customer.Country == "FR")
                    ? order.OrderLines.Select(s => ApplySalesTax(s, order)).Sum()
                    : m_NextOrderCalculator.CalculateOrderTotal(order);
        }

        private decimal ApplySalesTax(OrderLine orderLine, Order order)
        {
            if (orderLine.Product == Product.Gas && order.Customer.Carrier == "DPD")
            {
                return 0;
            }
            
            if (orderLine.Product == Product.Tv || orderLine.Product == Product.Gas)
            {
                return orderLine.Cost * NonFoodTaxMultiplier;
            }
            throw new InvalidOperationException();
        }
    }
}
