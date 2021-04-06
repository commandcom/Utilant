using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilantInterviewTest.Models;
using UtilantInterviewTest.Services;

namespace PhotoAlbum.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPhotoAlbumApi _photoAlbumApi;

        public SearchController(IPhotoAlbumApi photoAlbumApi)
        {
            _photoAlbumApi = photoAlbumApi;
        }

        public IActionResult Index(string photoSearch)
        {
            ViewData["searchString"] = photoSearch;

            if (string.IsNullOrEmpty(photoSearch))
            {
                RedirectToAction("Index", "Home");
            }

            Search search = new();
            
            return View(search.Execute(_photoAlbumApi, photoSearch));
        }
    }
}
