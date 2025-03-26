using FirstMvcProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcProject.Controllers
{
    public class MoviesController:Controller
    {
        //The controller after movies is just a naming convention only
        //Inherit from the controller class 

        //The Action have to be (public , Non-static , method inside controller , not generic)
       
        //To Excute Any Action => BaseUrl + Controller Name + Action Name/?
        
        public string Index (int id)
        {
            return $"Hello , {id}";
        }
        
        public IActionResult GetMovie(int? id,string name)
        {
            //If the return type is Content Result 
            //ContentResult result = new ContentResult();
            //result.Content= $"Movie      {id} / {name}";
            //result.ContentType="text/html" ;
            //result.StatusCode = 900;
            //return result ;
            //OR
            //return Content($"Movie      {id} / {name}");

            //If i want to add conditions and the return type is IAction result 
            if (id == 0)
                return new BadRequestResult();
            
            else if (id < 10)
                return NotFound();
            else
                return Content($"Movie      {id} / {name}");

        }

        //Redirect to Url 
        public IActionResult TestRedirectAction()
        {
            return Redirect("https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs#understanding-action-results");
        }

        //Redirect to Action 
        public IActionResult TestRedirectToAction(Movie movie)
        {
            return RedirectToAction("GetMovie", "Movies", new { id = 30, name = "movie" });
            //Or
            //return Redirect("https://localhost:7120/movies/Getmovie/55?name=cc");
            //Or
            //return RedirectToRoute("JO","Movies");

        }

        //i forced the id form route  OR From body
        //forced the name from query
        //From body is raw in postman (Json)
        //public IActionResult TestModelBinding([FromRoute]int id,[FromQuery] string name)
        //{
        //    return Content($"Movie      {id} / {name}");
        //}

        [HttpGet] //This called verb or method func/action
        public IActionResult TestModelBinding([FromBody] Movie movie)
        {
            return Content($"Movie      {movie.Id} / {movie.Name}");
        }
    }
}
