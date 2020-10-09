using BusinessObjects;
using NUnit.Framework;
using OrderTotalCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1.CarrierValidationTests
{
    [TestFixture]
    public class DefaultCarrierValidationStrategyTests
    {
        [Test]
        public void IsValidCarrier_GasOrTv_ReturnsTrue()
        {
            var strategy = new DefaultCarrierValidationStrategy();
            var orderLines = new OrderLine[] { new OrderLine { Product = Product.Gas }, new OrderLine { Product = Product.Tv } };

            var isValid = strategy.IsValidCarrier(orderLines);

            Assert.That(isValid, Is.True);
        }

    }
}
