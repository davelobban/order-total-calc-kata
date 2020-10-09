using BusinessObjects;
using NUnit.Framework;
using OrderTotalCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1.CarrierValidationTests
{
    [TestFixture]
    public class CarrierValidationStrategyFactoryTests
    {
        [TestCase("US", "Fedex", typeof(DefaultCarrierValidationStrategy))]
        [TestCase("US", "USPS", typeof(DefaultCarrierValidationStrategy))]
        [TestCase("UK", "Parcelforce", typeof(DefaultCarrierValidationStrategy))]
        [TestCase("FR", "UPS", typeof(DefaultCarrierValidationStrategy))]
        [TestCase("FR", "DPD", typeof(DpdFranceCarrierValidationStrategy))]
        public void Create_ReturnsExpected_Strategy(string country, string carrier, Type expectedType)
        {
            var customer = new Customer() { Country = country, Carrier = carrier };

            var strategy = CarrierValidationStrategyFactory.CreateCarrierValidationStrategy(customer);

            Assert.That(strategy, Is.InstanceOf(expectedType));
        }
    }
}
