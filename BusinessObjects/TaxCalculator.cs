using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class TaxCalculator
    {
        private readonly IEnumerable<ITaxHandler> taxHandlers;

        public TaxCalculator()
        {
            taxHandlers = TaxHandlerSource.GetHandlers();
        }

        public double GetTotalTax(Order order)
        {
            var handlers = taxHandlers.Where(h => h.CanHandle(order));

            var totalTax = handlers.Sum(h => h.CalculateTax(order));

            return totalTax;
        }
    }

    
}
