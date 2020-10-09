using BusinessObjects;
using NUnit.Framework;
using OrderCalculators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NUnitTestProject1
{
    public class OrderCalculatorTests
    {

        [Test]
        public void CorrectTotalOrderCalculatedForSingleOrder()
        {
            var incoming = File.ReadAllText("testData.SingleOrder.json");
            var order = Order.FromJson(incoming);

            var orderCalculator = BuildOrderCalculatorChain();
            var totalCost = orderCalculator.CalculateOrderTotal(order);
            Assert.That(totalCost, Is.EqualTo(310));
        }


        [Test]
        public void CorrectTotalOrderCalculatedForUkOrder()
        {
            var incoming = File.ReadAllText("testData.OrderCollection.json");
            var orderList = OrderList.FromJson(incoming);

            var order = orderList.Orders.Where(w => w.Customer.Id == 3).First();
            var orderCalculator = BuildOrderCalculatorChain();
            var orderTotal = orderCalculator.CalculateOrderTotal(order);
            Assert.That(orderTotal, Is.EqualTo(345));
        }

        [Test]
        public void CorrectTotalOrderCalculatedForFranceOrder()
        {
            var incoming = File.ReadAllText("testData.OrderCollection.json");
            var orderList = OrderList.FromJson(incoming);

            var order = orderList.Orders.Where(w => w.Customer.Id == 4).First();
            var orderCalculator = BuildOrderCalculatorChain();
            var orderTotal = orderCalculator.CalculateOrderTotal(order);
            Assert.That(orderTotal, Is.EqualTo(236));
        }

        private IOrderCalculator BuildOrderCalculatorChain()
        {
            var endOfChain = new EndOfChainOrderCalculator();
            var usOrderCalculator = new USOrderCalculator(endOfChain);
            var frOrderCalculator = new FROrderCalculator(usOrderCalculator);
            return new UKOrderCalculator(frOrderCalculator);
        }
    }
}
