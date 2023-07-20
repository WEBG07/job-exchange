using Abp.MimeTypes;
using JobExchange.Models;
using JobExchange.Repository;
using JobExchange.Repository.RepositoryInterfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList;
using Stripe;
using System;
using System.Drawing;

namespace JobExchange.Controllers
{
    public class IndustryController : Controller
	{
        private readonly IIndustryRepository _industryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IndustryController(IIndustryRepository industryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _industryRepository = industryRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        // GETALL
        public ActionResult Index(int page, int size)
		{
            int pageSize = size > 0 ? size : 10;
            int pageNumber = page > 0 ? page : 1;

            // Get the list of products from the database.
            var industries = _industryRepository.GetAll();
            // Create a PagedList from the list of products.
            var pagedList = new PagedList<Industry>(industries, pageNumber, pageSize);

            // Return the paged list of products to the view.
            return View(pagedList);
		}

        [HttpPost]
        public IActionResult Create([FromBody] Industry industry)
        {
            try
            {
                if (_industryRepository.ExistsByName(industry.IndustryName))
                {
                    return Ok(new
                    {
                        message = "Tên ngành nghề đã tồn tại !"
                    });
                }
                _industryRepository.Create(industry);
                return Ok(industry);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
		public ActionResult Update(int id, [FromBody] Industry industry)
		{
            try
            {
                var industryExists = _industryRepository.GetById(id);

                if (industryExists == null)
                {
                    return NotFound();
                }

                if (industry.IndustryName != industryExists.IndustryName && _industryRepository.ExistsByName(industry.IndustryName))
                {
                    return Ok(new
                    {
                        message = "Tên ngành nghề đã tồn tại !"
                    });
                }

                industryExists.IndustryName = industry.IndustryName;
                _industryRepository.Update(industryExists);
                return Ok(industryExists);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var industry = _industryRepository.GetById(id);
                if (industry == null)
                {
                    return NotFound();
                }

                _industryRepository.Delete(industry);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_industryRepository.GetById(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Search(string name)
        {
            var results = _industryRepository.SearchByName(name);
            try
            {
                return Ok(results);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
