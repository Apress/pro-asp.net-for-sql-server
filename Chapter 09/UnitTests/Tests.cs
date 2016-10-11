using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using Chapter09.Configuration;
using Chapter09.Database;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        
        #region "  Member Variables  "

        #endregion

        #region " SetUp and TearDown "

        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        #endregion
        
        #region " Tests "

        [Test]
        public void Test100_ReadDatabaseScripts()
        {
            Type type = typeof(DatabaseManager);

            foreach (string name in type.Assembly.GetManifestResourceNames())
            {
                Console.WriteLine(name);
            }

            Stream stream = type.Assembly.GetManifestResourceStream("Chapter09.Database.Scripts.init.sql");
            if (stream != null)
            {
                StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader(stream);
                sb.Append(sr.ReadToEnd());
                Console.WriteLine(sb);
            }
        }

        [Test]
        public void Test101_ReadInitCommands()
        {
            DatabaseManager dbm = new DatabaseManager();
            List<string> commands = dbm.GetSqlCommands("Chapter09.Database.Scripts.init.sql");
            foreach (string command in commands)
            {
                Console.WriteLine(command);
                Console.WriteLine("###");
            }
        }

        [Test]
        public void Test102_InitDatabase()
        {
            DatabaseManager dbm = new DatabaseManager();
            dbm.InitializeDatabase();
        }

        [Test]
        public void Test103_ReadConfiguration()
        {
            Configuration config = 
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
             Chapter09SectionGroup chapter09Config = 
                (Chapter09SectionGroup) config.SectionGroups["chapter09Group"];

            Chapter09Section section = chapter09Config.Chapter09Section;
            Assert.IsNotNull(section);
            Console.WriteLine("ConnectionStringName: " + section.ConnectionStringName);
            Assert.IsNotEmpty(section.ConnectionStringName);
        }

        [Test]
        public void Test104_ReadConfiguration()
        {
            Chapter09SectionGroup chapter09Config = Chapter09Configuration.GetConfig();
            Chapter09Section section = chapter09Config.Chapter09Section;
            Assert.IsNotNull(section);
            Console.WriteLine("ConnectionStringName: " + section.ConnectionStringName);
            Assert.IsNotEmpty(section.ConnectionStringName);
        }

        [Test]
        public void Test105_ReadConfiguration()
        {
            Chapter09SectionGroup chapter09Config = Chapter09Configuration.GetConfig();
            Chapter09Section section = chapter09Config.Chapter09Section;
            Assert.IsNotNull(section);
            Console.WriteLine("EnableAutoUpdates: " + section.EnableAutoUpdates);
            Assert.IsTrue(section.EnableAutoUpdates);
        }

        #endregion

    }
}
