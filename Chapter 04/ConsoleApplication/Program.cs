using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Chapter04;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string recordCountStr = ConfigurationManager.AppSettings["RecordCount"];
                int recordCount;
                if (!int.TryParse(recordCountStr, out recordCount))
                {
                    // default to 1000 if the value 
                    // cannot be read from the config
                    recordCount = 1000;
                }
                PersonDomain pd = new PersonDomain();
                pd.RegenerateData(recordCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
