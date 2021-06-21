using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesTaxCalculator.Domain.Interfaces;

namespace SalesTaxCalculator.Infrastructure.Core
{
    public class RoundTaxAmount : IRoundTaxAmount
    {
        public decimal AmountToRound(decimal number)
        {
            return Math.Round(number, 2);
        }
    }
}
