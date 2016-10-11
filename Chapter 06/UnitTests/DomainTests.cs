using System;
using System.Data;
using System.Threading;
using Chapter05.ClassLibrary;
using NUnit.Framework;

namespace Chapter05.UnitTests
{
    [TestFixture]
    public class DomainTests
    {

        #region "  Shared Methods  "

        private Domain domain;
        private int productId;
        private decimal originalPrice;

        [SetUp]
        public void SetUp()
        {
            productId = 1;
            domain = new Domain();
            DataSet productDs = domain.GetProductByID(productId, CachingMode.Off);
            originalPrice = GetPrice(productDs);
        }

        [TearDown]
        public void TearDown()
        {
            domain.SetListPrice(originalPrice, productId);
            domain.ClearCache();
            domain = null;
        }

        private decimal GetPrice(DataSet ds)
        {
            // verify there is data
            Assert.IsTrue(ds.Tables.Count > 0, "DataSet must be populated");
            Assert.IsNotNull(ds.Tables[0], "Table must be populated");
            Assert.IsTrue(ds.Tables[0].Rows.Count > 0, "Row must be populated");

            DataRow row = ds.Tables[0].Rows[0];
            decimal price = (decimal)row["ListPrice"];
            return price;
        }

        #endregion

        #region "  Test Methods  "

        /// <summary>
        /// Tests that the system works properly with caching off
        /// </summary>
        [Test]
        public void Test101_Caching_Off_Test()
        {
            CachingMode mode = CachingMode.Off;
            domain.PrepareCachingMode(mode);
            
            // get the first copy of the product
            DataSet productDs1 = domain.GetProductByID(productId, mode);

            decimal oldPrice = GetPrice(productDs1);
            decimal newPrice = oldPrice + 0.01m;
            domain.SetListPrice(newPrice, productId);

            // get the second copy of the product
            DataSet productDs2 = domain.GetProductByID(productId, mode);
            decimal updatedPrice = GetPrice(productDs2);

            Assert.AreNotEqual(oldPrice, updatedPrice);
            Assert.AreEqual(newPrice,updatedPrice);

            domain.CompleteCachingMode(mode);
        }

        /// <summary>
        /// Tests that the system works properly with absolute expiration
        /// </summary>
        [Test]
        public void Test102_Caching_AbsoluteExpiration_Test()
        {
            CachingMode mode = CachingMode.AbsoluteExpiration;
            domain.PrepareCachingMode(mode);
            domain.SetAbsoluteTimeout(3);

            // get the first copy of the product
            DataSet productDs1 = domain.GetProductByID(productId, mode);

            decimal price1 = GetPrice(productDs1);
            decimal newPrice1 = price1 + 0.01m;
            domain.SetListPrice(newPrice1, productId);

            // get the second copy of the product
            DataSet productDs2 = domain.GetProductByID(productId, mode);
            decimal price2 = GetPrice(productDs2);

            Thread.Sleep(3000);

            DataSet productDs3 = domain.GetProductByID(productId, mode);
            decimal price3 = GetPrice(productDs3);

            Assert.AreEqual(price1, price2, 
                "price1 and price2 should match due to caching");
            Assert.AreNotEqual(newPrice1, price2, 
                "newPrice1 and price2 should not match due to caching");
            Assert.AreEqual(newPrice1, price3, 
                "newPrice1 and price3 should match once the cache expires the item");

            domain.CompleteCachingMode(mode);
        }

        /// <summary>
        /// Tests that the system works properly with polling
        /// </summary>
        [Test]
        public void Test103_Caching_Polling_Test()
        {
            CachingMode mode = CachingMode.Polling;
            domain.PrepareCachingMode(mode);

            // get the first copy of the product
            DataSet productDs1 = domain.GetProductByID(productId, mode);

            decimal price1 = GetPrice(productDs1);
            decimal newPrice1 = price1 + 0.01m;
            domain.SetListPrice(newPrice1, productId);

            // get the second copy of the product
            DataSet productDs2 = domain.GetProductByID(productId, mode);
            decimal price2 = GetPrice(productDs2);

            // poll time is set to 3 seconds
            Thread.Sleep(3000);

            DataSet productDs3 = domain.GetProductByID(productId, mode);
            decimal price3 = GetPrice(productDs3);

            Assert.AreEqual(price1, price2,
                "price1 and price2 should match due to caching");
            Assert.AreNotEqual(newPrice1, price2,
                "newPrice1 and price2 should not match due to caching");
            Assert.AreEqual(newPrice1, price3,
                "newPrice1 and price3 should match once the cache expires the item");

            domain.CompleteCachingMode(mode);
        }

        /// <summary>
        /// Tests that the system works properly with Notification
        /// </summary>
        [Test]
        public void Test104_Caching_Notification_Test()
        {
            CachingMode mode = CachingMode.Notification;
            domain.PrepareCachingMode(mode);

            // get the first copy of the product
            DataSet productDs1 = domain.GetProductByID(productId, mode);
            Assert.IsNotNull(productDs1, "productDs1 cannot be null");

            decimal price1 = GetPrice(productDs1);
            decimal newPrice1 = price1 + 0.01m;
            domain.SetListPrice(newPrice1, productId);

            // sleep just long enough to allow the notification to work
            Thread.Sleep(200);

            // get the second copy of the product
            DataSet productDs2 = domain.GetProductByID(productId, mode);
            Assert.IsNotNull(productDs2, "productDs2 cannot be null");
            decimal price2 = GetPrice(productDs2);

            DataSet productDs3 = domain.GetProductByID(productId, mode);
            Assert.IsNotNull(productDs3, "productDs3 cannot be null");
            decimal price3 = GetPrice(productDs3);

            Assert.AreNotEqual(price1, price2,
                "price1 and price2 should not match due to the cache notification");
            Assert.AreEqual(newPrice1, price2,
                "newPrice1 and price2 should match due to the cache notification");
            Assert.AreEqual(newPrice1, price3,
                "newPrice1 and price3 should match");

            domain.CompleteCachingMode(mode);
        }

        /// <summary>
        /// Tests that the system works properly with SqlDependency
        /// </summary>
        [Test]
        public void Test105_Caching_SqlDependency_Test()
        {
            CachingMode mode = CachingMode.SqlDependency;
            domain.PrepareCachingMode(mode);

            // get the first copy of the product
            Console.WriteLine("Getting price1");
            DataSet productDs1 = domain.GetProductByID(productId, mode);
            Assert.IsNotNull(productDs1, "productDs1 cannot be null");

            decimal price1 = GetPrice(productDs1);
            decimal newPrice1 = price1 + 0.01m;
            domain.SetListPrice(newPrice1, productId);

            // sleep just long enough to allow the notification to work
            Thread.Sleep(200);

            // get the second copy of the product
            Console.WriteLine("Getting price2");
            DataSet productDs2 = domain.GetProductByID(productId, mode);
            Assert.IsNotNull(productDs2, "productDs2 cannot be null");
            decimal price2 = GetPrice(productDs2);

            Console.WriteLine("Getting price3");
            DataSet productDs3 = domain.GetProductByID(productId, mode);
            Assert.IsNotNull(productDs3, "productDs3 cannot be null");
            decimal price3 = GetPrice(productDs3);

            Assert.AreNotEqual(price1, price2,
                "price1 and price2 should not match due to the SqlDependency");
            Assert.AreEqual(newPrice1, price2,
                "newPrice1 and price2 should match due to the SqlDependency");
            Assert.AreEqual(newPrice1, price3,
                "newPrice1 and price3 should match");

            domain.CompleteCachingMode(mode);
        }

        [Test]
        public void Test201_GetProductWithRowFilter_Test()
        {
            DataSet ds = domain.GetAllProducts();

            for(int i=1;i<5;i++)
            {
                DataTable dt = domain.GetProductByID(ds, i);
                Assert.IsTrue(dt.Rows.Count > 0, "DataTable should have data");
                Assert.IsTrue(dt.Rows.Count.Equals(1), "DataTable should have 1 row");

                DataRow row = dt.Rows[0];
                Console.WriteLine("ProductID: " + row["ProductID"]);
                Console.WriteLine("Name: " + row["Name"]);
                Console.WriteLine("ProductNumber: " + row["ProductNumber"]);
            }
        }

        #endregion

    }

}
