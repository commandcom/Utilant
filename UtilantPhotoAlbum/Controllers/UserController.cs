using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilantInterviewTest.Services;

namespace PhotoAlbum.Controllers
{
    public class UserController : Controller
    {
        private readonly IPhotoAlbumApi _photoAlbumApi;

        public UserController(IPhotoAlbumApi photoAlbumApi)
        {
            _photoAlbumApi = photoAlbumApi;
        }
        public IActionResult Index(int id)
        {
            return View(_photoAlbumApi.GetAllUserInfo().First(u => u.Id == id));
        }
    }
}
