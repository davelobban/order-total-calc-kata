using BusinessObjects;
using NUnit.Framework;
using OrderTotalCalculator;
using System;
using System.Linq;
using System.IO;
using System.Text;

namespace NUnitTestProject1
{
    [TestFixture]
    public class OrderCalculatorTests
    {
        [Test]
        public void CalculateTotal_SingleOrder_ReturnsThreeHundredAndTen()
        {
            var incoming = File.ReadAllText("testData.SingleOrder.json");
            var order = Order.FromJson(incoming);
            
            var total = OrderCalculator.CalculateTotal(order);

            Assert.That(total, Is.EqualTo(310));
        }

        [Test]
        public void CalculateTotal_LastOrder_ReturnsThreeHundredAndFiftyFour()
        {
            var incoming = File.ReadAllText("testData.OrderCollection.json");
            var orders = OrderList.FromJson(incoming);

            var total = OrderCalculator.CalculateTotal(orders.Orders.Last());

            Assert.That(total, Is.EqualTo(354));
        }





    }
}
