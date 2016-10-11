using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Chapter07.WCFService
{
    [DataContract]
    public class FavoriteLinkDataContract
    {
        
        private string _url;
        
        [DataMember(Name = "Url",Order = 1)]
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _title;
        
        [DataMember(Name = "Title",Order = 1)]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private bool _keeper;
        
        [DataMember(Name = "Keeper",Order = 1)]
        public bool Keeper
        {
            get { return _keeper; }
            set { _keeper = value; }
        }

        private short _rating;
        
        [DataMember(Name = "Rating",Order = 1)]
        public short Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        private string _note;
        
        [DataMember(Name = "Note",Order = 1)]
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
        
        private DateTime _creation;
        
        [DataMember(Name = "Creation",Order = 1)]
        public DateTime Creation
        {
            get { return _creation; }
            set { _creation = value; }
        }

        private DateTime _modified;
        
        [DataMember(Name = "Modified",Order = 1)]
        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

    }
}
