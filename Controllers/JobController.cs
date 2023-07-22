using JobExchange.Models;
using JobExchange.Repository.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobExchange.Controllers
{
    public class JobController : Controller
    {
        private readonly IRecruitmentRepository _recruitmentRepository;
        public JobController(IRecruitmentRepository recruitmentRepository)
        {
            _recruitmentRepository = recruitmentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DefaultJob(string? id)
        {
            var recruitment = _recruitmentRepository.GetById(id);
            var recruitmentsByCompanyId = _recruitmentRepository.GetRecruitmentsByCompanyId(recruitment.CompanyId);
            var recruitmentsByIndustryId = _recruitmentRepository.GetRecruitmentsByIndustryId(recruitment.IndustryId);
            var recruitmentViewModel = new RecruitmentViewModel
            {
                Recruitment = recruitment,
                RecruitmentsCompanyId = recruitmentsByCompanyId,
                RecruitmentsIndustryId = recruitmentsByIndustryId
            };
            return View(recruitmentViewModel);
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
