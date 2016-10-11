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
    /// <summary>
    /// Strongly-typed collection for the CustomerandSuppliersbyCity class.
    /// </summary>
    [Serializable]
    public partial class CustomerandSuppliersbyCityCollection : ReadOnlyList<CustomerandSuppliersbyCity>
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public CustomerandSuppliersbyCityCollection OrderByAsc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public CustomerandSuppliersbyCityCollection OrderByDesc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

        public CustomerandSuppliersbyCityCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
        {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public CustomerandSuppliersbyCityCollection Where(Where where) 
        {
            wheres.Add(where);
            return this;
        }

    	
        public CustomerandSuppliersbyCityCollection Where(string columnName, object value) 
        {
            if(value != DBNull.Value && value != null)
            {	
                return Where(columnName, Comparison.Equals, value);
            }

            else
            {
                return Where(columnName, Comparison.Is, DBNull.Value);
            }

        }

    	
        public CustomerandSuppliersbyCityCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public CustomerandSuppliersbyCityCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            BetweenAnd between = new BetweenAnd();
            between.ColumnName = columnName;
            between.StartDate = dateStart;
            between.EndDate = dateEnd;
            between.StartParameterName = "start" + columnName; 
            between.EndParameterName = "end" + columnName; 
            betweens.Add(between);
            return this;
        }

    	
        public CustomerandSuppliersbyCityCollection Load() 
	    {
            Query qry = new Query(CustomerandSuppliersbyCity.Schema);
            CheckLogicalDelete(qry);
            foreach (Where where in wheres) 
            {
                qry.AddWhere(where);
            }

             
            foreach (BetweenAnd between in betweens)
            {
                qry.AddBetweenAnd(between);
            }

            if (orderBy != null)
            {
                qry.OrderBy = orderBy;
            }

            IDataReader rdr = qry.ExecuteReader();
            this.Load(rdr);
            rdr.Close();
            return this;
        }

        
        public CustomerandSuppliersbyCityCollection() 
        {
            
        }

    }

    /// <summary>
    /// This is  Read-only wrapper class for the Customer and Suppliers by City view.
    /// </summary>
    [Serializable]
    public partial class CustomerandSuppliersbyCity : ReadOnlyRecord<CustomerandSuppliersbyCity> 
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }

	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }

                return BaseSchema;
            }

        }

    	
        private static void GetTableSchema() 
        {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("Customer and Suppliers by City", TableType.View, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarCity = new TableSchema.TableColumn(schema);
                colvarCity.ColumnName = "City";
                colvarCity.DataType = DbType.String;
                colvarCity.MaxLength = 15;
                colvarCity.AutoIncrement = false;
                colvarCity.IsNullable = true;
                colvarCity.IsPrimaryKey = false;
                colvarCity.IsForeignKey = false;
                colvarCity.IsReadOnly = false;
                
                schema.Columns.Add(colvarCity);
                
                TableSchema.TableColumn colvarCompanyName = new TableSchema.TableColumn(schema);
                colvarCompanyName.ColumnName = "CompanyName";
                colvarCompanyName.DataType = DbType.String;
                colvarCompanyName.MaxLength = 40;
                colvarCompanyName.AutoIncrement = false;
                colvarCompanyName.IsNullable = false;
                colvarCompanyName.IsPrimaryKey = false;
                colvarCompanyName.IsForeignKey = false;
                colvarCompanyName.IsReadOnly = false;
                
                schema.Columns.Add(colvarCompanyName);
                
                TableSchema.TableColumn colvarContactName = new TableSchema.TableColumn(schema);
                colvarContactName.ColumnName = "ContactName";
                colvarContactName.DataType = DbType.String;
                colvarContactName.MaxLength = 30;
                colvarContactName.AutoIncrement = false;
                colvarContactName.IsNullable = true;
                colvarContactName.IsPrimaryKey = false;
                colvarContactName.IsForeignKey = false;
                colvarContactName.IsReadOnly = false;
                
                schema.Columns.Add(colvarContactName);
                
                TableSchema.TableColumn colvarRelationship = new TableSchema.TableColumn(schema);
                colvarRelationship.ColumnName = "Relationship";
                colvarRelationship.DataType = DbType.String;
                colvarRelationship.MaxLength = 9;
                colvarRelationship.AutoIncrement = false;
                colvarRelationship.IsNullable = false;
                colvarRelationship.IsPrimaryKey = false;
                colvarRelationship.IsForeignKey = false;
                colvarRelationship.IsReadOnly = false;
                
                schema.Columns.Add(colvarRelationship);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Customer and Suppliers by City",schema);
            }

        }

        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }

	    #endregion
	    
	    #region .ctors
	    public CustomerandSuppliersbyCity()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public CustomerandSuppliersbyCity(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public CustomerandSuppliersbyCity(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("City")]
        public string City 
	    {
		    get
		    {
			    return GetColumnValue<string>("City");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("City", value);
            }

        }

	      
        [XmlAttribute("CompanyName")]
        public string CompanyName 
	    {
		    get
		    {
			    return GetColumnValue<string>("CompanyName");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CompanyName", value);
            }

        }

	      
        [XmlAttribute("ContactName")]
        public string ContactName 
	    {
		    get
		    {
			    return GetColumnValue<string>("ContactName");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ContactName", value);
            }

        }

	      
        [XmlAttribute("Relationship")]
        public string Relationship 
	    {
		    get
		    {
			    return GetColumnValue<string>("Relationship");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Relationship", value);
            }

        }

	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string City  = @"City";
            
            public static string CompanyName  = @"CompanyName";
            
            public static string ContactName  = @"ContactName";
            
            public static string Relationship  = @"Relationship";
            
	    }

	    #endregion
    }

}
