using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UtilantInterviewTest.Models;
using RestSharp;

namespace UtilantInterviewTest.Services
{
    public class PhotoAlbumApi : IPhotoAlbumApi
    {
        private Uri _serviceUrl;
        private JsonSerializerOptions _serializerOptions;
        private List<User> _userData;

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
        public List<Album> GetAlbums(int userId)
        {
            List<Album> albums = JsonSerializer.Deserialize<List<Album>>(
                GetServiceData($"users/{userId}/albums").Content, _serializerOptions)
                .OrderBy(a => a.Title).ToList();

            foreach (var album in albums)
            {
                album.Photos = GetPhotos(album.Id);
            }

            return albums;
        }

        //public Album GetAlbum(int albumId)
        //{
        //    return JsonSerializer.Deserialize<Album>(
        //        GetServiceData($"albums/{albumId}/photos").Content, _serializerOptions)
        //        .OrderBy(p => p.Title).ToList();
        //}

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
        /// Gets all users in the system/database
        /// </summary>
        /// <returns>List of all users and their associated album and post information</returns>
        public List<User> GetAllUserInfo()
        {
            if (_userData == null)
            {
                var users = JsonSerializer.Deserialize<List<User>>(GetServiceData("users").Content, _serializerOptions)
                    .OrderBy(u => u.Name).ToList();

                foreach (var user in users)
                {
                    // get all albums for this user
                    user.Albums = GetAlbums(user.Id);
                    user.Posts = GetPosts(user.Id);
                }

                _userData = users;
            }

            return _userData;
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
        public Uri ServiceUrl { get => _serviceUrl; set => _serviceUrl = value; }
    }
}
