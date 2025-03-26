using Microsoft.AspNetCore.Mvc;
using FirstMvcProject.Models;

namespace FirstMvcProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //View  Have 4 overloads
            return View(); //Return view with the same name As The Action Name
            //return View(new Movie()); //Return view with the same name As The Action Name , and bind the model data to view 
            //return View("Jo"); //Return view with the Provided Name
            //return View("Jo",new Movie()); //Combination of the previous two overloads
        }

        public IActionResult Privacy()
        {
            return View(); //Return view with the same name As The Action Name
            
        }
        public IActionResult AboutUs()
        {
            return View(); //Return view with the same name As The Action Name
            
        }
        public IActionResult ContaceUs()
        {
            return View(); //Return view with the same name As The Action Name
            
        }
    }
}
