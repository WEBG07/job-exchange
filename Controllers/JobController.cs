using Microsoft.AspNetCore.Mvc;

namespace JobExchange.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
