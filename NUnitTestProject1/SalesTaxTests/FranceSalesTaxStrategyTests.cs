using BusinessObjects;
using NUnit.Framework;
using OrderTotalCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1.SalesTaxTests
{
    [TestFixture]
    public class FranceSalesTaxStrategyTests
    {
        [Test]
        public void CalculateSalesTax_100GasProduct_Returns18()
        {
            var strategy = new FranceSalesTaxStrategy();
            var orderLines = new OrderLine[] { new OrderLine { Product = Product.Gas, Cost = 100 } };

            var salesTax = strategy.CalculateSalesTax(orderLines);

            Assert.That(salesTax, Is.EqualTo(18));
        }

        [Test]
        public void CalculateSalesTax_100TvProduct_Returns18()
        {
            var strategy = new FranceSalesTaxStrategy();
            var orderLines = new OrderLine[] { new OrderLine { Product = Product.Tv, Cost = 100 } };

            var salesTax = strategy.CalculateSalesTax(orderLines);

            Assert.That(salesTax, Is.EqualTo(18));
        }

        [Test]
        public void CalculateSalesTax_100GasAnd100TvProduct_Returns36()
        {
            var strategy = new FranceSalesTaxStrategy();
            var orderLines = new OrderLine[] { 
                new OrderLine { Product = Product.Gas, Cost = 100 },
                new OrderLine {Product = Product.Tv, Cost = 100}
            };

            var salesTax = strategy.CalculateSalesTax(orderLines);

            Assert.That(salesTax, Is.EqualTo(36));
        }
    }
}
