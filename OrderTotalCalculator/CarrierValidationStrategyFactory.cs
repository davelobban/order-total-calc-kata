using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderTotalCalculator
{
    public class CarrierValidationStrategyFactory
    {
        public static ICarrierValidatorStrategy CreateCarrierValidationStrategy(Customer customer)
        {
            if (customer.Country == "FR" && customer.Carrier == "DPD")
                return new DpdFranceCarrierValidationStrategy();

            return new DefaultCarrierValidationStrategy();
        }
    }
}
