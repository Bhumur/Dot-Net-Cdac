using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index(int? id, int a=1, int b=1, int c=1)
        {
            Console.WriteLine(id);
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);

            ViewBag.id = id;
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;

                return View();
                       
        }
    }
}
