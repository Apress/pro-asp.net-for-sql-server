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

namespace Chapter08.SubSonicDAL
{
    public partial class Person : ActiveRecord<Person>
    {
        /// <summary>
        /// FirstName and LastName combined
        /// </summary>
        public string FullName {
            get {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}
