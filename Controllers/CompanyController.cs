using JobExchange.Models;
using JobExchange.Repository.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace JobExchange.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IRecruitmentRepository _recruitmentRepository;
        public CompanyController(ICompanyRepository companyRepository, IRecruitmentRepository recruitmentRepository)
        {
            _companyRepository = companyRepository;
            _recruitmentRepository = recruitmentRepository;
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
    }
}