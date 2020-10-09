using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderTotalCalculator
{
    public interface ISalesTaxStrategy
    {
        public double CalculateSalesTax(OrderLine[] orderLines);
    }
}
