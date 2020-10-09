using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BusinessObjects;
using BusinessObjects.Handlers;
using NUnit.Framework;

namespace NUnitTestProject1
{
    [TestFixture]
    public class UsTaxHandlerTests
    {
        [Test]
        public void CanHandle_GivenUSOrder_ReturnsTrue()
        {
            var incoming = File.ReadAllText("testData.SingleOrder.json");
            var actual = Order.FromJson(incoming);

            var sut = CreateSut();

            Assert.That(actual.Customer.Country, Is.EqualTo("US"));
            Assert.That(sut.CanHandle(actual), Is.True);
        }

        [Test]
        public void CanHandle_GivenNonUSOrder_ReturnsFalse()
        {
            var customer = new Customer();
            customer.Country = "France";

            var order = new Order();
            order.Customer = customer;

            var sut = CreateSut();

            Assert.That(sut.CanHandle(order), Is.False);
        }

        [Test]
        public void CalculateTax_GivenUSOrder_ReturnsCorrectTax()
        {
            var incoming = File.ReadAllText("testData.SingleOrder.json");
            var actual = Order.FromJson(incoming);

            var sut = CreateSut();

            Assert.That(actual.OrderLines[1].Cost, Is.EqualTo(200)); 
            Assert.That(sut.CalculateTax(actual), Is.EqualTo(10)); // 5% of the TV cost
        }


        private UsTaxHandler CreateSut()
        {
            return new UsTaxHandler();
        }
    }
}
