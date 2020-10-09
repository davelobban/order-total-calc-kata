using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Handlers
{
    public class NYTaxHandler : ITaxHandler
    {
        private const double salesTax = 0.10;

        public bool CanHandle(Order order)
        {
            return order.Customer.State == "NY" && order.Customer.Country == "US";
        }

        public double CalculateTax(Order order)
        {
            return order.OrderLines.Where(orderline => orderline.Product == Product.Gas)
                                   .Sum(gas => gas.Cost * salesTax);
        }
    }
}
