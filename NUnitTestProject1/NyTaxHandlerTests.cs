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
    public class NyTaxHandlerTests
    {
        [Test]
        public void CanHandle_GivenNYOrder_ReturnsTrue()
        {
            var customer = new Customer();
            customer.Country = "US";
            customer.State = "NY";

            var order = new Order();
            order.Customer = customer;

            var sut = CreateSut();

            Assert.That(sut.CanHandle(order), Is.True);
        }

        [Test]
        public void CanHandle_GivenNonNYOrder_ReturnsFalse()
        {
            var customer = new Customer();
            customer.Country = "US";
            customer.State = "TX";

            var order = new Order();
            order.Customer = customer;

            var sut = CreateSut();

            Assert.That(sut.CanHandle(order), Is.False);
        }

        [Test]
        public void CanHandle_GivenNYStateNotInUSOrder_ReturnsFalse()
        {
            var customer = new Customer();
            customer.Country = "USSADFASDFS";
            customer.State = "NY";

            var order = new Order();
            order.Customer = customer;

            var sut = CreateSut();

            Assert.That(sut.CanHandle(order), Is.False);
        }

        [Test]
        public void CalculateTax_GivenNYOrder_ReturnsCorrectTax()
        {
            var customer = new Customer();
            customer.Country = "US";
            customer.State = "NY";

            var order = new Order();
            order.Customer = customer;
            

            var fossilFuelLine = new OrderLine()
            {
                Product = Product.Gas,
                Cost = 100
            };

            order.OrderLines = new OrderLine[]{fossilFuelLine};

            var sut = CreateSut();

            Assert.That(sut.CalculateTax(order), Is.EqualTo(10)); // 10% of the state sales tax

        }


        private NYTaxHandler CreateSut()
        {
            return new NYTaxHandler();
        }
    }
}
