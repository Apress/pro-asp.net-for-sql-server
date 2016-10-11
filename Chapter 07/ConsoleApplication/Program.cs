using System;

namespace Chapter07.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DataServiceHost.Instance.StartDataService();

            Console.WriteLine("Press enter to stop host:");
            Console.ReadLine();
            
            DataServiceHost.Instance.StopDataService();
        }
    }
}
