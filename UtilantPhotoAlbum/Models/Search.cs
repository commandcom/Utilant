using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilantInterviewTest.Models;
using UtilantInterviewTest.Services;

namespace UtilantInterviewTest.Models
{
    public class Search
    {
        public SearchResults Execute(IPhotoAlbumApi photoAlbumApi, string searchString)
        {
            if(photoAlbumApi == null)
            {
                throw new ApplicationException(nameof(photoAlbumApi) + " parameter cannot be null.");
            }

            if (string.IsNullOrEmpty(searchString))
            {
                // no search possible
                return null;
            }

            // a little awkward since we're searching two different types of objects; we'll do two separate searchs and combine the results
            SearchResults results = new();

            results.SearchString = searchString;

            results.Users = photoAlbumApi.GetUsers().Where(u => u.Name.StartsWith(searchString, StringComparison.InvariantCultureIgnoreCase)).ToList();
            results.Albums = photoAlbumApi.GetAlbums().Where(a => a.Title.StartsWith(searchString, StringComparison.InvariantCultureIgnoreCase)).ToList();
            
            return results;
        }
    }

    public class SearchResults
    {
        public string SearchString { get; set; }
        public List<User> Users { get; set; }
        public List<Album> Albums { get; set; }
    }


}
