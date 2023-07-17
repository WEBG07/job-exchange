using Microsoft.AspNetCore.Mvc;
using JobExchange.Models;
using JobExchange.Repository;
using System.Security.Claims;

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
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? userIdClaim.Value : null;
            Console.WriteLine(userId);
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
