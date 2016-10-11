using System.ComponentModel;
using System.ServiceModel;

namespace Chapter07.WCFService
{
    [DataObject()]
    public class FavoriteLinkClient : ClientBase<IFavoriteLinkService>,IFavoriteLinkService
    {
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public FavoriteLinkDataContract[] GetRecentFavoriteLinkCollection(
            long profileId, int startDaysBack, int endDaysBack)
        {
            return Channel.GetRecentFavoriteLinkCollection(profileId, startDaysBack, endDaysBack);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public FavoriteLinkDataContract[] GetLatest20FavoriteLinkCollection(long profileId)
        {
            return Channel.GetLatest20FavoriteLinkCollection(profileId);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public FavoriteLinkDataContract[] GetFavoriteLinkCollectionByTag(long profileId, string token)
        {
            return Channel.GetFavoriteLinkCollectionByTag(profileId, token);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public FavoriteLinkDataContract[] GetFavoriteLinkCollectionByUrl(long profileId, string url)
        {
            return Channel.GetFavoriteLinkCollectionByUrl(profileId, url);
        }

      

    }
}
