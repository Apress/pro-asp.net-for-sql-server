using System;

namespace Chapter07.Domain
{
    public class Profile
    {
        public Profile(Guid userId)
        {
            UserID = userId;
            FavoriteLinkDomain domain = new FavoriteLinkDomain();
            ProfileID = domain.GetFavoriteLinkProfileID(userId);
        }

        private long _profileId;
        public long ProfileID
        {
            get { return _profileId; }
            set { _profileId = value; }
        }

        private Guid _userId;
        public Guid UserID
        {
            get { return _userId; }
            set { _userId = value; }
        }

    }
}
