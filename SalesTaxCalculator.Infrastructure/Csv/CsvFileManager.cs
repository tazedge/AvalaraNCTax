using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using SalesTaxCalculator.Domain.Interfaces;

namespace SalesTaxCalculator.Infrastructure.Csv
{
    public class CsvFileManager : ICsvFileReader
    {
        public IList<TData> ReadRecords<TData>(string filePath, bool headerIncluded, string delimiter, 
            int rowsToSkipBeforeHeader , int rowsToSkipAfterheader)
        {
            var records = new List<TData>();

            var csvConfig = ProvideCsvConfiguration(headerIncluded, delimiter);

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, csvConfig))
            {
                for (var i = 0; i < rowsToSkipBeforeHeader; i++)
                {
                    reader.ReadLine();
                }


                if (headerIncluded)
                {
                    csv.Read();
                    csv.ReadHeader();
                }

                for (var i = 0; i < rowsToSkipAfterheader; i++)
                {
                    csv.Read();
                }

                while (csv.Read())
                {
                  records.Add(  csv.GetRecord<TData>());
                }

            }

            return records;

        }

        private CsvConfiguration ProvideCsvConfiguration(bool includeHeader, string delimiter)
        {
            var csvConfiguration = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
            {
                Delimiter = delimiter,
                HasHeaderRecord = includeHeader
            };
            return csvConfiguration;
        }
    }
}
