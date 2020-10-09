using BusinessObjects;
using System;
using System.Linq;

namespace OrderCalculators
{
    public class USOrderCalculator : IOrderCalculator
    {
        private const decimal NYFuelTaxMultiplier = 1.10m;
        private const decimal ElectronicsTaxMultiplier = 1.05m;

        private readonly IOrderCalculator m_NextOrderCalculator;

        public USOrderCalculator(IOrderCalculator nextOrderCalculator)
        {
            m_NextOrderCalculator = nextOrderCalculator;
        }

        public decimal CalculateOrderTotal(Order order)
        {
            return (order.Customer.Country == "US")
                ? order.OrderLines.Select(s => ApplySalesTax(s, order)).Sum()
                : m_NextOrderCalculator.CalculateOrderTotal(order);
        }

        private decimal ApplySalesTax(OrderLine orderLine, Order order)
        {
            if (orderLine.Product == Product.Gas)
            {
                if (order.Customer.State == "NY") return orderLine.Cost * NYFuelTaxMultiplier;
                else if (order.Customer.State == "TX") return orderLine.Cost;
            }
            else if (orderLine.Product == Product.Tv)
            {
                return orderLine.Cost * ElectronicsTaxMultiplier;
            }
            throw new InvalidOperationException();
        }
    }
}