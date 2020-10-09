using BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;

namespace OrderTotalCalculator
{
    public class FranceSalesTaxStrategy : ISalesTaxStrategy
    {
        public double CalculateSalesTax(OrderLine[] orderLines)
        {
            var cost = orderLines.Sum(x => x.Cost);
            return cost * 0.18;
        }
    }
}
