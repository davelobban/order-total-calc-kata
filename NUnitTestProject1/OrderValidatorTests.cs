using BusinessObjects;
using NUnit.Framework;
using OrderTotalCalculator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NUnitTestProject1
{
    [TestFixture]
    public class OrderValidatorTests
    {

        [Test]
        public void ValidateOrder_SingleOrder_DoesNotThrow()
        {
            var incoming = File.ReadAllText("testData.SingleOrder.json");
            var order = Order.FromJson(incoming);

            Assert.DoesNotThrow(() => OrderValidator.ValidateOrder(order));
        }

        [Test]
        public void Validate_FourthOrder_ThrowsException()
        {
            var incoming = File.ReadAllText("testData.OrderCollection.json");
            var orders = OrderList.FromJson(incoming);

            Assert.Throws<Exception>(() => OrderValidator.ValidateOrder(orders.Orders[3]));
        }
    }
}
