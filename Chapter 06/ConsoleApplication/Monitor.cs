using System;
using System.Data;
using System.Threading;
using Chapter05.ClassLibrary;

namespace Chapter05.ConsoleApplication
{
    class Monitor
    {
        private Domain domain;
        private Thread t1 = null;
        private bool isDone = false;
        private int timeout = 3; // seconds
        private decimal originalPrice = 0;
        private decimal currentPrice = 0;
        private int productId = 1;
        private CachingMode cachingMode = CachingMode.Off;

        public void SetCachingMode(CachingMode mode)
        {
            cachingMode = mode;
        }

        public void Run()
        {
            try
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress Enter to stop");
                Console.WriteLine();
                Thread.Sleep(500);

                domain = new Domain();
                Console.WriteLine("Caching Mode: " + cachingMode);
                domain.PrepareCachingMode(cachingMode);

                originalPrice = GetPrice();
                currentPrice = originalPrice;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Original Price:\t" + String.Format("{0:C}", originalPrice));
                Console.WriteLine();

                Thread.Sleep(1000);
                t1 = new Thread(new ThreadStart(MonitorPrice));
                t1.Start();

                Console.ReadKey();
                if (t1.ThreadState == ThreadState.Suspended)
                {
                    t1.Interrupt();
                }
                Stop();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nRestoring original price...");
                domain.SetListPrice(originalPrice, productId);
                domain.CompleteCachingMode(cachingMode);
                Console.WriteLine("Done.");

                Console.WriteLine("\nPress Enter to quit");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }

        private void MonitorPrice()
        {
            decimal newPrice = currentPrice;
            bool isOdd = true;
            while (!isDone)
            {
                decimal latestPrice;
                latestPrice = GetPrice();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Latest Price:\t" + String.Format("{0:C}", latestPrice));
                Console.WriteLine();

                Thread.Sleep(1000);
                if (!isDone)
                {
                    // do update only on odd iterations
                    if (isOdd)
                    {
                        newPrice += 0.01m; // raise the price by 0.01m
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Updating Price:\t" + String.Format("{0:C}", newPrice));
                        Console.WriteLine();
                        domain.SetListPrice(newPrice, productId);
                        Thread.Sleep(timeout * 1000);
                    }
                }
                isOdd = !isOdd;
            }
        }

        public void Stop()
        {
            isDone = true;
        }

        public decimal GetPrice()
        {
            decimal listPrice = 0;
            DataSet ds = domain.GetProductByID(productId, cachingMode);
            if (ds != null &&
                ds.Tables.Count > 0 &&
                ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (productId.Equals((int)row["ProductID"]))
                    {
                        listPrice = (decimal)row["ListPrice"];
                        break;
                    }
                }
            }
            return listPrice;
        }

    }
}
