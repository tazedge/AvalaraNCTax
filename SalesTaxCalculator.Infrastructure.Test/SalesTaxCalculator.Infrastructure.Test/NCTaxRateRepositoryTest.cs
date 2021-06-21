using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SalesTaxCalculator.Domain.Interfaces;
using SalesTaxCalculator.Domain.Model;
using SalesTaxCalculator.Infrastructure.Csv;
using SalesTaxCalculator.Infrastructure.Repositories;

namespace SalesTaxCalculator.Infrastructure.Test
{
    [TestClass]
    public class NCTaxRateRepositoryTest
    {
        [TestMethod]
        public void should_return_zero_tax_rate_when_invalid_county_checked()
        {
            // Arrange
            var countyTaxList = new List<NCCountyTax>();
            countyTaxList.Add(new NCCountyTax
            {
                CountyName = "Wake",
                TaxRate = 0.075M
            });

            var county = "Wakey";

            Mock<ICsvFileReader> moqCsvManager = new Mock<ICsvFileReader>();
            moqCsvManager.Setup(c => c.ReadRecords<NCCountyTax>(
                        It.IsAny<string>(), 
                        It.IsAny<bool>(),
                        It.IsAny<string>(),
                        It.IsAny<int>(),
                        It.IsAny<int>()))
                .Returns(countyTaxList);

            
            var repository = new NCTaxRateRepository(moqCsvManager.Object);

            // Act 
            var rate = repository.GetRateForCounty(county);

            //Assert
            Assert.AreEqual(0, rate);

        }
        [TestMethod]
        public void should_return_correct_tax_rate_when_valid_county_checked()
        {
            // Arrange
            var countyTaxList = new List<NCCountyTax>();
            countyTaxList.Add(new NCCountyTax
            {
                CountyName = "Wake",
                TaxRate = 0.075M
            });

            var county = "Wake";

            Mock<ICsvFileReader> moqCsvManager = new Mock<ICsvFileReader>();
            moqCsvManager.Setup(c => c.ReadRecords<NCCountyTax>(
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                .Returns(countyTaxList);


            var repository = new NCTaxRateRepository(moqCsvManager.Object);

            // Act 
            var rate = repository.GetRateForCounty(county);

            //Assert
            Assert.AreEqual(0.075M, rate);

        }

        [TestMethod]
        public void should_return_correct_tax_rate_when_county_mixed_case()
        {
            // Arrange
            var countyTaxList = new List<NCCountyTax>();
            countyTaxList.Add(new NCCountyTax
            {
                CountyName = "Wake",
                TaxRate = 0.075M
            });

            var county = "WaKe";

            Mock<ICsvFileReader> moqCsvManager = new Mock<ICsvFileReader>();
            moqCsvManager.Setup(c => c.ReadRecords<NCCountyTax>(
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                .Returns(countyTaxList);


            var repository = new NCTaxRateRepository(moqCsvManager.Object);

            // Act 
            var rate = repository.GetRateForCounty(county);

            //Assert
            Assert.AreEqual(0.075M, rate);

        }
    }
}
