using JobExchange.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JobExchange.Controllers
{
    public class CompanyController : Controller
    {
        private readonly db_JobExchangeContext _dbContextProvider;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ILogger<CompanyController> logger, db_JobExchangeContext dbContextProvider)
        {
            _logger = logger;
            _dbContextProvider = dbContextProvider;
        }

        public IActionResult Index()
        {
            IEnumerable<Company> companies = _dbContextProvider.Companies;
            return View(companies);
        }

        public IActionResult Top()
        {
            var topCompanies = _dbContextProvider.Companies
                .OrderByDescending(c => c.Recruitments.Count())
                .Take(5)
                .ToList();

        return View(topCompanies);
        }

        public IActionResult Detail(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = _dbContextProvider.Companies.Find(id);

            if (company == null)
            {
                return NotFound();
            }

            var recruitments = _dbContextProvider.Recruitments.Where(r => r.CompanyId == id).ToList();

            var industryId = company.IndustryId;
            var relatedCompanies = _dbContextProvider.Companies.Include(r => r.Recruitments).Where(c => c.IndustryId == industryId && c.CompanyId != id).ToList();
            var viewModel = new CompanyViewModel{
                Company = company,
                Recruitments = recruitments,
                RelatedCompanies = relatedCompanies,
            };
            return View(viewModel);
        }

        public IActionResult Search(string? name)
        {
            IEnumerable<Company> companies = _dbContextProvider.Companies;

            if (string.IsNullOrEmpty(name))
            {
                return View(companies);
            }

            var companiesSearch = _dbContextProvider.Companies.Include(r => r.Recruitments).Where(c => c.CompanyName.Contains(name)).ToList();

            if (companiesSearch.Count == 0)
            {
                ViewData["Count"] = "0";
                return View(companies);
            }
            ViewData["Count"] = companiesSearch.Count.ToString();
            return View(companiesSearch);
        }

        public IActionResult Recruitments(string companyId, string name)
        {
            var recruitments = _dbContextProvider.Recruitments.Include(r => r.Company).Where(r => r.CompanyId == companyId && r.JobDescription.Contains(name)).ToList();
            return PartialView("_Recruitments", recruitments);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}