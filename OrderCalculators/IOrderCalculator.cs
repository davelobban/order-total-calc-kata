using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderCalculators
{
    public interface IOrderCalculator
    {
        decimal CalculateOrderTotal(Order order);
    }
}
