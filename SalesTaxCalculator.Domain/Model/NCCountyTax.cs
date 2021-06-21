using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxCalculator.Domain.Model
{
    public class NCCountyTax
    {
        public string CountyName { get; set; }
        public decimal TaxRate { get; set; }
    }
}
