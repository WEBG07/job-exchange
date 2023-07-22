using Microsoft.AspNetCore.Mvc;

namespace JobExchange.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DefaultJob()
        {
            return View();
        }
        public IActionResult CandidateHistory() { 
            return View();
        }
        public IActionResult SavedJobs()
        {
            return View();
        }
    }
}
