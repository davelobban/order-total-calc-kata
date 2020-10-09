using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Handlers
{
    public class UsTaxHandler : ITaxHandler
    {
        private const double salesTax = 0.05;

        public bool CanHandle(Order order)
        {
            return order.Customer.Country == "US";
        }

        public double CalculateTax(Order order)
        {
            
            return order.OrderLines.Where(orderline => orderline.Product == Product.Tv)
                                   .Sum(tv => tv.Cost * salesTax);
        }
    }
}
