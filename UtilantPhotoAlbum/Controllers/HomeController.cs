using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UtilantInterviewTest.Models;
using UtilantInterviewTest.Services;

namespace UtilantInterviewTest.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IPhotoAlbumApi _photoAlbumApi;

        public HomeController(IPhotoAlbumApi photoAlbumApi)
        {
            _photoAlbumApi = photoAlbumApi;
        }

       
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_photoAlbumApi.GetAllUserInfo());
            
            //return View(_photoAlbumApi.GetAllUserInfo().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
