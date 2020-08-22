using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClassLibraryIshangoBar.Utilisateur;
using static ClassLibraryIshangoBar.Utilisateur.UtilisateurModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ishangoWeb.Models;
using Syncfusion.Blazor.PivotView;

namespace ishangoWeb.Controllers
{
    public class AdminController : Controller
    {

        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(LoginViewModel model)
        {
            UtilisateurDataAccessLayer userDAL = new UtilisateurDataAccessLayer();
            var  login = new UtilisateurDataAccessLayer.tUser();

            
            login = userDAL.GetUsers(model.UserName.Trim(), model.PassWord.Trim());

            if (!string.IsNullOrEmpty(login.PassWord))
            {
                return RedirectToAction("AjouterMenu");
            }
            ModelState.AddModelError("Echer", "Nom d'utilisateur ou password incorrect");

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