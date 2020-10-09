using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BusinessObjects;
using NUnit.Framework;

namespace NUnitTestProject1
{
    [TestFixture]
    public class TaxCalculatorTests
    {
        [Test]
        public void CalculatesTotalTaxCorrectly()
        {
            var incoming = File.ReadAllText("testData.SingleOrder.json");
            var actual = Order.FromJson(incoming);

            var sut = new TaxCalculator();

            Assert.That(sut.GetTotalTax(actual), Is.EqualTo(10));


        }
    }
}
