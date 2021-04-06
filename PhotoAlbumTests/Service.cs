using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UtilantInterviewTest.Services;

namespace PhotoAlbumTests
{
    [TestClass]
    public class Service
    {
        private const string PhotoAlbumServiceUrl = "https://jsonplaceholder.typicode.com/";

        [TestMethod]
        public void GetAllUserInfo()
        {
            //IPhotoAlbumApi api = new PhotoAlbumApi(new Uri(PhotoAlbumServiceUrl));

            //var users = api.GetAlbums;

            //Assert.IsNotNull(users);
            //// assuming the service will always same numer of users (documentation indicates 10 are configured)
            //Assert.IsTrue(users.Count == 10);

            //// assuming service will always return a non-zero number of albums
            //Assert.IsTrue(users.TrueForAll(u => u.Albums != null));
            //Assert.IsTrue(users.TrueForAll(u => u.Albums.Count > 0));

            //// assuming service will always return a non-zero number of photos for each album
            //Assert.IsTrue(users.TrueForAll(u => u.Albums.TrueForAll(p => p.Photos.Count > 0)));

            //// assuming service will always return a non-zero number of posts for each user
            //Assert.IsTrue(users.TrueForAll(u => u.Posts != null));
            //Assert.IsTrue(users.TrueForAll(u => u.Posts.Count > 0));
        }
    }
}
