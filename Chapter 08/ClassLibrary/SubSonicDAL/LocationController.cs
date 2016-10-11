using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Chapter08.SubSonicDAL
{
    public partial class LocationController
    {

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LocationCollection FetchByCity(string city)
        {
            LocationCollection coll = new LocationCollection().
                Where(Location.Columns.City, city).Load();
            return coll;
        }

    }
}
