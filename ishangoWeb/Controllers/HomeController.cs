using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ishangoWeb.Models;
using ClassLibraryIshangoBar.Evenements;
using ClassLibraryIshangoBar.Menus;

namespace ishangoWeb.Controllers
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
            EvenementDataAccessLayer eventsDAL = new EvenementDataAccessLayer();
            IEnumerable<EvenementModel> events = new List<EvenementModel>();

            events = eventsDAL.GetLesEvents();

            return View(events);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        public IActionResult Menu()
        {
            MenuDataAccessLayer menuDAL = new MenuDataAccessLayer();
            IEnumerable<MenuModel> menus = new List<MenuModel>();
            menus = menuDAL.GetLesMenus();

            return View(menus);
        }
        public IActionResult Menuu()
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
