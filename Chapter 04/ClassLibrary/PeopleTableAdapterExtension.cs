using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Chapter04.Chapter04DomainTableAdapters
{
    public partial class PeopleTableAdapter
    {

        private Database db = DatabaseFactory.CreateDatabase("chpt04");

        public int GetAllPeopleRowCount()
        {
            int count = 0;
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

    }
}
