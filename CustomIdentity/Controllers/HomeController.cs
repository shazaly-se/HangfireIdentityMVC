using CustomIdentity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHost)
        {
            _logger = logger;
            _webHost = webHost;
        }



        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            string uploadsFolder = Path.Combine(_webHost.WebRootPath , "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            foreach (var file in files)
            {
                string fileName = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")+ Path.GetFileName(file.FileName);
                string fileSavePath = Path.Combine(uploadsFolder, fileName);
                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                ViewBag.Message += string.Format("<b>{0}</b> uploads successfully. <br/>", fileName );

            }
            return View();
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