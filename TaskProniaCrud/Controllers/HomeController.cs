using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace TaskProniaCrud.Controllers
{
    public class HomeController : Controller
    {
    
        public IActionResult Index()
        {
            return View();
        }

    }
}
