using JobExchange.Areas.Identity.Data;
using JobExchange.Models;
using JobExchange.Repository.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace JobExchange.Controllers
{
    public class CompanyController : Controller
    {
        private readonly JobExchangeContext _context;
        private readonly ICompanyRepository _companyRepository;
        private readonly IRecruitmentRepository _recruitmentRepository;
        private readonly UserManager<JobExchangeUser> _userManager;
        public CompanyController(JobExchangeContext context, ICompanyRepository companyRepository, IRecruitmentRepository recruitmentRepository, UserManager<JobExchangeUser> userManager)
        {
            _companyRepository = companyRepository;
            _recruitmentRepository = recruitmentRepository;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var companies = _companyRepository.GetAllCompanies();
            return View(companies);
        }
        
        public IActionResult Top()
        {
            var companies = _companyRepository.GetTopCompanies();
            return View(companies);
        }

        public IActionResult Search(string? name)
        {
            var companies = _companyRepository.GetAllCompanies();
            var companiesSearch = _companyRepository.SearchCompanies(name);

            if (companiesSearch.Count() == 0)
            {
                ViewData["Count"] = "0";
                return View(companies);
            }
            ViewData["Count"] = companiesSearch.Count().ToString();
            return View(companiesSearch);
        }

        public IActionResult Detail(string? id)
        {
            var company = _companyRepository.GetCompanyById(id);
            var recruitments = _recruitmentRepository.GetRecruitmentsByCompanyId(id);
            var relatedCompanies = _companyRepository.GetCompaniesRelated(company.IndustryId, id);
            var viewModel = new CompanyViewModel{
                Company = company,
                Recruitments = recruitments,
                RelatedCompanies = relatedCompanies,
            };
            return View(viewModel);
        }

        public IActionResult Recruitments(string companyId, string name)
        {
            var recruitments = _recruitmentRepository.GetRecruitmentsByName(companyId, name);
            return PartialView("_Recruitments", recruitments);
        }

        public IActionResult Profile()
        {
            var companyId = _userManager.GetUserId(User);
            var company = _context.Companies
                .Include(r => r.Industry)
                .FirstOrDefault(m => m.CompanyId == companyId);
            return View(company);
        }

        // GET:
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = _companyRepository.GetCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }
            ViewData["IndustryId"] = new SelectList(_context.Industries, "IndustryId", "IndustryName");
            return View(company);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Company company)
        {
            try
            {
                ViewData["IndustryId"] = new SelectList(_context.Industries, "IndustryId", "IndustryName");
                _companyRepository.Update(company);
            }
            catch (DbUpdateConcurrencyException)
            {
                return View(company);
                return NotFound();
            }
            return RedirectToAction(nameof(Profile));
        }

    }
}