using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilantInterviewTest.Models;

namespace UtilantInterviewTest.Services
{
    public interface IPhotoAlbumApi
    {
        List<User> GetAllUserInfo();
        List<Album> GetAlbums(int userId);
        List<Photo> GetPhotos(int albumId);
        List<Post> GetPosts(int userId);
        Uri ServiceUrl { get; set; }
    }
}
