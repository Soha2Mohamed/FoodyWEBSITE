using Foody.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Foody.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // 1-    welcome page: contains the name of the website, logo sentence, and desciption.
        // it contains also 2 buttons one for login and the other for signup

        // 2-   login page: asks the user to enter email and user and then submit
        // the sentence: if you don't have an account signup,button that redirects to signup page
        // if user exists , the button redirects  the user to  timeline or home page

        // 3-   sign up page: insert new user with sentence: if you already have an account login,button that redirects to logiin page
        // if inserting is successful, redirects the user to login page to login 

        // 4-   profile page : contains 2 features: viewing and editing user info and editing recipes
        // for user infoo: first the user can see and edit his info

        // 5-   view user info: user can see all his info.has a button if user wants to edit

        // 6-   edit user info: user can edit any value and then is redirected to view user page

        // 7-  view recipes: list of all recipes related to the user with little info about each of them
        // can  be rearranged ascending, desceding,alphabetically, or by cuisine

        // 8-   view recipe: user pressees on any recipe and can view all info

        // 9-   edit recipe : user presses on recipe edit button and can edit

        // 10- create recipe:

        // 11- delete recipe: 

        // 12- timeline page: contains highest rated meals of the week 
        // user can press on any recipe to view

        // 13-  comment on a recipe:

        // 14-  rate a recipe

        // 15-  save a recipe too cook later

        public IActionResult index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult about()
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
