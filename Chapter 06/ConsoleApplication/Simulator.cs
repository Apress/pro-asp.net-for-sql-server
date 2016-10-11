using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;
using Chapter05.ClassLibrary;

namespace Chapter05.ConsoleApplication
{
    // simulates activity on a commerce website 
    class Simulator
    {
        private DataSet products;
        private List<Int32> productIds;
        private Domain domain;
        private int timeout = 3;
        private int groupSize = 10;
        private Thread t1 = null;
        private bool isDone = false;

        private static int alreadyExistsCount = 0;
        private static int expiredCount = 0;
        private static int underusedCount = 0;
        private static int removedCount = 0;
        private static int dependencyCount = 0;
        private CachingMode cachingMode = CachingMode.Off;

        private DateTime startTime = DateTime.Now;
        private DateTime endTime = DateTime.Now;

        public Simulator(int timeout, int groupSize)
        {
            this.timeout = timeout;
            this.groupSize = groupSize;
        }

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

                startTime = DateTime.Now;
                domain = new Domain();
                domain.DomainItemChanged += new EventHandler<DomainEventArgs>(DomainItemChangedHandler);
                domain.PrepareCachingMode(cachingMode);
                products = domain.GetAllProducts();
                productIds = new List<int>();
                if (products != null && products.Tables[0] != null)
                {
                    foreach (DataRow row in products.Tables[0].Rows)
                    {
                        productIds.Add((int) row["ProductID"]);
                    }
                }

                // preload the cache with some of the products
                int initialLoadCount = productIds.Count/4;
                PreloadProducts(initialLoadCount);

                // wait to start the thread
                Thread.Sleep(timeout*1000);
                t1 = new Thread(new ThreadStart(AddMoreProducts));
                t1.Start();

                Console.ReadKey();
                if (t1.ThreadState == ThreadState.Suspended)
                {
                    t1.Interrupt();
                }

                Stop();

                endTime = DateTime.Now;

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
                Console.WriteLine("Configuration: ");

                CacheSection cacheSection = ConfigurationManager.GetSection("system.web/caching/cache") as CacheSection;
                if (cacheSection != null)
                {
                    Console.WriteLine();
                    Console.WriteLine(cacheSection.PrivateBytesLimit +
                                      "\tPrivate Bytes Limit");
                    Console.WriteLine(cacheSection.PercentagePhysicalMemoryUsedLimit +
                                      "\tPercentage Physical Memory Used Limit");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("[ Default Cache Settings ]");
                }

                Console.WriteLine();
                Console.WriteLine("Totals: ");
                Console.WriteLine();
                Console.WriteLine(alreadyExistsCount + "\tAlready in Cache");
                Console.WriteLine(expiredCount + "\tExpired");
                Console.WriteLine(underusedCount + "\tUnderused");
                Console.WriteLine(removedCount + "\tRemoved");
                Console.WriteLine(dependencyCount + "\tDependency Changed");

                long ticks = endTime.Ticks - startTime.Ticks;
                TimeSpan ts = new TimeSpan(ticks);
                Console.WriteLine();
                Console.WriteLine("Duration: " + ts);
                domain.CompleteCachingMode(cachingMode);

                Console.WriteLine("\nPress Enter to quit");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }

        void DomainItemChangedHandler(object sender, DomainEventArgs e)
        {
            if (isDone)
            {
                return;
            }
            switch (e.CacheActivity)
            {
                case CacheActivity.AlreadyExists:
                    alreadyExistsCount++;
                    break;
                case CacheActivity.Underused:
                    underusedCount++;
                    break;
                case CacheActivity.Removed:
                    removedCount++;
                    break;
                case CacheActivity.DependencyChanged:
                    dependencyCount++;
                    break;
                case CacheActivity.Expired:
                    expiredCount++;
                    break;
            }
        }

        // tell the thread it is done
        public void Stop()
        {
            isDone = true;
            domain.ClearCache();
        }

        /// <summary>
        /// Method run in thread
        /// </summary>
        private void AddMoreProducts()
        {
            while (!isDone)
            {
                PreloadProducts(groupSize);
                Thread.Sleep(timeout * 1000);
            }
        }

        /// <summary>
        /// Add Products to the cache
        /// </summary>
        /// <param name="size"></param>
        public void PreloadProducts(int size)
        {
            // select products randomly
            Random r = new Random();

            for (int i = 1; i <= size; i++)
            {
                int randomId = r.Next(0, productIds.Count);
                DataSet product = domain.GetProductByID(randomId, cachingMode);
            }
        }

        //public void InsertToCache(string key, Object value,
        //    int cacheTimeout, CacheItemPriority priority)
        //{
        //    Cache cache = HttpRuntime.Cache;
        //    if (cache[key] != null)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Cyan;
        //        Console.WriteLine(" o (Already in cache) " + key);
        //        alreadyExistsCount++;
        //    }
        //    else
        //    {
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        Console.WriteLine(String.Format(
        //            " + {0}, {1}", key, value.GetType()));
        //        cache.Insert(key, value, null,
        //            DateTime.Now.AddSeconds(cacheTimeout),
        //            TimeSpan.Zero, priority, RemovedCallback);
        //    }
        //}

        //private void RemovedCallback(string key, object value, 
        //    CacheItemRemovedReason reason)
        //{
        //    // colorize the reason for removal
        //    if (CacheItemRemovedReason.Underused == reason)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Magenta;
        //        underusedCount++;
        //    }
        //    else if (CacheItemRemovedReason.Expired == reason)
        //    {
        //        Console.ForegroundColor = ConsoleColor.DarkYellow;
        //        expiredCount++;
        //    }
        //    else if (CacheItemRemovedReason.DependencyChanged == reason)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        dependencyCount++;
        //    }
        //    else if (CacheItemRemovedReason.Removed == reason)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Gray;
        //        removedCount++;
        //    }
        //    Console.WriteLine(String.Format(
        //        " - {0}, {1}, {2}",
        //        key, value.GetType(), reason));
        //}
    }
}
