using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using Chapter07.LINQ;
using Chapter07.WCFService;
using NUnit.Framework;
using Chapter07.Data;
using Chapter07.Data.FavoriteLinksTableAdapters;
using Chapter07.Domain;

namespace Chapter07.UnitTests
{
    [TestFixture]
    public class FavoriteLinkDomainTests
    {

        #region "  Member Variables  "

        private FavoriteLinkDomain domain;
        private Guid _userId1 = Guid.Empty;
        private Guid _userId2 = Guid.Empty;
        private long _profileId1 = -1;
        private long _profileId2 = -1;

        private bool _enableLoadTesting = true;

        #endregion

        #region " SetUp and TearDown "

        [SetUp]
        public void SetUp()
        {
            domain = new FavoriteLinkDomain();

            _userId1 = new Guid("{E18369A7-99F7-486d-8F0B-96347ABF04ED}");
            _userId2 = new Guid("{E18369A7-99F7-486d-8F0B-96347ABF04EE}");
            _profileId1 = domain.GetFavoriteLinkProfileID(_userId1);
            _profileId2 = domain.GetFavoriteLinkProfileID(_userId2);
        }

        [TearDown]
        public void TearDown()
        {
            domain.PurgeProfile(_profileId1);
            domain.PurgeProfile(_profileId2);
            domain = null;
        }

        #endregion
        
        #region " Level 100 "

        [Test]
        public void Test100_ReadConfiguration()
        {
            Configuration config = 
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Assert.IsNotNull(config, "Configuration cannot be null");

            Chapter07SectionGroup chapter07Config = 
                config.SectionGroups["chapter07"] as Chapter07SectionGroup;
            Assert.IsNotNull(chapter07Config, "Chapter07 Configuration cannot be null");

            FavoriteLinkSection section = chapter07Config.FavoriteLinkSection;
            Assert.IsNotNull(section, "Favorite Link Section cannot be null");

            //section.ConnectionStringName = String.Empty;
            //Assert.IsTrue(String.Empty.Equals(section.ConnectionStringName));
        }

        [Test]
        public void Test101_Connect()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["FavoriteLinkDB"].ConnectionString;
            Console.WriteLine("Connection String: " + connectionString);
            Assert.IsFalse(String.Empty.Equals(connectionString), "Connection String must be defined");
        }

        [Test]
        public void Test102_CheckUserID1()
        {
            Assert.IsFalse(Guid.Empty.Equals(_userId1), "User ID 1 must be defined");
        }

        [Test]
        public void Test103_CheckUserID2()
        {
            Assert.IsFalse(Guid.Empty.Equals(_userId2), "User ID 2 must be defined");
        }

        [Test]
        public void Test104_CheckDomain()
        {
            Assert.IsFalse(domain == null, "Domain must be defined");
        }
        
        [Test]
        public void Test105_GetProfile1() {
            Console.WriteLine("_profileId1 is " + _profileId1);
        }

        [Test]
        public void Test106_GetProfile2()
        {
            Console.WriteLine("_profileId2 is " + _profileId2);
        }

        [Test]
        public void Test107_CheckProfiles()
        {
            Assert.IsTrue(_profileId1 != _profileId2, "Profile IDs cannot match");
        }

        [Test]
        public void Test108_GetDataSet()
        {
            chpt07_FavoriteLinksTableAdapter adapter = new Chapter07.Data.FavoriteLinksTableAdapters.chpt07_FavoriteLinksTableAdapter();
            FavoriteLinks.chpt07_FavoriteLinksDataTable data = adapter.GetData();
            Assert.IsNotNull(data);
        }

        #endregion

        #region " Level 200 "

        [Test]
        public void Test201_SaveFavoriteLink()
        {
            long id = domain.SaveFavoriteLink(_profileId1, "http://testlink1.com", "Test Link 1", -1);
            Assert.IsTrue(id > 0, "FavoriteLinkID must be defined");
        }

        [Test]
        public void Test202_SaveMultipleLinks()
        {
            domain.SaveFavoriteLink(_profileId1, "http://testlink1.com", "Test Link 1");
            domain.SaveFavoriteLink(_profileId1, "http://testlink2.com", "Test Link 2");
            domain.SaveFavoriteLink(_profileId1, "http://testlink3.com", "Test Link 3");
            domain.SaveFavoriteLink(_profileId1, "http://testlink4.com", "Test Link 4");
            FavoriteLinkCollection collection1 = domain.GetFavoriteLinkCollection(_profileId1);
            Assert.IsTrue(collection1.Count == 4, "Profile 1 should have 4 links: " + collection1.Count);

            domain.SaveFavoriteLink(_profileId2, "http://testlink1.com", "Test Link 1");
            domain.SaveFavoriteLink(_profileId2, "http://testlink2.com", "Test Link 2 (alternate)");
            FavoriteLinkCollection collection2 = domain.GetFavoriteLinkCollection(_profileId2);
            Assert.IsTrue(collection2.Count == 2, "Profile 2 should have 2 links: " + collection2.Count);
        }

        [Test]
        public void Test203_SaveLinkTag()
        {
            long favoriteLinkId = domain.SaveFavoriteLink(_profileId1, "http://testlink1.com", "Test Link 1");
            domain.SaveLinkTag(favoriteLinkId, "token1");
        }

        [Test]
        public void Test204_SaveMultipleLinkTags()
        {
            long favoriteLinkId = domain.SaveFavoriteLink(_profileId1, "http://testlink2.com", "Test Link 2");
            domain.SaveLinkTag(favoriteLinkId, "token1");
            domain.SaveLinkTag(favoriteLinkId, "token2");
            domain.SaveLinkTag(favoriteLinkId, "token3");
        }

        [Test]
        public void Test205_SaveMultipleLinkTags()
        {
            long favoriteLinkId = domain.SaveFavoriteLink(_profileId1, "http://testlink3.com", "Test Link 3");
            domain.SaveLinkTag(favoriteLinkId, "token2");
            domain.SaveLinkTag(favoriteLinkId, "token3");
        }

        #endregion

        #region " Level 300 "

        [Test]
        public void Test301_GetFavoriteLinks()
        {
            domain.SaveFavoriteLink(_profileId1, "http://testlink1.com", "Test Link 1");
            domain.SaveFavoriteLink(_profileId1, "http://testlink2.com", "Test Link 2");
            domain.SaveFavoriteLink(_profileId1, "http://testlink3.com", "Test Link 3");
            FavoriteLinkCollection collection1 = domain.GetFavoriteLinkCollection(_profileId1);
            Assert.IsTrue(collection1.Count > 0, "FavoriteLinkCollection 1 must have items");
            ShowLinks(collection1);

            domain.SaveFavoriteLink(_profileId2, "http://testlink1.com", "Test Link 1");
            domain.SaveFavoriteLink(_profileId2, "http://testlink2.com", "Test Link 2");
            domain.SaveFavoriteLink(_profileId2, "http://testlink3.com", "Test Link 3");
            FavoriteLinkCollection collection2 = domain.GetFavoriteLinkCollection(_profileId2);
            Assert.IsTrue(collection2.Count > 0, "FavoriteLinkCollection 2 must have items");
            ShowLinks(collection2);
        }

        [Test]
        public void Test304_GetRecentFavoriteLinks()
        {
            domain.SaveFavoriteLink(_profileId1, "http://testlink1.com", "Test Link 1");
            domain.SaveFavoriteLink(_profileId1, "http://testlink2.com", "Test Link 2");
            domain.SaveFavoriteLink(_profileId1, "http://testlink3.com", "Test Link 3");
            FavoriteLinkCollection collection = domain.GetRecentFavoriteLinkCollection(_profileId1, 3, 0);
            Assert.IsTrue(collection.Count > 0, "Recent FavoriteLinkCollection must have items");
            ShowLinks(collection);
        }

        [Test]
        public void Test305_GetFavoriteLinksByTag()
        {
            long favoriteLinkId = domain.SaveFavoriteLink(_profileId1, "http://testlink1.com", "Test Link 1");
            domain.SaveLinkTag(favoriteLinkId, "token1");

            FavoriteLinkCollection collection = domain.GetFavoriteLinkCollectionByTag(_profileId1, "token1");
            Assert.IsTrue(collection.Count > 0, "FavoriteLinkCollection by tag must have items");
            ShowLinks(collection);
        }

        [Test]
        public void Test306_GetLinkTagsByFavoriteLinkId()
        {
            long favoriteLinkId = domain.SaveFavoriteLink(_profileId1, "http://testlink1.com", "Test Link 1");
            domain.SaveLinkTag(favoriteLinkId, "token1");
            domain.SaveLinkTag(favoriteLinkId, "token2");

            DataSet ds = domain.GetLinkTagsByFavoriteLinkID(favoriteLinkId);
            Assert.IsTrue(ds.Tables.Count > 0, "Must have table for LinkTags");
            Assert.IsTrue(ds.Tables[0].Rows.Count > 0, "Must have rows for LinkTags");
        }

        [Test]
        public void Test307_GetLinkTagsByProfileId()
        {
            long favoriteLinkId1 = domain.SaveFavoriteLink(_profileId1, "http://testlink1.com", "Test Link 1");
            domain.SaveLinkTag(favoriteLinkId1, "token1");
            long favoriteLinkId2 = domain.SaveFavoriteLink(_profileId1, "http://testlink2.com", "Test Link 1");
            domain.SaveLinkTag(favoriteLinkId2, "token2");

            DataSet ds = domain.GetLinkTagsByProfileID(_profileId1);
            Assert.IsTrue(ds.Tables.Count > 0, "Must have table for LinkTags");
            Assert.IsTrue(ds.Tables[0].Rows.Count > 0, "Must have rows for LinkTags");
        }

        
        [Test]
        public void Test350_LoadTest()
        {
            if (!_enableLoadTesting)
            {
                return;
            }
            String titleFormat = "Link {0}";
            String urlFormat = "http://testurl/{0}.html";

            TimeKeeper timeKeeper = new TimeKeeper();
            int maxLinks = 1000;
            double totalReflectionCastingTime = 0;
            double totalDirectCastingTime = 0;

            Console.WriteLine(String.Format("Starting test with {0} links", maxLinks));

            for (int i = 1; i <= maxLinks; i++)
            {
                string title = String.Format(titleFormat, i);
                string url = String.Format(urlFormat, i);
                domain.SaveFavoriteLink(_profileId1, title, url, true, 3, "A link", "loadtest", -1);
            }

            DataSet ds = domain.GetFavoriteLinksByProfileID(_profileId1);

            FavoriteLink.SelectedCastingMode = CastingMode.ReflectionCasting;
            timeKeeper.Start();
            FavoriteLinkCollection collection1 = new FavoriteLinkCollection();
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                FavoriteLink link = domain.Convert(row);
                collection1.Add(link);
            }
            timeKeeper.Stop();
            totalReflectionCastingTime += timeKeeper.Duration;
            timeKeeper.Reset();

            FavoriteLink.SelectedCastingMode = CastingMode.DirectCasting;
            timeKeeper.Start();
            FavoriteLinkCollection collection2 = new FavoriteLinkCollection();
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                FavoriteLink link = domain.Convert(row);
                collection2.Add(link);
            }
            timeKeeper.Stop();
            totalDirectCastingTime += timeKeeper.Duration;
            timeKeeper.Reset();
            
            Console.WriteLine(String.Format("Max Links: {0}", maxLinks));
            double avgReflectionTime = totalReflectionCastingTime/maxLinks*1000;
            double avgDirectTime = totalDirectCastingTime/maxLinks*1000;
            Console.WriteLine(String.Format("Avg Reflection Casting Time: {0} ms", avgReflectionTime));
            Console.WriteLine(String.Format("Avg Direct Casting Time: {0} ms", avgDirectTime));

            domain.PurgeProfile(_profileId1);
            _profileId1 = domain.GetFavoriteLinkProfileID(_userId1);
        }

        [Test]
        public void Test351_LoadWithReflectionCastingTest()
        {
            FavoriteLink.SelectedCastingMode = CastingMode.ReflectionCasting;
            RunSetAndGetLoadTesting();
        }

        [Test]
        public void Test352_LoadWithDirectCastingTest()
        {
            FavoriteLink.SelectedCastingMode = CastingMode.DirectCasting;
            RunSetAndGetLoadTesting();
        }

        private void RunSetAndGetLoadTesting() 
        {
            if (!_enableLoadTesting)
            {
                return;
            }
            String titleFormat = "Link {0}";
            String urlFormat = "http://testurl/{0}.html";

            TimeKeeper timeKeeper = new TimeKeeper();
            int maxLinks = 5;
            int totalTestRuns = 20;
            int currentRun = 1;
            double totalSaveTime = 0;
            double totalGetDataSetTime = 0;
            double totalGetDataReaderTime = 0;

            while (currentRun <= totalTestRuns)
            {
                Console.WriteLine(String.Format("Starting test run {0} of {1} with {2} links", currentRun, totalTestRuns, maxLinks));
                // pause for a moment to settle I/O
                Thread.Sleep(100);

                timeKeeper.Start();
                for (int i = 1; i <= maxLinks; i++)
                {
                    string title = String.Format(titleFormat, i);
                    string url = String.Format(urlFormat, i);
                    domain.SaveFavoriteLink(_profileId1, title, url, true, 3, "A link", "loadtest", -1);
                }
                timeKeeper.Stop();
                totalSaveTime += timeKeeper.Duration;
                timeKeeper.Reset();

                // pause for a moment to settle I/O
                Thread.Sleep(500);
                timeKeeper.Start();
                FavoriteLinkCollection collection2 = domain.GetFavoriteLinkCollection2(_profileId1);
                timeKeeper.Stop();
                totalGetDataReaderTime += timeKeeper.Duration;
                timeKeeper.Reset();

                // pause for a moment to settle I/O
                Thread.Sleep(500);
                timeKeeper.Start();
                FavoriteLinkCollection collection = domain.GetFavoriteLinkCollection(_profileId1);
                timeKeeper.Stop();
                totalGetDataSetTime += timeKeeper.Duration;
                timeKeeper.Reset();

                domain.PurgeProfile(_profileId1);
                _profileId1 = domain.GetFavoriteLinkProfileID(_userId1);

                // pause for a moment to settle I/O
                Thread.Sleep(500);

                currentRun++;
            }

            Console.WriteLine(String.Format("Max Links: {0}", maxLinks));
            double avgSaveTime = totalSaveTime/totalTestRuns/maxLinks*1000;
            double avgGetDataSetTime = totalGetDataSetTime/totalTestRuns/maxLinks*1000;
            double avgGetDataReaderTime = totalGetDataReaderTime/totalTestRuns/maxLinks*1000;
            Console.WriteLine(String.Format("Avg Save Time: {0} ms", avgSaveTime));
            Console.WriteLine(String.Format("Avg Get DataSet Time: {0} ms", avgGetDataSetTime));
            Console.WriteLine(String.Format("Avg Get IDataReader Time: {0} ms", avgGetDataReaderTime));
        }

        #endregion

        #region " Level 400 "

        [Test]
        public void Test401_LinqTest()
        {

            domain.SaveFavoriteLink(_profileId1, "http://abclink.com", "ABC Link");
            domain.SaveFavoriteLink(_profileId1, "http://deflink.com", "DEF Link");
            domain.SaveFavoriteLink(_profileId1, "http://ghilink.com", "GHI Link");

            FavoriteLinkCollection links = domain.GetLatest20FavoriteLinkCollection(_profileId1);
            FavoriteLinkCollection filteredLinks1 = LinqHelper.GetFilteredLinks(links, "abc");

            Assert.IsTrue(filteredLinks1.Count == 1, "There should be just 1 result");
            Console.WriteLine("ABC Link:");
            foreach (FavoriteLink favoriteLink in filteredLinks1)
            {
                Console.WriteLine(favoriteLink.Url);
            }

            FavoriteLinkCollection filteredLinks2 = LinqHelper.GetFilteredLinks(links, "link.com");
         
            Assert.IsTrue(filteredLinks2.Count == 3, "There should be just 3 results");
            Console.WriteLine("All Links:");
            foreach (FavoriteLink favoriteLink in filteredLinks2)
            {
                Console.WriteLine(favoriteLink.Url);
            }

        }

        [Test]
        public void Test402_LinqTest()
        {
            domain.SaveFavoriteLink(_profileId1, "http://abclink.com", "ABC Link");
            domain.SaveFavoriteLink(_profileId1, "http://deflink.com", "DEF Link");
            domain.SaveFavoriteLink(_profileId1, "http://ghilink.com", "GHI Link");

            FavoriteLinkCollection links = domain.GetLatest20FavoriteLinkCollection(_profileId1);
            List<String> urls = LinqHelper.GetUrls(links);
         
            Assert.IsTrue(urls.Count == 3, "There should be just 3 results");
            Console.WriteLine("Urls:");
            foreach (String url in urls)
            {
                Console.WriteLine(url);
            }

        }

        #endregion
        
        #region " Level 500 "

        [Test]
        public void Test501_WcfTest()
        {
            // fill in the test links
            domain.SaveFavoriteLink(_profileId1, "http://abclink.com", "ABC Link");
            domain.SaveFavoriteLink(_profileId1, "http://deflink.com", "DEF Link");
            domain.SaveFavoriteLink(_profileId1, "http://ghilink.com", "GHI Link");

            StartDataService();
            IFavoriteLinkService proxy = GetProxy();
            FavoriteLinkDataContract[] links = 
                proxy.GetLatest20FavoriteLinkCollection(_profileId1);

            Assert.IsTrue(links.Length == 3, "Array should have 3 links");
            Console.WriteLine("Links:");
            foreach (FavoriteLinkDataContract link in links)
            {
                Console.WriteLine(link.Url);
            }

            StopDataService();
        }

        private ServiceHost dataHost;
        private string serviceUri = "http://localhost:8015/FavoriteLinkService/";

        public void StartDataService()
        {
            Binding binding = new BasicHttpBinding();
            Uri address = new Uri(serviceUri);
            dataHost = new ServiceHost(typeof(FavoriteLinkService));
            dataHost.AddServiceEndpoint(
                typeof(IFavoriteLinkService), binding, address);
            Trace.WriteLine("Starting service: " + address);
            dataHost.Open();
        }

        public void StopDataService()
        {
            if (dataHost != null)
            {
                dataHost.Close();
            }
        }

        public IFavoriteLinkService GetProxy()
        {
            
            Binding binding = new BasicHttpBinding();
            Uri address = new Uri(serviceUri);

            ChannelFactory<IFavoriteLinkService> factory = 
            new ChannelFactory<IFavoriteLinkService>(
                binding,
                new EndpointAddress(address));

            IFavoriteLinkService proxy = factory.CreateChannel();
            return proxy;
        }
        
        #endregion

        #region " Level 600 "

        [Test]
        public void Test601_NameChange()
        {
            Name = "John Q Public";

            Assert.AreEqual("John", FirstName, "FirstName should match");
            Assert.AreEqual("Q", MiddleInitial, "MiddleInitial should match");
            Assert.AreEqual("Public", LastName, "LastName should match");

            Name = "John Public";
            
            Assert.AreEqual("John", FirstName, "FirstName should match");
            Assert.AreEqual("", MiddleInitial, "MiddleInitial should match");
            Assert.AreEqual("Public", LastName, "LastName should match");
        }

        private String _firstName = String.Empty;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        private String _middleInitial = String.Empty;

        public string MiddleInitial
        {
            get {
                return _middleInitial;
            }
            set
            {
                _middleInitial = value;
            }
        }
        
        private String _lastName = String.Empty;

        public string LastName
        {
            get {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        /// <summary>
        /// Expects a name formatted like "John Q Public" or "John Public"
        /// </summary>
        [Obsolete("Use FirstName, MiddleInitial and LastName")]
        public string Name
        {
            get
            {
                if (String.IsNullOrEmpty(MiddleInitial))
                {
                    return FirstName + " " + LastName;
                }
                return FirstName + " " + MiddleInitial + " " + LastName;
            }
            set
            {
                string[] parts = value.Split(" ".ToCharArray()[0]);
                FirstName = parts[0];
                if (parts.Length > 2)
                {
                    MiddleInitial = parts[1];
                    LastName = parts[2];
                }
                else if (parts.Length > 1)
                {
                    MiddleInitial = String.Empty;
                    LastName = parts[1];
                }
            }
        }
        public String anyString;
        
        [Test]
        public void TestAnyString()
        {
            String anotherString;
            Assert.IsNull(anyString, "value should be null");
            //Assert.IsNull(anotherString, "value is not initialized");
            Console.WriteLine("String values: " + anyString);
        }

        private void ShowLinks(FavoriteLinkCollection links)
        {
            foreach (FavoriteLink link in links)
            {
                Console.WriteLine(link.Title + " : " + link.Url);
            }
        }

        private void CheckNull()
        {
            DataRow row = null;
            String title = null;
            if (DBNull.Value.Equals(row["Title"]))
            {
                title = row["Title"] as String;
            }
        }
        
        [Test]
        public void Test602_GetNullables()
        {
            DataSet ds = domain.GetNullables();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    String name;
                    String color;
                    DateTime? birthDate;
                    if (DBNull.Value.Equals(row["Name"]) && row["Name"] is DateTime)
                    {
                        name = (string)row["Name"];
                    }
                    name = row["Name"] as string;
                    color = row["Color"] as string;
                    birthDate = row["BirthDate"] as DateTime?;
                }
            }
        }
        
        #endregion

    }
}
