using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OrderTotalCalculator
{
    public class DpdFranceCarrierValidationStrategy : ICarrierValidatorStrategy
    {
        public bool IsValidCarrier(OrderLine[] orderLines)
        {
            return !orderLines.Any(x => x.Product == Product.Gas);
        }
    }
}
