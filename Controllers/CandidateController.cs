using Microsoft.AspNetCore.Mvc;
using JobExchange.Models;

namespace JobExchange.Controllers
{
    public class CandidateController : Controller
    {
        public IActionResult Index()
        {
            Candidate candidate = new Candidate();
            candidate.CandidateId = "812";
            candidate.FullName = "Vu Van The";
            candidate.Birthday = new DateTime(2002, 10, 8);
            candidate.Gender = "Nam";
            candidate.Phone = "097520371";
            candidate.Avatar = "";

            //ViewData["candidate"] = candidate;
            return View(candidate);
        }
    }
}
