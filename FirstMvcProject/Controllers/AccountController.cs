using Microsoft.AspNetCore.Mvc;

namespace FirstMvcProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn(int id,string name)
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
