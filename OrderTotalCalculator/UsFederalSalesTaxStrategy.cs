using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderTotalCalculator
{
    public class UsFederalSalesTaxStrategy : ISalesTaxStrategy
    {
        public virtual double CalculateSalesTax(OrderLine[] orderLines)
        {
            var cost = orderLines.Sum(x => x.Product == Product.Tv ? x.Cost : 0);
            return cost * 0.05;
        }
    }
}
