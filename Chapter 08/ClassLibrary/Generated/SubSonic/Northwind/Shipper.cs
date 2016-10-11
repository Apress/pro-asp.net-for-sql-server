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


//Generated on 6/10/2007 10:06:59 PM by brennan

namespace Chapter08.NorthwindDAL{
    /// <summary>
    /// Strongly-typed collection for the Shipper class.
    /// </summary>
    [Serializable]
    public partial class ShipperCollection : ActiveList<Shipper> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public ShipperCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public ShipperCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public ShipperCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public ShipperCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public ShipperCollection Where(string columnName, object value) 
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

    	
        public ShipperCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public ShipperCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public ShipperCollection Load() 
        {
            Query qry = new Query(Shipper.Schema);
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

        
        public ShipperCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Shippers table.
    /// </summary>
    [Serializable]
    public partial class Shipper : ActiveRecord<Shipper>
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
				TableSchema.Table schema = new TableSchema.Table("Shippers", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarShipperID = new TableSchema.TableColumn(schema);
                colvarShipperID.ColumnName = "ShipperID";
                colvarShipperID.DataType = DbType.Int32;
                colvarShipperID.MaxLength = 0;
                colvarShipperID.AutoIncrement = true;
                colvarShipperID.IsNullable = false;
                colvarShipperID.IsPrimaryKey = true;
                colvarShipperID.IsForeignKey = false;
                colvarShipperID.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarShipperID);
                
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
                
                TableSchema.TableColumn colvarPhone = new TableSchema.TableColumn(schema);
                colvarPhone.ColumnName = "Phone";
                colvarPhone.DataType = DbType.String;
                colvarPhone.MaxLength = 24;
                colvarPhone.AutoIncrement = false;
                colvarPhone.IsNullable = true;
                colvarPhone.IsPrimaryKey = false;
                colvarPhone.IsForeignKey = false;
                colvarPhone.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarPhone);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Shippers",schema);
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
	    public Shipper()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Shipper(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public Shipper(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("ShipperID")]
        public int ShipperID 
	    {
		    get { return GetColumnValue<int>("ShipperID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipperID", value);
            }

        }

	      
        [XmlAttribute("CompanyName")]
        public string CompanyName 
	    {
		    get { return GetColumnValue<string>("CompanyName"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CompanyName", value);
            }

        }

	      
        [XmlAttribute("Phone")]
        public string Phone 
	    {
		    get { return GetColumnValue<string>("Phone"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Phone", value);
            }

        }

	    
	    #endregion
	    
	    
	    #region PrimaryKey Methods
	    
		public Chapter08.NorthwindDAL.OrderCollection Orders()
		{
			return new Chapter08.NorthwindDAL.OrderCollection().Where(Order.Columns.ShipVia, ShipperID).Load();
		}

		#endregion
		
	 	
			
	    
	    //no foreign key tables defined (0)
	    
	    
	    
	    //no ManyToMany tables defined (0)
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(string varCompanyName,string varPhone)
	    {
		    Shipper item = new Shipper();
		    
            item.CompanyName = varCompanyName;
            
            item.Phone = varPhone;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(int varShipperID,string varCompanyName,string varPhone)
	    {
		    Shipper item = new Shipper();
		    
                item.ShipperID = varShipperID;
				
                item.CompanyName = varCompanyName;
				
                item.Phone = varPhone;
				
		    item.IsNew = false;
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

	    #endregion
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string ShipperID = @"ShipperID";
            
            public static string CompanyName = @"CompanyName";
            
            public static string Phone = @"Phone";
            
	    }

	    #endregion
    }

}

