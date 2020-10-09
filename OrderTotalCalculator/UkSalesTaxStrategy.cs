using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderTotalCalculator
{
    public class UkSalesTaxStrategy : ISalesTaxStrategy
    {
        public double CalculateSalesTax(OrderLine[] orderLines)
        {
            var electronicsCost = orderLines.Sum(x => x.Product == Product.Tv ? x.Cost : 0);
            var gasCost = orderLines.Sum(x => x.Product == Product.Gas ? x.Cost : 0);
            return (electronicsCost * 0.20) + (gasCost * 0.05);
        }
    }
}
