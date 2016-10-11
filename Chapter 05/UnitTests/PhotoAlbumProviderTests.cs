using System;
using System.Collections.Generic;
using NUnit.Framework;
using Chapter05.PhotoAlbumProvider;

namespace UnitTests
{

    [TestFixture]
    public class PhotoAlbumProviderTests
    {
        private const string USERNAME = "unittests";
        private const string USERNAME2 = "unittests2";

        [Test]
        public void Test100AlbumInsert()
        {
            Album album = PhotoAlbumService.Instance.AlbumInsert(USERNAME, "Test Album", true, true);
            Assert.IsTrue(album != null, "Test album cannot be null");
            Console.WriteLine("Album created");
        }

        [Test]
        public void Test101GetAlbums()
        {
            List<Album> albums = PhotoAlbumService.Instance.GetAlbums(USERNAME);
            Assert.IsTrue(albums.Count > 0, "There should be at least 1 album");
            Console.WriteLine(String.Format("Found {0} albums", albums.Count));
        }

        [Test]
        public void Test102UpdateAlbum()
        {
            List<Album> albums = PhotoAlbumService.Instance.GetAlbums(USERNAME);
            albums[0].Name = "Updated Album";
            PhotoAlbumService.Instance.AlbumUpdate(albums[0]);
            Console.WriteLine("Updated Album");
        }

        [Test]
        public void Test103DeleteAlbum()
        {
            List<Album> albums = PhotoAlbumService.Instance.GetAlbums(USERNAME);
            PhotoAlbumService.Instance.AlbumDeletePermanent(albums[0]);
            Console.WriteLine("Deleted Album");
        }

        [Test]
        public void Test104AlbumMove()
        {
            Album album = PhotoAlbumService.Instance.AlbumInsert(USERNAME, "Test Album", true, true);
            PhotoAlbumService.Instance.AlbumMove(album, USERNAME, USERNAME2);
            Console.WriteLine("Moved album");
        }

        [Test]
        public void Test200PhotoInsert()
        {
            Album album = PhotoAlbumService.Instance.AlbumInsert(USERNAME, "Test Photo Album", true, true);
            Photo photo = PhotoAlbumService.Instance.PhotoInsert(album, "Test Photo", DateTime.Now, 
                String.Empty, 0, 0, String.Empty, 0, 0, true, true);
            Assert.IsNotNull(photo, "Photo should not be null");
            Console.WriteLine("Photo Created");
        }

        [Test]
        public void Test201GetPhoto()
        {
            List<Album> albums = PhotoAlbumService.Instance.GetAlbums(USERNAME);
            foreach (Album album in albums)
            {
                if (album.Photos.Count > 0)
                {
                    Console.WriteLine("Photos found");
                    return;
                }
            }
            Assert.Fail("No photos found");
        }

        [Test]
        public void Test202PhotoUpdate()
        {
            List<Album> albums = PhotoAlbumService.Instance.GetAlbums(USERNAME);
            if (albums.Count > 0)
            {
                Album album = albums[0];
                if (album.Photos.Count > 0)
                {
                    Photo photo = album.Photos[0];
                    photo.Name = "Updated Photo";
                    PhotoAlbumService.Instance.PhotoUpdate(photo);
                    Console.WriteLine("Photo updated");
                    return;
                }
                else
                {
                    Assert.Fail("No photos for test");
                }
            }
            else
            {
                Assert.Fail("No albums for test");
            }
        }

        [Test]
        public void Test203PhotoDelete()
        {
            List<Album> albums = PhotoAlbumService.Instance.GetAlbums(USERNAME);
            foreach (Album album in albums)
            {
                if (album.Photos.Count > 0)
                {
                    Photo photo = album.Photos[0];
                    PhotoAlbumService.Instance.PhotoDeletePermanent(photo);
                    Console.WriteLine("Photo deleted");
                    return;
                }
            }
            Assert.Fail("No data for test");
        }

        [Test]
        public void Test204PhotoMove()
        {
            Album album1 = PhotoAlbumService.Instance.AlbumInsert(USERNAME, "Album 1", true, true);
            //int count1 = album1.Photos.Count;
            Album album2 = PhotoAlbumService.Instance.AlbumInsert(USERNAME2, "Album 2", true, true);
            //int count2 = album2.Photos.Count;
            Photo photo = PhotoAlbumService.Instance.PhotoInsert(album1, "Test Photo", DateTime.Now,
                String.Empty, 0, 0, String.Empty, 0, 0, true, true);
            PhotoAlbumService.Instance.PhotoMove(photo, album1, album2);
            Assert.IsTrue(album2.Photos.Contains(photo), "Album 2 must have photo");
            Console.WriteLine("Moved photo");
        }

        [Test]
        public void Test999RemoveAll()
        {
            String[] usernames = { USERNAME, USERNAME2 };
            foreach (String username in usernames)
            {
                List<Album> albums = PhotoAlbumService.Instance.GetAlbums(username);
                Console.WriteLine(String.Format("Deleting {0} albums", albums.Count));
                foreach (Album album in albums)
                {
                    foreach (Photo photo in album.Photos)
                    {
                        PhotoAlbumService.Instance.PhotoDeletePermanent(photo);
                    }
                    PhotoAlbumService.Instance.AlbumDeletePermanent(album);
                }
            }
            Console.WriteLine("Done!");
        }

    }
}
