using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;using thirdPartyDemo;

namespace thirdPartyDemo
{
    class ReadCSV_And_WriteJSON
    {
        public void ImplementCSVToJSON()
        {
            string importFilePath = @"C:\Users\Asus\source\repos\thirdPartyDemo\thirdPartyDemo\addresss.csv";
            string exportFilePath = @"C:\Users\Asus\source\repos\thirdPartyDemo\thirdPartyDemo\export.json";
            //reading csv file
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) //Reading through csvReader acess the csv file
            {
                var records = csv.GetRecords<AddressData>().ToList();  // from this reading the data and getting the record from the csv file
                Console.WriteLine("Read data sucessfully from addresses.csv , here are codes");   //storing the data into address data class object nd type casting is to list
                foreach (AddressData record in records)
                {

                    Console.WriteLine("\t" + record.firstname);
                    Console.WriteLine("\t" + record.lastname);
                    Console.WriteLine("\t" + record.city);
                    Console.WriteLine("\t" + record.state);
                    Console.WriteLine("\t" + record.zipcode);

                }
                Console.WriteLine("\n ******************* Now reading from csv file and write to json file************");
                //Write data to json file
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportFilePath))
                    using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }
        }
    }
    public class ReadJSON_And_writeCSV
    {
        public void ImplementJSONToCSV()
        {
            string importFilePath = @"C:\Users\Asus\source\repos\thirdPartyDemo\thirdPartyDemo\addresss.csv";
            string exportFilePath = @"C:\Users\Asus\source\repos\thirdPartyDemo\thirdPartyDemo\export.json";
            IList<AddressData> addresses = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(importFilePath));
            Console.WriteLine("***************Now reading from json file and write to csv********");
            //Writing csv file
            using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer , CultureInfo.CurrentCulture))
            {
                csvExport.WriteRecords(addresses);
            }

        }

    }

}
