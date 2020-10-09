using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjects.Handlers;

namespace BusinessObjects
{
    public class TaxHandlerSource
    {
        public static IEnumerable<ITaxHandler> GetHandlers()
        {
            yield return new UsTaxHandler();
            yield return new NYTaxHandler();

        }
    }
}
