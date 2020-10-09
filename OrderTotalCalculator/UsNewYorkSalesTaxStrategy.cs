using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OrderTotalCalculator
{
    public class UsNewYorkSalesTaxStrategy : UsFederalSalesTaxStrategy
    {
        public override double CalculateSalesTax(OrderLine[] orderLines)
        {
            var baseTax = base.CalculateSalesTax(orderLines);
            var gasAmount = orderLines.Sum(x => x.Product == Product.Gas ? x.Cost : 0);
            return baseTax + gasAmount * 0.1;
        }
    }
}
