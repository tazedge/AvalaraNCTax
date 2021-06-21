using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxCalculator.Domain.Interfaces
{
     public  interface IRoundTaxAmount
     {
         decimal AmountToRound(decimal number);
     }
}
