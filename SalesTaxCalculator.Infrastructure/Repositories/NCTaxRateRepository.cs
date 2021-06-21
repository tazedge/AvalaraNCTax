using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesTaxCalculator.Domain.Interfaces;
using SalesTaxCalculator.Domain.Model;

namespace SalesTaxCalculator.Infrastructure.Repositories
{
    public class NCTaxRateRepository : INCTaxRateRepository
    {

        private readonly ICsvFileReader _csvReader;
        private List<NCCountyTax> _NCTaxList;

        public NCTaxRateRepository(ICsvFileReader csvReader)
        {
            _csvReader = csvReader;
            _NCTaxList = new List<NCCountyTax>();
        }
        public decimal GetRateForCounty(string countyName)
        {
            if (_NCTaxList.Count == 0)
            {
                LoadNCTaxRates();
            }

            decimal rate = 0;
            foreach (var ncCountyTax in _NCTaxList)
            {
                if (ncCountyTax.CountyName.ToLower().Contains(countyName.ToLower()))
                {
                    rate = ncCountyTax.TaxRate;
                    break;
                }
                  
            }

            return rate;
        }

        private void LoadNCTaxRates()
        {
 
            var dataPath = "NCTaxRates.csv";
            _NCTaxList.Clear();
            _NCTaxList = _csvReader.ReadRecords<NCCountyTax>(
                dataPath,  
                false,
                ",", 
                0, 
                1)
                .ToList();

        }
    }
}
