using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxCalculator.Domain.Interfaces
{
    public interface ICsvFileReader
    {
        IList<TData> ReadRecords<TData>(string filePath, bool headerIncluded, string delimiter,
            int rowsToSkipBeforeHeader , int rowsToSkipAfterheader );
    }
}
