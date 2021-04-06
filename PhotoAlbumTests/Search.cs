using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UtilantInterviewTest.Models;
using UtilantInterviewTest.Services;

namespace PhotoAlbumTests
{
    [TestClass]
    public class SearchTests
    {
        private const string PhotoAlbumServiceUrl = "https://jsonplaceholder.typicode.com/";

        private static IPhotoAlbumApi _api;

        [ClassInitialize]
        static public void InitializePhotoAlbumService(TestContext context)
        {
            _api = new PhotoAlbumApi(new Uri(PhotoAlbumServiceUrl));
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void SearchThrowsErrorWithoutApi()
        {
            Search search = new();
            search.Execute(null, string.Empty);
        }

        [TestMethod]
        public void SearchReturnsNullIfNoSearchTermProvided()
        {
            Search search = new();
            Assert.IsNull(search.Execute(_api, string.Empty));
        }

        [TestMethod]
        public void SearchReturnsExpectedResults()
        {
            // get data for search
            _api.GetPagedAlbumInfo(1, 10);

            //  tests assume data coming from service is static
            Search search = new();
            
            string searchString = "z";

            // no user name or album title in service start with z
            SearchResults results = search.Execute(_api, searchString);
            Assert.IsTrue(results.Albums.Count == 0);
            Assert.IsTrue(results.Users.Count == 0);

            // only one user result with "chel"
            searchString = "chel";
            results = search.Execute(_api, searchString);
            Assert.IsTrue(results.Albums.Count == 0);
            Assert.IsTrue(results.Users.Count == 1);
            Assert.IsTrue(results.Users[0].Name.ToLower().StartsWith(searchString));

            // only one album result with "modi"
            searchString = "modi";
            results = search.Execute(_api, searchString);
            Assert.IsTrue(results.Albums.Count == 1);
            Assert.IsTrue(results.Users.Count == 0);
            Assert.IsTrue(results.Albums[0].Title.ToLower().StartsWith(searchString));

            // multiple results with "c"
            searchString = "c";
            results = search.Execute(_api, searchString);
            Assert.IsTrue(results.Albums.Count == 5);
            Assert.IsTrue(results.Users.Count == 3);
            Assert.IsTrue(results.Albums.TrueForAll(a => a.Title.StartsWith(searchString, StringComparison.InvariantCultureIgnoreCase)));
            Assert.IsTrue(results.Albums.TrueForAll(a => a.Title.StartsWith(searchString, StringComparison.InvariantCultureIgnoreCase)));

            // search is case-insensitive
            searchString = "C";
            results = search.Execute(_api, searchString);
            Assert.IsTrue(results.Albums.Count == 5);
            Assert.IsTrue(results.Users.Count == 3);
        }
    }

    
}
