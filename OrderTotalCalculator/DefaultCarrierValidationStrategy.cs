using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderTotalCalculator
{
    public class DefaultCarrierValidationStrategy : ICarrierValidatorStrategy
    {
        public bool IsValidCarrier(OrderLine[] orderLines)
        {
            return true;
        }
    }
}
