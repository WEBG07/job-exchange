using Microsoft.AspNetCore.Mvc;
using JobExchange.Models;
using JobExchange.Repository;
using System.Security.Claims;
using MimeKit;

namespace JobExchange.Controllers
{
    public class CandidateController : Controller
    {
        private readonly CandidateRepository candidateRepository;
        public CandidateController(CandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }
        public IActionResult Index()
        {
            var messageInfo = new Dictionary<string, string>
            {
                { "text", "This is a success message" },
                { "type", "success" },
                { "title", "Thông báo" },
                { "icon", "glyphicon-ok" },
                { "delay", "5000" }
            };

            TempData["messageInfo"] = messageInfo;

            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? userIdClaim.Value : null;

            Candidate? candidate = candidateRepository.GetCandidate(userId);

            if (candidate == null)
            {
                Console.WriteLine("Candidate nulll");
                return RedirectToAction("Index", "Home");
            }

            return View(candidate);
        }
        [HttpPost]
        public IActionResult UpdateInfoPersonal(Candidate candidate)
        {
                Console.WriteLine(candidate.ToString());
            if (ModelState.IsValid)
            {
                candidateRepository.UpdateInfoPersonal(candidate);
                return RedirectToAction("Index");
            } else
            {
            }
            return RedirectToAction("Index", candidate);
        }
    }
}
