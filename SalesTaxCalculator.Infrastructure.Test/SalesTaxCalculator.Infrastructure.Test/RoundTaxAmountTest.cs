using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxCalculator.Infrastructure.Core;

namespace SalesTaxCalculator.Infrastructure.Test
{
    [TestClass]
    public class RoundTaxAmountTest
    {
        [TestMethod]
        public void should_return_original_number_when_only_one_decimal()
        {
            decimal amount = 12.1M;
            var rounder = new RoundTaxAmount();

            // Act
            var result = rounder.AmountToRound(amount);

            // assert
            Assert.AreEqual(amount, result);
        }

        [TestMethod]
        public void should_round_correctly_up()
        {
            decimal amount = 12.188M;
            decimal expected = 12.19M;
            var rounder = new RoundTaxAmount();

            // Act
            var result = rounder.AmountToRound(amount);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void should_round_correctly_down()
        {
            decimal amount = 12.182M;
            decimal expected = 12.18M;
            var rounder = new RoundTaxAmount();

            // Act
            var result = rounder.AmountToRound(amount);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
