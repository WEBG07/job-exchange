using JobExchange.Models;
using JobExchange.Repository.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using JobExchange.DataModel;



namespace JobExchange.Controllers
{
    public class JobController : Controller
    {
        private readonly JobExchangeContext _context;
        private readonly IRecruitmentRepository _recruitmentRepository;
        public JobController(JobExchangeContext context, IRecruitmentRepository recruitmentRepository)
        {
            _context = context;
            _recruitmentRepository = recruitmentRepository;
        }
        public IActionResult Index()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data.json");

            if (System.IO.File.Exists(filePath))
            {
                var jsonData = System.IO.File.ReadAllText(filePath);
                var data = System.Text.Json.JsonSerializer.Deserialize<List<ProvinceDataModel>>(jsonData);

                // Check if the deserialization was successful and data is not null
                if (data != null)
                {
                    ViewData["IndustryId"] = new SelectList(_context.Industries, "IndustryId", "IndustryName");
                    ViewBag.City = data;
                    return View();
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("Error");
            }
        }
        //GetRecruitments
        [HttpPost]
        public IActionResult GetRecruitments(string filter = null, string value1 = null, string value2 = null)
        {
            var recruitments = _recruitmentRepository.GetRecruitments(filter, value1, value2);

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore // Bỏ qua vòng lặp tự tham chiếu
            };

            string json = JsonConvert.SerializeObject(recruitments, Formatting.Indented, settings);
            return Content(json, "application/json");
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
