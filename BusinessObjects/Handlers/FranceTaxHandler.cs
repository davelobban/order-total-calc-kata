using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects.Handlers
{
    public class FranceTaxHandler : ITaxHandler
    {
        public bool CanHandle(Order order)
        {
            throw new NotImplementedException();
        }

        public double CalculateTax(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
