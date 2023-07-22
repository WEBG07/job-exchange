using JobExchange.Models;
using JobExchange.Repository;
using JobExchange.Repository.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using System.Diagnostics;
using System.Drawing;
using System.Security.Claims;

namespace JobExchange.Controllers
{
    //[Authorize(Roles = "ROLE_CANDIDATE")]
    public class HomeController : Controller
    {
        private readonly IIndustryRepository _industryRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IIndustryRepository industryRepository)
        {
            _logger = logger;
            _industryRepository = industryRepository;
        }

        public IActionResult Index(int page)
        {
            int pageNumber = page > 0 ? page : 1;
            // Get the list of products from the database.
            var industries = _industryRepository.GetAll();
            // Create a PagedList from the list of products.
            var pagedList = new PagedList<Industry>(industries, pageNumber, 8);

            // Return the paged list of products to the view.
            return View(pagedList);
        }

        //public IActionResult Index()
        //{
        //    //var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    //var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    //Console.WriteLine("đây là id: " + userId);
        //    return View();
        //}

        //[Authorize(Roles = "ROLE_CANDIDATE")]
        //[Authorize]
        public IActionResult Privacy()
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