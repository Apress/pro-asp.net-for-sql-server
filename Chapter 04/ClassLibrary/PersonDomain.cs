using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Chapter04
{
    [DataObject(true)]
    public class PersonDomain
    {

        #region "  Variables  "

        private Random rndNum = new Random();
        private int days30 = 30 * 365;

        private Dictionary<String, Int32> locationRanges = null;

        /// <summary>
        /// This is used as a global connection for database connectivity
        /// </summary>
        private Database db;

        #endregion

        #region "  Constructor  "

        public PersonDomain()
        {
            db = DatabaseFactory.CreateDatabase("chpt04");
        }

        #endregion

        #region "  Data Update Methods  "

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
            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_ClearData"))
                {
                    db.ExecuteNonQuery(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }
        }

        private void PopulateData()
        {
            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_PopulateData"))
                {
                    db.ExecuteNonQuery(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }
        }

        private int SavePerson(string firstName, string lastName, DateTime birthDate, int locationId)
        {
            Int32 personId = 0;
            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_SavePerson"))
                {
                    db.AddInParameter(dbCmd, "@FirstName", DbType.String, firstName);
                    db.AddInParameter(dbCmd, "@LastName", DbType.String, lastName);
                    db.AddInParameter(dbCmd, "@BirthDate", DbType.DateTime, birthDate);
                    db.AddInParameter(dbCmd, "@LocationId", DbType.String, locationId);
                    db.AddOutParameter(dbCmd, "@PersonId", DbType.Int32, 0);

                    db.ExecuteNonQuery(dbCmd);
                    personId = (Int32) db.GetParameterValue(dbCmd, "@PersonId");
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }
            return personId;
        }

        #endregion

        #region "  Select Methods  "

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IDataReader GetAllPeopleReader()
        {
            IDataReader dr = null;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_GetAllPeople"))
                {
                    dr = db.ExecuteReader(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }

            //return the results
            return dr;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetAllPeopleDataSet()
        {
            DataSet ds = new DataSet();

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_GetAllPeople"))
                {
                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }

            //return the results
            return ds;
        }

        public DataSet GetAllPeopleDataSet(int startRowIndex, int maximumRows)
        {
            DataSet ds = GetPeopleSubSetSortedDataSet(startRowIndex, maximumRows);
            return ds;
        }

        public int? GetPeopleRowCount()
        {
            int? count = 0;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_GetAllPeopleRowCount"))
                {
                    db.AddOutParameter(dbCmd, "@Count", DbType.Int32, 0);

                    db.ExecuteNonQuery(dbCmd);
                    count = (int)db.GetParameterValue(dbCmd, "@Count");
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }
            return count;
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public DataSet GetPeopleSubSetSortedDataSet(int? startRowIndex, int? maximumRows)
        {
            return GetPeopleSubSetSortedDataSet(null, startRowIndex, maximumRows);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
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

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_GetPeopleSubSetSorted"))
                {
                    db.AddInParameter(dbCmd, "@sortExpression", DbType.String, sortExpression);
                    db.AddInParameter(dbCmd, "@startRowIndex", DbType.Int32, startRowIndex);
                    db.AddInParameter(dbCmd, "@maximumRows", DbType.Int32, maximumRows);

                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public IDataReader GetPeopleSubSetSortedReader(int? startRowIndex, int? maximumRows)
        {
            return GetPeopleSubSetSortedReader(null, startRowIndex, maximumRows);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public IDataReader GetPeopleSubSetSortedReader(
            string sortExpression, int? startRowIndex, int? maximumRows)
        {
            IDataReader dr = null;
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

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_GetPeopleSubSetSorted"))
                {
                    db.AddInParameter(dbCmd, "@sortExpression", DbType.String, sortExpression);
                    db.AddInParameter(dbCmd, "@startRowIndex", DbType.Int32, startRowIndex);
                    db.AddInParameter(dbCmd, "@maximumRows", DbType.Int32, maximumRows);

                    dr = db.ExecuteReader(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }

            //return the results
            return dr;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetPeopleByLocationDataSet(int locationId)
        {
            DataSet ds = new DataSet();

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_GetPeopleByLocation"))
                {
                    db.AddInParameter(dbCmd, "@LocationId", DbType.Int32, locationId);
                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IDataReader GetPeopleByLocationDataReader(int locationId)
        {
            IDataReader dr = null;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_GetPeopleByLocation"))
                {
                    db.AddInParameter(dbCmd, "@LocationId", DbType.Int32, locationId);
                    dr = db.ExecuteReader(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }

            //return the results
            return dr;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetLastNames()
        {
            DataSet ds;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_GetLastNames"))
                {
                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetPeopleByLastName(string lastName)
        {
            DataSet ds;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_GetPeopleByLastName"))
                {
                    db.AddInParameter(dbCmd, "@LastName", DbType.String, lastName);
                    
                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetAllCountries()
        {
            DataSet ds;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_GetAllCountries"))
                {
                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }

            //return the results
            return ds;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetCitiesByCountry(string country)
        {
            DataSet ds;

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_GetCitiesByCountry"))
                {
                    db.AddInParameter(dbCmd, "@Country", DbType.String, country);

                    ds = db.ExecuteDataSet(dbCmd);
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
            }

            //return the results
            return ds;
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

        public Dictionary<String, Int32> GetLocationRanges()
        {
            Dictionary<String, Int32> dict = new Dictionary<String, Int32>();

            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("chpt04_GetLocationRanges"))
                {
                    db.AddOutParameter(dbCmd, "@MinId", DbType.Int32, 0);
                    db.AddOutParameter(dbCmd, "@MaxId", DbType.Int32, 0);

                    db.ExecuteNonQuery(dbCmd);
                    Int32 minId = (Int32)db.GetParameterValue(dbCmd, "@MinId");
                    Int32 maxId = (Int32)db.GetParameterValue(dbCmd, "@MaxId");
                    dict["MinId"] = minId;
                    dict["MaxId"] = maxId;
                }
            }
            catch (Exception ex)
            {
                // TODO Log Error
                throw;
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
                            "Rory", 
                            "Carl", 
                            "Scott", 
                            "Terry", 
                            "Mark", 
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
                            "Campbell", 
                            "Blyth", 
                            "Franklin", 
                            "Hanselman", 
                            "Miller", 
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
