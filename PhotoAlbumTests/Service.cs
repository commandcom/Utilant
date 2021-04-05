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
            IPhotoAlbumApi api = new PhotoAlbumApi(new Uri(PhotoAlbumServiceUrl));

            var users = api.GetAllUserInfo();

            Assert.IsNotNull(users);
        }
    }
}
