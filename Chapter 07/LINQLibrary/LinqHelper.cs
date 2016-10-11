using System;
using System.Collections.Generic;
using System.Text;
using System.Query;
using System.Xml.XLinq;
using System.Data.DLinq;
using Chapter07.Domain;

namespace Chapter07.LINQ
{
    public class LinqHelper
    {

        public static FavoriteLinkCollection GetFilteredLinks(
            FavoriteLinkCollection linksIn, string str)
        {
            FavoriteLinkCollection linksOut = new FavoriteLinkCollection();

            var selectedLinks = from l in linksIn
                                where l.Url.Contains(str)
                                select l;

            foreach (FavoriteLink favoriteLink in selectedLinks)
            {
                linksOut.Add(favoriteLink);
            }
            return linksOut;
        }

        public static List<String> GetUrls(FavoriteLinkCollection linksIn)
        {
            List<String> urlsOut = new List<String>();

            var urls = from l in linksIn select l.Url;
            foreach (String url in urls)
            {
                urlsOut.Add(url);
            }
            return urlsOut;
        }

    }
}
