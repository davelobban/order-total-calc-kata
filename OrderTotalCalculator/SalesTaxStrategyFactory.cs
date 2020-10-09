using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderTotalCalculator
{
    public class SalesTaxStrategyFactory
    {
        public static ISalesTaxStrategy CreateStrategy(Customer customer)
        {
            switch (customer.Country.ToUpper())
            {
                case "US":
                    return GetUsSalesStrategy(customer.State);
                case "UK":
                    return new UkSalesTaxStrategy();
                case "FR":
                    return new FranceSalesTaxStrategy();
                default:
                    throw new NotImplementedException();
            }

        }

        private static ISalesTaxStrategy GetUsSalesStrategy(string state)
        {
            switch (state)
            {
                case "NY":
                    return new UsNewYorkSalesTaxStrategy();
                default:
                    return new UsFederalSalesTaxStrategy();
            }
        }
    }
}
