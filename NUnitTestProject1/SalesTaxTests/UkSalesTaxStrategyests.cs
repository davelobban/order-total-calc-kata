using BusinessObjects;
using NUnit.Framework;
using OrderTotalCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1.SalesTaxTests
{
    public class UkSalesTaxStrategyests
    {
        [Test]
        public void CalculateSalesTax_100GasProduct_Returns5()
        {
            var strategy = new UkSalesTaxStrategy();
            var orderLines = new OrderLine[] { new OrderLine { Product = Product.Gas, Cost = 100 } };

            var salesTax = strategy.CalculateSalesTax(orderLines);

            Assert.That(salesTax, Is.EqualTo(5));
        }

        [Test]
        public void CalculateSalesTax_100TvProduct_Returns20()
        {
            var strategy = new UkSalesTaxStrategy();
            var orderLines = new OrderLine[] { new OrderLine { Product = Product.Tv, Cost = 100 } };

            var salesTax = strategy.CalculateSalesTax(orderLines);

            Assert.That(salesTax, Is.EqualTo(20));
        }

        [Test]
        public void CalculateSalesTax_100GasAnd100TvProduct_Returns25()
        {
            var strategy = new UkSalesTaxStrategy();
            var orderLines = new OrderLine[] {
                new OrderLine { Product = Product.Gas, Cost = 100 },
                new OrderLine {Product = Product.Tv, Cost = 100}
            };

            var salesTax = strategy.CalculateSalesTax(orderLines);

            Assert.That(salesTax, Is.EqualTo(25));
        }
    }
}
