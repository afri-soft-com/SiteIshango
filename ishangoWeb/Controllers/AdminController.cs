using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace ishangoWeb.Controllers
{
    public class AdminController : Controller
    {

        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }
        public IActionResult AdminLogin()
        {
            return View();
        }

        public IActionResult AjouterMenu()
        {
            return View();
        }

        public IActionResult AjouterEvent()
        {
            return View();
        }
    }
}