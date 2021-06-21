using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxCalculator.Domain.Interfaces
{
    public interface INCTaxRateRepository
    {
        decimal GetRateForCounty(String countyName);
    }
}
