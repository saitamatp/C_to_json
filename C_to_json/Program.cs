using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;

namespace C_to_json
{
    class Program
    {
        static void Main(string[] args)
        {
            List<loan> a = new List<loan>();

            using (var reader = new StreamReader(@"D:\temp\work\loan.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<loan>();
                foreach(var record in records)
                {
                    a.Add(record);
                }
            }

            /*
            foreach(var i in a)
            {
                Console.WriteLine(i.currency_code);
            }*/

            for (var i=0;i< 847845; i++)
            {
                a.Add(sample_data.po());
            }

            try
            {
                string json = JsonConvert.SerializeObject(a);
                Console.WriteLine(System.Text.ASCIIEncoding.ASCII.GetByteCount(json) + "-ASCII Value");
                File.WriteAllText(@"D:\temp\work\loan.json", json);
            }
            catch
            {
                Console.WriteLine("Large size of data cannot be handled");
            }
            
            //Console.WriteLine(json);
            //Console.WriteLine(System.Text.ASCIIEncoding.Unicode.GetByteCount(json)+"-Unicode Value");

            
        }
    }
}
