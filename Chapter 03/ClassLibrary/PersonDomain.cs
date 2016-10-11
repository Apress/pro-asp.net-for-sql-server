using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Chapter03
{
    [DataObject(true)]
    public class PersonDomain
    {

        private Random rndNum = new Random();
        private int days30 = 30 * 365;

        private Dictionary<String, int> locationRanges = null;

        /// <summary>
        /// This is used as a global connection for database connectivity
        /// </summary>
        private Database db;

        public PersonDomain()
        {
            db = DatabaseFactory.CreateDatabase("chpt03");
        }

        public void RegenerateData(int count)
        {
            ClearData();
            PopulateData();
            int i = 0;
            while (i < count)
            {
                string firstName = GetRandomFirstName();
                string lastName = GetRandomLastName();
                DateTime birthDate = GetRandomBirthDate();
                int locationId = GetRandomLocation();
                SavePerson(firstName, lastName, birthDate, locationId);
                i++;
            }
        }

        private void ClearData()
        {
            using (DbCommand dbCmd = db.GetStoredProcCommand("chpt03_ClearData"))
            {
                db.ExecuteNonQuery(dbCmd);
            }
        }

        private void PopulateData()
        {
            using (DbCommand dbCmd = db.GetStoredProcCommand("chpt03_PopulateData"))
            {
                db.ExecuteNonQuery(dbCmd);
            }
        }

        private long SavePerson(string firstName, string lastName, DateTime birthDate, int locationId)
        {
            long personId = 0;
            using (DbCommand dbCmd = db.GetStoredProcCommand("chpt03_SavePerson"))
            {
                db.AddInParameter(dbCmd, "@FirstName", DbType.String, firstName);
                db.AddInParameter(dbCmd, "@LastName", DbType.String, lastName);
                db.AddInParameter(dbCmd, "@BirthDate", DbType.DateTime, birthDate);
                db.AddInParameter(dbCmd, "@LocationId", DbType.String, locationId);
                db.AddOutParameter(dbCmd, "@PersonId", DbType.Int64, 0);

                db.ExecuteNonQuery(dbCmd);
                personId = (long)db.GetParameterValue(dbCmd, "@PersonId");
            }
            return personId;
        }

        #region "  Select Methods  "

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IDataReader GetAllPeopleReader()
        {
            IDataReader dr = null;

            using (DbCommand dbCmd = db.GetStoredProcCommand("chpt03_GetAllPeople"))
            {
                dr = db.ExecuteReader(dbCmd);
            }

            //return the results
            return dr;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetAllPeopleDataSet()
        {
            DataSet ds = new DataSet();

            using (DbCommand dbCmd = 
              db.GetStoredProcCommand("chpt03_GetAllPeople"))
            {
                ds = db.ExecuteDataSet(dbCmd);
            }

            //return the results
            return ds;
        }

        public long? GetPeopleRowCount()
        {
            long? count = 0;

            using (DbCommand dbCmd = db.GetStoredProcCommand("chpt03_GetPeopleRowCount"))
            {
                db.AddOutParameter(dbCmd, "@Count", DbType.Int64, 0);

                db.ExecuteNonQuery(dbCmd);
                count = (long)db.GetParameterValue(dbCmd, "@Count");
            }

            return count;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetPeopleSubSetSortedDataSet(int? startRowIndex, int? maximumRows)
        {
            return GetPeopleSubSetSortedDataSet(null, startRowIndex, maximumRows);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetPeopleSubSetSortedDataSet(
            string sortExpression, int? startRowIndex, int? maximumRows)
        {
            DataSet ds = new DataSet();
            if (String.IsNullOrEmpty(sortExpression))
            {
                sortExpression = "";
            }
            if (!startRowIndex.HasValue)
            {
                startRowIndex = 0;
            }
            if (!maximumRows.HasValue)
            {
                maximumRows = 0;
            }

            using (DbCommand dbCmd = db.GetStoredProcCommand("chpt03_GetPeopleSubSetSorted"))
            {
                db.AddInParameter(dbCmd, "@sortExpression", DbType.String, sortExpression);
                db.AddInParameter(dbCmd, "@startRowIndex", DbType.Int64, startRowIndex);
                db.AddInParameter(dbCmd, "@maximumRows", DbType.Int64, maximumRows);

                ds = db.ExecuteDataSet(dbCmd);
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IDataReader GetPeopleSubSetSortedReader(int? startRowIndex, int? maximumRows)
        {
            return GetPeopleSubSetSortedReader(null, startRowIndex, maximumRows);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IDataReader GetPeopleSubSetSortedReader(
            string sortExpression, int? startRowIndex, int? maximumRows)
        {
            IDataReader dr = null;
            if (String.IsNullOrEmpty(sortExpression))
            {
                sortExpression = String.Empty;
            }
            if (!startRowIndex.HasValue)
            {
                startRowIndex = 0;
            }
            if (!maximumRows.HasValue)
            {
                maximumRows = 0;
            }

            using (DbCommand dbCmd = db.GetStoredProcCommand("chpt03_GetPeopleSubSetSorted"))
            {
                db.AddInParameter(dbCmd, "@sortExpression", DbType.String, sortExpression);
                db.AddInParameter(dbCmd, "@startRowIndex", DbType.Int64, startRowIndex);
                db.AddInParameter(dbCmd, "@maximumRows", DbType.Int64, maximumRows);

                dr = db.ExecuteReader(dbCmd);
            }

            //return the results
            return dr;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetPeopleByLocationDataSet(int locationId)
        {
            DataSet ds = new DataSet();

            using (DbCommand dbCmd = db.GetStoredProcCommand("chpt03_GetPeopleByLocation"))
            {
                db.AddInParameter(dbCmd, "@LocationId", DbType.Int64, locationId);
                ds = db.ExecuteDataSet(dbCmd);
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IDataReader GetPeopleByLocationDataReader(int locationId)
        {
            IDataReader dr = null;

            using (DbCommand dbCmd = db.GetStoredProcCommand("chpt03_GetPeopleByLocation"))
            {
                db.AddInParameter(dbCmd, "@LocationId", DbType.Int64, locationId);
                dr = db.ExecuteReader(dbCmd);
            }

            //return the results
            return dr;
        }

        #endregion

        #region "  Helper Methods  "

        private string GetRandomFirstName()
        {
            return FirstNames[rndNum.Next(FirstNames.Length)];
        }

        private string GetRandomLastName()
        {
            return LastNames[rndNum.Next(LastNames.Length)];
        }

        private DateTime GetRandomBirthDate()
        {
            int daysOld = rndNum.Next(days30) + days30;
            DateTime birthDate = DateTime.Now.AddDays(-daysOld);
            return birthDate;
        }

        private int GetRandomLocation()
        {
            // use GetLocationRanges to select a random location
            if (locationRanges == null)
            {
                locationRanges = GetLocationRanges();
            }
            int locationId = rndNum.Next(locationRanges["MinId"], locationRanges["MaxId"] + 1);
            return locationId;
        }

        public Dictionary<String, int> GetLocationRanges()
        {
            Dictionary<String, int> dict = new Dictionary<String, int>();

            using (DbCommand dbCmd = db.GetStoredProcCommand("chpt03_GetLocationRanges"))
            {
                db.AddOutParameter(dbCmd, "@MinId", DbType.Int32, 0);
                db.AddOutParameter(dbCmd, "@MaxId", DbType.Int32, 0);

                db.ExecuteNonQuery(dbCmd);
                int minId = (int)db.GetParameterValue(dbCmd, "@MinId");
                int maxId = (int)db.GetParameterValue(dbCmd, "@MaxId");
                dict["MinId"] = minId;
                dict["MaxId"] = maxId;
            }

            //return the results
            return dict;
        }
        #endregion

        #region "  Properties  "

        private string[] _firstNames = null;
        public string[] FirstNames
        {
            get
            {
                if (_firstNames == null)
                {
                    _firstNames = new string[]
                        {
                            "John", 
                            "Bob", 
                            "Paul", 
                            "Jim", 
                            "Tim", 
                            "Tom", 
                            "Jake", 
                            "Sandy", 
                            "Terry", 
                            "Kim", 
                            "Chris", 
                            "Lisa", 
                            "Amy", 
                            "Stacey", 
                            "James", 
                            "Jared", 
                            "Kevin", 
                            "Mike", 
                            "Dave"
                        };
                }
                return _firstNames;
            }
        }

        private string[] _lastNames = null;
        public string[] LastNames
        {
            get
            {
                if (_lastNames == null)
                {
                    _lastNames = new string[]
                        {
                            "Smith", 
                            "Thompson", 
                            "Marshall", 
                            "Peterson", 
                            "Williams", 
                            "Hanselman", 
                            "Lukes", 
                            "Butler", 
                            "Jameson", 
                            "O'Malley", 
                            "Stewart", 
                            "Baker", 
                            "Douglas", 
                            "Davidson", 
                            "Palmer", 
                            "Lee", 
                            "Johnson"
                        };
                }
                return _lastNames;
            }
        }
        #endregion

    }
}
