using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DaveWritesCode.CodeLou.MVC.Models;
using Microsoft.AspNetCore.Http;
using src;
using System.Text.Json;
using System.IO;

namespace DaveWritesCode.CodeLou.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            var students = new List<Student>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                students = JsonSerializer.Deserialize<List<Student>>(reader.ReadToEnd());
            }
            return View(students);
        }

        [HttpPost]
        public IActionResult DownloadStudents(List<Student> students)
        {

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
