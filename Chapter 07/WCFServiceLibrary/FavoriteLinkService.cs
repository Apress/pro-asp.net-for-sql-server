using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using Chapter07.Domain;

namespace Chapter07.WCFService
{

    [ServiceContract(Namespace = "http://chapter07/")]
    public interface IFavoriteLinkService
    {

        [OperationContract]
        FavoriteLinkDataContract[] GetRecentFavoriteLinkCollection(
            long profileId, int startDaysBack, int endDaysBack);

        [OperationContract]
        FavoriteLinkDataContract[] GetLatest20FavoriteLinkCollection(long profileId);

        [OperationContract]
        FavoriteLinkDataContract[] GetFavoriteLinkCollectionByTag(long profileId, string token);

        [OperationContract]
        FavoriteLinkDataContract[] GetFavoriteLinkCollectionByUrl(long profileId, string url);
        
    }

    public class FavoriteLinkService : IFavoriteLinkService
    {

        public FavoriteLinkDataContract[] GetRecentFavoriteLinkCollection(
           long profileId, int startDaysBack, int endDaysBack)
        {
            Trace.WriteLine("GetRecentFavoriteLinkCollection");
            FavoriteLinkDomain domain = new FavoriteLinkDomain();
            FavoriteLinkCollection favoriteLinks = domain.GetRecentFavoriteLinkCollection(profileId, startDaysBack, endDaysBack);
            return GetFavoriteLinksArray(favoriteLinks);
        }
        
        public FavoriteLinkDataContract[] GetLatest20FavoriteLinkCollection(
            long profileId)
        {
            Trace.WriteLine("GetLatest20FavoriteLinkCollection");
            FavoriteLinkDomain domain = new FavoriteLinkDomain();
            FavoriteLinkCollection favoriteLinks = 
                domain.GetLatest20FavoriteLinkCollection(profileId);
            return GetFavoriteLinksArray(favoriteLinks);
        }
        
        public FavoriteLinkDataContract[] GetFavoriteLinkCollectionByTag(
            long profileId, string token)
        {
            Trace.WriteLine("GetFavoriteLinkCollectionByTag");
            FavoriteLinkDomain domain = new FavoriteLinkDomain();
            FavoriteLinkCollection favoriteLinks = 
                domain.GetFavoriteLinkCollectionByTag(profileId, token);
            return GetFavoriteLinksArray(favoriteLinks);
        }
        
        public FavoriteLinkDataContract[] GetFavoriteLinkCollectionByUrl(
            long profileId, string url)
        {
            Trace.WriteLine("GetFavoriteLinkCollectionByUrl");
            FavoriteLinkDomain domain = new FavoriteLinkDomain();
            FavoriteLinkCollection favoriteLinks = 
                domain.GetFavoriteLinkCollectionByUrl(profileId, url);
            return GetFavoriteLinksArray(favoriteLinks);
        }

        private FavoriteLinkDataContract[] GetFavoriteLinksArray(
            FavoriteLinkCollection favoriteLinks)
        {
            List<FavoriteLinkDataContract> links = new List<FavoriteLinkDataContract>();
            foreach (FavoriteLink favoriteLink in favoriteLinks)
            {
                FavoriteLinkDataContract linkDataContract = new FavoriteLinkDataContract();
                linkDataContract.Title = favoriteLink.Title;
                linkDataContract.Url = favoriteLink.Url;
                linkDataContract.Keeper = favoriteLink.Keeper;
                linkDataContract.Rating = favoriteLink.Rating;
                linkDataContract.Note = favoriteLink.Note;
                links.Add(linkDataContract);
            }
            return links.ToArray();
        }

    }

}
