using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SalesTaxCalculator.Domain.Interfaces;
using SalesTaxCalculator.Web.Controllers;

namespace SalesTaxCalculator.Web.Test
{
    [TestClass]
    public class NCSalesTaxByCountyAmountTest
    {

        [TestMethod]
        public void should_return_not_found_failure_with_invalid_county()
        {

            Mock<IRoundTaxAmount> moqRounder = new Mock<IRoundTaxAmount>();
            Mock<INCTaxRateRepository> moqRepository = new Mock<INCTaxRateRepository>();
            Mock < ILogger <NCSalesTaxByCountyAmountController>> mockLogger = new Mock<ILogger<NCSalesTaxByCountyAmountController>>();

            moqRepository.Setup(r => r.GetRateForCounty(It.IsAny<string>())).Returns(0);

            var taxController = new NCSalesTaxByCountyAmountController(
                mockLogger.Object,
                moqRepository.Object,
                moqRounder.Object);

            var result = taxController.GetTaxForTransaction("Wakey", 110);

            Assert.IsInstanceOfType(result, typeof( IActionResult));
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

        }

        [TestMethod]
        public void should_return_success_with_county()
        {

            Mock<IRoundTaxAmount> moqRounder = new Mock<IRoundTaxAmount>();
            Mock<INCTaxRateRepository> moqRepository = new Mock<INCTaxRateRepository>();
            Mock<ILogger<NCSalesTaxByCountyAmountController>> mockLogger = new Mock<ILogger<NCSalesTaxByCountyAmountController>>();

            moqRepository.Setup(r => r.GetRateForCounty(It.IsAny<string>())).Returns(0.075M);

            var taxController = new NCSalesTaxByCountyAmountController(
                mockLogger.Object,
                moqRepository.Object,
                moqRounder.Object);

            var result = taxController.GetTaxForTransaction("Wake", 110);

            Assert.IsInstanceOfType(result, typeof(IActionResult));
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));



        }
    }
}
