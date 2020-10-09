using BusinessObjects;
using NUnit.Framework;
using OrderTotalCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1.SalesTaxTests
{
    [TestFixture]
    public class UsFederalSalesTaxStrategyTests
    {
        [Test]
        public void CalculateSalesTax_100GasProduct_Returns0()
        {
            var strategy = new UsFederalSalesTaxStrategy();
            var orderLines = new OrderLine[] { new OrderLine { Product = Product.Gas, Cost = 100 } };

            var salesTax = strategy.CalculateSalesTax(orderLines);

            Assert.That(salesTax, Is.EqualTo(0));
        }

        [Test]
        public void CalculateSalesTax_100TvProduct_Returns5()
        {
            var strategy = new UsFederalSalesTaxStrategy();
            var orderLines = new OrderLine[] { new OrderLine { Product = Product.Tv, Cost = 100 } };

            var salesTax = strategy.CalculateSalesTax(orderLines);

            Assert.That(salesTax, Is.EqualTo(5));
        }

        [Test]
        public void CalculateSalesTax_100GasAnd100TvProduct_Returns5()
        {
            var strategy = new UsFederalSalesTaxStrategy();
            var orderLines = new OrderLine[] {
                new OrderLine { Product = Product.Gas, Cost = 100 },
                new OrderLine {Product = Product.Tv, Cost = 100}
            };

            var salesTax = strategy.CalculateSalesTax(orderLines);

            Assert.That(salesTax, Is.EqualTo(5));
        }

    }
}
