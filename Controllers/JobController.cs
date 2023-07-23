using JobExchange.Areas.Identity.Data;
using JobExchange.Models;
using JobExchange.Repository;
using JobExchange.Repository.RepositoryInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobExchange.Controllers
{
    public class JobController : Controller
    {
        private readonly IRecruitmentRepository _recruitmentRepository;
        private readonly ISaveJobRepository _saveJobRepository;
        private readonly UserManager<JobExchangeUser> _userManager;
        private readonly JobExchangeContext _context;
        public JobController(IRecruitmentRepository recruitmentRepository, JobExchangeContext context, ISaveJobRepository saveJobRepository, UserManager<JobExchangeUser> userManager)
        {
            _recruitmentRepository = recruitmentRepository;
            _saveJobRepository = saveJobRepository;
            _userManager = userManager;
            _context = context;
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
            bool isSave = _saveJobRepository.ExistsById(_userManager.GetUserId(User), id);

            ViewBag.IsSave = isSave; // Pass the result to the view
            return View(recruitmentViewModel);
        }
        public IActionResult CandidateHistory()
        {
            return View();
        }

        public IActionResult Saved()
        {
            var saved = _context.SaveRecruitments
                .Include(r => r.Recruitment)
                .ThenInclude(r => r.Company)
                .Where(m => m.CandidateId == _userManager.GetUserId(User)).ToList(); // 1 list
            //.FirstOrDefault(m => m.CandidateId == _userManager.GetUserId(User)); 1 đối tượng
            return View(saved);

        }

        [HttpPost]
        public IActionResult Save(string recruitmentId)
        {
            try
            {
                SaveRecruitment saveRecruitment = new SaveRecruitment();
                saveRecruitment.RecruitmentId = recruitmentId;
                saveRecruitment.CreateDate = DateTime.Now;
                saveRecruitment.CandidateId = _userManager.GetUserId(User);
                _saveJobRepository.Save(saveRecruitment);
                return Ok(saveRecruitment);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult UnSave(string Id)
        {
            try
            {
                var candidateId = _userManager.GetUserId(User);
                var saveRecruitment = _saveJobRepository.GetById(candidateId, Id);
                if (saveRecruitment == null)
                {
                    return NotFound();
                }

                _saveJobRepository.UnSave(saveRecruitment);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
