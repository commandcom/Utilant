using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilantInterviewTest.Models;
using X.PagedList;

namespace UtilantInterviewTest.Services
{
    public interface IPhotoAlbumApi
    {
        IPagedList<Album> GetPagedAlbumInfo(int pageNumber, int pageSize);
        List<User> GetUsers();
        User GetUser(int userId);
        List<Album> GetAlbums(User user);
        List<Album> GetAlbums();
        Album GetAlbum(int id);
        List<Photo> GetPhotos(int albumId);
        List<Post> GetPosts(int userId);
        Uri ServiceUrl { get; set; }
    }
}
