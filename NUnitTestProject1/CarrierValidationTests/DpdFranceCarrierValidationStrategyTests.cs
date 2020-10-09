using BusinessObjects;
using NUnit.Framework;
using OrderTotalCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1.CarrierValidationTests
{
    [TestFixture]
    public class DpdFranceCarrierValidationStrategyTests
    {
        [Test]
        public void IsValidCarrier_NoGas_ReturnsTrue()
        {
            var strategy = new DpdFranceCarrierValidationStrategy();
            var orderLines = new OrderLine[] { new OrderLine { Product = Product.Tv } };

            var isValid = strategy.IsValidCarrier(orderLines);

            Assert.That(isValid, Is.True);
        }

        [Test]
        public void IsValidCarrier_HasGas_ReturnsFalse()
        {
            var strategy = new DpdFranceCarrierValidationStrategy();
            var orderLines = new OrderLine[] { new OrderLine { Product = Product.Gas } };

            var isValid = strategy.IsValidCarrier(orderLines);

            Assert.That(isValid, Is.False);
        }
    }
}
