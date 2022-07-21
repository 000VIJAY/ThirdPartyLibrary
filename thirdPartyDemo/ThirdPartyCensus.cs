using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace thirdPartyDemo
{
    public class Contact
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Add { get; set; }
    }

    public class ThirdPartyCensus
    {
        const string filePath = @"C:\Users\Asus\source\repos\thirdPartyDemo\thirdPartyDemo\census.CSV";
        public void CSVReadData()
        {
            using (CsvReader cr = new CsvReader(new StreamReader(filePath),System.Globalization.CultureInfo.CurrentCulture)) 
            {
                while(cr.Read())   //csv reader is a constructor it take two argument 1. file handler 2.information 
                {
                    var records = cr.GetRecord<Contact>();
                    Console.WriteLine(records.Name);
                    Console.WriteLine(records.Age);
                }
            }
              
        }
        public void CSVWritter()
        {
            List<Contact> myList = new List<Contact>()
            {
                new Contact() { Name = "Vijay",Age = 23 ,Add = "patna" },
                new Contact() {Name = "nitish" ,Age = 24, Add = "nalanda"}
            };
            var fh =  new StreamWriter(filePath);
            using (CsvWriter cw =new CsvWriter(fh, System.Globalization.CultureInfo.CurrentCulture)) 
            {
                cw.WriteRecords(myList);
            }


        }
    }
}
