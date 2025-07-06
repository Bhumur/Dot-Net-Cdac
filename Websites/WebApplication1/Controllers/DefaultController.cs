using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        //https://localhost:7258/Default/Index/123?a=100&b=200&c=300
        //https://localhost:7258/Default/Index/123?c=300
        //https://localhost:7258/Default/Index/123?a=100&c=300
        //https://localhost:7258/Default/Index/123?b=200
        public IActionResult Index(int? id, int a=1, int b=2 , int c=3)
        {
            //if (id == null)
            //    return NotFound();
            
            ViewBag.id = id; 
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;

            return View();
        }
    }
}
