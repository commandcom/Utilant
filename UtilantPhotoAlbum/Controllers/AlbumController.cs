using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilantInterviewTest.Services;
using UtilantInterviewTest.Models;

namespace PhotoAlbum.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IPhotoAlbumApi _photoAlbumApi;

        public AlbumController(IPhotoAlbumApi photoAlbumApi)
        {
            _photoAlbumApi = photoAlbumApi;
        }

        public IActionResult Index(int id)
        {
            return View(_photoAlbumApi.GetAlbum(id));
        }
    }
}
