using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UtilantInterviewTest.Models;
using RestSharp;
using X.PagedList;


namespace UtilantInterviewTest.Services
{
    public class PhotoAlbumApi : IPhotoAlbumApi
    {
        private List<Album> _albumData;
        private List<User> _userData;
        private JsonSerializerOptions _serializerOptions;

        public PhotoAlbumApi(Uri serviceUrl)
        {
            ServiceUrl = serviceUrl;

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        /// <summary>
        /// Gets all the album for a particular user
        /// </summary>
        /// <param name="userId">ID of the user.</param>
        /// <returns>List of user's Albums</returns>
        /// See <see cref="GetUsers"/> to get user ID information.
        public List<Album> GetAlbums(User user)
        {
            List<Album> albums = JsonSerializer.Deserialize<List<Album>>(
                GetServiceData($"users/{user.Id}/albums").Content, _serializerOptions)
                .OrderBy(a => a.Title).ToList();

            foreach (var album in albums)
            {
                album.User = user;
                album.Photos = GetPhotos(album.Id);
            }

            return albums;
        }

        public List<Album> GetAlbums()
        {
            if (_albumData == null)
            {
                // get data from service
                GetPagedAlbumInfo();
            }

            return _albumData;
        }

            public Album GetAlbum(int id)
        {
            if (_albumData == null)
            {
                // get data from service
                GetPagedAlbumInfo();
            }

            return _albumData.Single(a => a.Id == id);
        }
        public List<User> GetUsers()
        {
            // use the cached data if its available
            if (_userData == null)
            {
                _userData = JsonSerializer.Deserialize<List<User>>(GetServiceData("users").Content, _serializerOptions)
                   .OrderBy(u => u.Name).ToList();
            }

            return _userData;
        }

        public User GetUser(int id)
        {
            if (_albumData == null)
            {
                // get data from service
                GetPagedAlbumInfo();
            }

            return _albumData.Where(a => a.User.Id == id).First().User;
        }

        /// <summary>
        /// Get all the photos associated with an album
        /// </summary>
        /// <param name="albumId">ID of the album to retreive.</param>
        /// <returns>List of photos associated with an album</returns>
        /// See <see cref="GetUsers"/> and <see cref="GetAlbums(int)"/> to get user and album information.
        public List<Photo> GetPhotos(int albumId)
        {
            return JsonSerializer.Deserialize<List<Photo>>(
                GetServiceData($"albums/{albumId}/photos").Content, _serializerOptions)
                .OrderBy(p => p.Title).ToList();
        }

        public List<Post> GetPosts(int userId)
        {
            return JsonSerializer.Deserialize<List<Post>>(
                GetServiceData($"users/{userId}/posts").Content, _serializerOptions)
                .OrderBy(p => p.Title).ToList();
        }

        /// <summary>
        /// Gets all album and user in the system/database. Results can be paged
        /// </summary>
        /// <returns>List of all users and their associated album and post information</returns>
        public IPagedList<Album> GetPagedAlbumInfo(int pageNumber = 1, int pageSize = 10)
        {
            if (_albumData == null)
            {
                _albumData = new();

                GetUsers();

                foreach (var user in _userData)
                {
                    user.Posts = GetPosts(user.Id);
                    _albumData.AddRange(GetAlbums(user));
                }
            }
     
            return _albumData.ToPagedList(pageNumber, pageSize);
        }
        
        private IRestResponse GetServiceData(string uriPath)
        {
            // create the URI that gets requested information from the service
            Uri serviceUriPath = new Uri(ServiceUrl, uriPath);

            var client = new RestClient(serviceUriPath);

            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            return client.Get(request);
        }

        /// <summary>
        /// Address of the service
        /// </summary>
        public Uri ServiceUrl { get; set; }
    }
}
