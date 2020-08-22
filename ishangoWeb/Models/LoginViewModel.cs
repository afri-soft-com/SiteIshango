using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ishangoWeb.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Entrez le nom d'utilisateur svp!!")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Entrez le mot de passe svp!!")]
        public string PassWord { get; set; }
    }
}
