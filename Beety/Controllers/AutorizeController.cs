using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Security;

namespace Beety.Controllers
{
    public class AutorizeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserDTO model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
               
            }
            ViewBag.returnUrl = returnUrl;
            return Redirect("http://localhost:63345/");
            return View(model);
        }
    }
}