using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Collections;

namespace thirdPartyDemo
{
    public class ThirdPartyCsv
    {
        public void ImplementCSVDataHandling()
        {
            string importFilePath = @"C:\Users\Asus\source\repos\thirdPartyDemo\thirdPartyDemo\addresss.csv";
            string exportFilePath = @"C:\Users\Asus\source\repos\thirdPartyDemo\thirdPartyDemo\export.csv";
            //reading csv file
            using (var reader = new StreamReader(importFilePath)) 
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) //Reading through csvReader acess the csv file
            {
                var records = csv.GetRecords<AddressData>().ToList();  // from this reading the data and getting the record from the csv file
                Console.WriteLine("Read data sucessfully from addresses csv.");   //storing the data into address data class object nd type casting is to list
                foreach (AddressData record in records)
                {

                    Console.WriteLine("\t" + record.firstname);
                    Console.WriteLine("\t" + record.lastname);
                    Console.WriteLine("\t" + record.city);
                    Console.WriteLine("\t" + record.state);
                    Console.WriteLine("\t" + record.zipcode);
                }
                Console.WriteLine("\n *******************Now reading from csv file and write to csv file***********");
                //writing csv file
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}
