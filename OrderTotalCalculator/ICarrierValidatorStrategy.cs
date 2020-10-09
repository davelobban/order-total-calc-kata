using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderTotalCalculator
{
    public interface ICarrierValidatorStrategy
    {
        bool IsValidCarrier(OrderLine[] orderLines);
    }
}
