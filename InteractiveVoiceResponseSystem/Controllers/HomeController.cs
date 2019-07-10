using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InteractiveVoiceResponseSystem.Models;

namespace InteractiveVoiceResponseSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly LocalNewVersionHintsDBContext _context;

        public HomeController(LocalNewVersionHintsDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.QuestionList.ToList());
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
