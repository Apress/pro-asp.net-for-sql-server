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



namespace Chapter08.NorthwindDAL
{
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string Category = @"Category";
        
		public static string CustomerCustomerDemo = @"CustomerCustomerDemo";
        
		public static string CustomerDemographic = @"CustomerDemographic";
        
		public static string Customer = @"Customer";
        
		public static string Employee = @"Employee";
        
		public static string EmployeeTerritory = @"EmployeeTerritory";
        
		public static string OrderDetail = @"OrderDetail";
        
		public static string Order = @"Order";
        
		public static string ProductCategoryMap = @"ProductCategoryMap";
        
		public static string Product = @"Product";
        
		public static string Region = @"Region";
        
		public static string Shipper = @"Shipper";
        
		public static string Supplier = @"Supplier";
        
		public static string Territory = @"Territory";
        
		public static string TextEntry = @"TextEntry";
        
	}

	#endregion
    #region View Struct
    public partial struct Views 
    {
		
		public static string Alphabeticallistofproduct = @"Alphabeticallistofproduct";
        
		public static string CategorySalesfor1997 = @"CategorySalesfor1997";
        
		public static string CurrentProductList = @"CurrentProductList";
        
		public static string CustomerandSuppliersbyCity = @"CustomerandSuppliersbyCity";
        
		public static string Invoice = @"Invoice";
        
		public static string OrderDetailsExtended = @"OrderDetailsExtended";
        
		public static string OrderSubtotal = @"OrderSubtotal";
        
		public static string OrdersQry = @"OrdersQry";
        
		public static string ProductSalesfor1997 = @"ProductSalesfor1997";
        
		public static string ProductsAboveAveragePrice = @"ProductsAboveAveragePrice";
        
		public static string ProductsbyCategory = @"ProductsbyCategory";
        
		public static string QuarterlyOrder = @"QuarterlyOrder";
        
		public static string SalesbyCategory = @"SalesbyCategory";
        
		public static string SalesTotalsbyAmount = @"SalesTotalsbyAmount";
        
		public static string SummaryofSalesbyQuarter = @"SummaryofSalesbyQuarter";
        
		public static string SummaryofSalesbyYear = @"SummaryofSalesbyYear";
        
    }

    #endregion
}


namespace Chapter08.SubSonicDAL
{
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string Location = @"Location";
        
		public static string Person = @"Person";
        
	}

	#endregion
    #region View Struct
    public partial struct Views 
    {
		
    }

    #endregion
}

#region Databases
public partial struct Databases 
{
	
	public static string Northwind = @"Northwind";
    
	public static string Chapter08 = @"Chapter08";
    
}

#endregion
