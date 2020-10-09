using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    public interface ITaxHandler
    {
        bool CanHandle(Order order);
        double CalculateTax(Order order);


    }
}
