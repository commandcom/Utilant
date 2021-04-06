using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UtilantInterviewTest.Models;
using UtilantInterviewTest.Services;

namespace PhotoAlbumTests
{
    [TestClass]
    public class ServiceTests
    {
        private const string PhotoAlbumServiceUrl = "https://jsonplaceholder.typicode.com/";
        private static IPhotoAlbumApi _api;
        
        [ClassInitialize]
        static public void InitializePhotoAlbumService(TestContext context)
        {
            _api = new PhotoAlbumApi(new Uri(PhotoAlbumServiceUrl));
        }

        [TestMethod]
        public void CheckServiceUsers()
        {
            // assuming the service will always same numer of users(documentation indicates 10 are configured)
            var users = _api.GetUsers();
            Assert.IsTrue(users.Count == 10);

            // assuming service will always return a non-zero number of posts for each user
            Assert.IsTrue(users.TrueForAll(u => u.Posts != null));
            Assert.IsTrue(users.TrueForAll(u => u.Posts.Count > 0));
        }

        [TestMethod]
        public void CheckServiceAlbums()
        {
            // assuming service will always return a non-zero number of albums and photos within the albums
            List<Album> albums = _api.GetAlbums();
            
            Assert.IsTrue(albums.Count > 0);
            Assert.IsTrue(albums.TrueForAll(p => p != null));
            Assert.IsTrue(albums.TrueForAll(p => p.Photos.Count > 0));
        }
    }
}
