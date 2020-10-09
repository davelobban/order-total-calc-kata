using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderCalculators
{
    public class UKOrderCalculator : IOrderCalculator
    {
        private const decimal FuelTaxMultiplier = 1.05m;
        private const decimal ElectronicsTaxMultiplier = 1.20m;

        private readonly IOrderCalculator m_NextOrderCalculator;

        public UKOrderCalculator(IOrderCalculator nextOrderCalculator)
        {
            m_NextOrderCalculator = nextOrderCalculator;
        }

        public decimal CalculateOrderTotal(Order order)
        {
            return (order.Customer.Country == "UK")
                ? order.OrderLines.Select(s => ApplySalesTax(s)).Sum()
                : m_NextOrderCalculator.CalculateOrderTotal(order);
        }

        private decimal ApplySalesTax(OrderLine orderLine)
        {
            if (orderLine.Product == Product.Gas) return orderLine.Cost * FuelTaxMultiplier;
            else if (orderLine.Product == Product.Tv) return orderLine.Cost * ElectronicsTaxMultiplier;

            throw new InvalidOperationException();
        }
    }
}
