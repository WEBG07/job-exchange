using System.Security.Claims;
using JobExchange.Models;
using JobExchange.Repository;
using JobExchange.Repository.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobExchange.Controllers
{
    public class JobController : Controller
    {
        private readonly IRecruitmentRepository _recruitmentRepository;
        private readonly ICandidateRecruitmentRepository _candidateRecruitmentRepository;
        public JobController(IRecruitmentRepository recruitmentRepository, ICandidateRecruitmentRepository candidateRecruitmentRepository)
        {
            _recruitmentRepository = recruitmentRepository;
            _candidateRecruitmentRepository = candidateRecruitmentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DefaultJob(string? id)
        {
            var candidateId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            var recruitment = _recruitmentRepository.GetById(id);
            var recruitmentsByCompanyId = _recruitmentRepository.GetRecruitmentsByCompanyId(id, recruitment.CompanyId);
            var recruitmentsByIndustryId = _recruitmentRepository.GetRecruitmentsByIndustryId(id, recruitment.IndustryId);
            var checkApply = _candidateRecruitmentRepository.checkApplication(candidateId,id);
            var recruitmentViewModel = new RecruitmentViewModel
            {
                Recruitment = recruitment,
                RecruitmentsCompanyId = recruitmentsByCompanyId,
                RecruitmentsIndustryId = recruitmentsByIndustryId,
                CheckApply = checkApply
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
        [HttpPost]
        public IActionResult ApplyJob(string candidateId, string recruitmentId)
        {
            var data = new CandidateRecruitment{
                RecruitmentId = recruitmentId,
                CandidateId = candidateId,
                ApplicationStatus = "Đang chờ xét duyệt",
                CreatedAt = DateTime.Now,
            };
            _candidateRecruitmentRepository.AddCandidateRecruitment(data);
            return Json("Success");
        }
    }
}
