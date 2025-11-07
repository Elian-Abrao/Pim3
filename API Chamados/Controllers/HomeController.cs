using Microsoft.AspNetCore.Mvc;

namespace API_Chamados.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
