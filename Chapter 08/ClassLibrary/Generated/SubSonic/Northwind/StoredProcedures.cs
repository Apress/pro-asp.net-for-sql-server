using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;



namespace Chapter08.NorthwindDAL{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the Ten Most Expensive Products Procedure
        /// </summary>
        public static StoredProcedure TenMostExpensiveProducts()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Ten Most Expensive Products" , DataService.GetInstance("Northwind"));
        	
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the SubSonicTest Procedure
        /// </summary>
        public static StoredProcedure SubSonicTest(DateTime param)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SubSonicTest" , DataService.GetInstance("Northwind"));
        	
            sp.Command.AddOutputParameter("@param",DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the Employee Sales by Country Procedure
        /// </summary>
        public static StoredProcedure EmployeeSalesbyCountry(DateTime BeginningDate, DateTime EndingDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Employee Sales by Country" , DataService.GetInstance("Northwind"));
        	
            sp.Command.AddParameter("@Beginning_Date", BeginningDate,DbType.DateTime);
        	    
            sp.Command.AddParameter("@Ending_Date", EndingDate,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the SubSonicTestNW Procedure
        /// </summary>
        public static StoredProcedure SubSonicTestNW(DateTime param)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SubSonicTestNW" , DataService.GetInstance("Northwind"));
        	
            sp.Command.AddOutputParameter("@param",DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the Sales by Year Procedure
        /// </summary>
        public static StoredProcedure SalesbyYear(DateTime BeginningDate, DateTime EndingDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Sales by Year" , DataService.GetInstance("Northwind"));
        	
            sp.Command.AddParameter("@Beginning_Date", BeginningDate,DbType.DateTime);
        	    
            sp.Command.AddParameter("@Ending_Date", EndingDate,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the CustOrdersDetail Procedure
        /// </summary>
        public static StoredProcedure CustOrdersDetail(int OrderID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CustOrdersDetail" , DataService.GetInstance("Northwind"));
        	
            sp.Command.AddParameter("@OrderID", OrderID,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the CustOrdersOrders Procedure
        /// </summary>
        public static StoredProcedure CustOrdersOrders(string CustomerID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CustOrdersOrders" , DataService.GetInstance("Northwind"));
        	
            sp.Command.AddParameter("@CustomerID", CustomerID,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the CustOrderHist Procedure
        /// </summary>
        public static StoredProcedure CustOrderHist(string CustomerID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CustOrderHist" , DataService.GetInstance("Northwind"));
        	
            sp.Command.AddParameter("@CustomerID", CustomerID,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the SalesByCategory Procedure
        /// </summary>
        public static StoredProcedure SalesByCategory(string CategoryName, string OrdYear)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SalesByCategory" , DataService.GetInstance("Northwind"));
        	
            sp.Command.AddParameter("@CategoryName", CategoryName,DbType.String);
        	    
            sp.Command.AddParameter("@OrdYear", OrdYear,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the Peaches Procedure
        /// </summary>
        public static StoredProcedure Peaches(string tablename, string mapSuffix)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Peaches" , DataService.GetInstance("Northwind"));
        	
            sp.Command.AddParameter("@tablename", tablename,DbType.String);
        	    
            sp.Command.AddParameter("@mapSuffix", mapSuffix,DbType.String);
        	    
            return sp;
        }

        
    }

    
}

