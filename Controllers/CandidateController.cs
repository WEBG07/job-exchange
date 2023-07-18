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
        public IActionResult UpdateInfoPersonal([FromBody] Candidate candidate)
        {

            candidateRepository.UpdateInfoPersonal(candidate);
            return Json(candidate);

        }
        [HttpPost]
        public string UploadAvatar(IFormFile avatar_file)
        {
            if (avatar_file != null && avatar_file.Length > 0)
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                var userId = userIdClaim != null ? userIdClaim.Value : null;

                string fileName = userId + Path.GetExtension(Path.GetFileName(avatar_file.FileName));
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "avatar");
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    avatar_file.CopyTo(stream);
                }
                if (candidateRepository.UpdateAvatar(userId, fileName))
                {
                    return fileName;
                }
                return "error";
                // Tiếp tục xử lý và trả về phản hồi tùy ý

            }

            return "empty";
        }

    }
}
//var messageInfo = new Dictionary<string, string>
//{
//    { "text", "Cập nhật thông tin thành công" },
//    { "type", "success" },
//    { "title", "Thông báo" },
//    { "icon", "glyphicon-ok" },
//    { "delay", "3000" }
//};

//TempData["messageInfo"] = messageInfo;