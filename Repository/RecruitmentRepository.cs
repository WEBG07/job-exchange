
using JobExchange.Models;
using JobExchange.Repository.RepositoryInterfaces;
using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JobExchange.Repository
{
    public class RecruitmentRepository : IRecruitmentRepository
    {
        private readonly JobExchangeContext _jobExchangeContext;
        public RecruitmentRepository(JobExchangeContext jobExchangeContext)
        {
            _jobExchangeContext = jobExchangeContext;
        }

        public Recruitment Create(Recruitment recruitment)
        {
            _jobExchangeContext.Recruitments.Add(recruitment);
            _jobExchangeContext.SaveChanges();

            return recruitment;
        }

        public void Delete(Recruitment recruitment)
        {
            _jobExchangeContext.Recruitments.Remove(recruitment);
            _jobExchangeContext.SaveChanges();
        }

        public List<Recruitment> GetAll()
        {
            return _jobExchangeContext.Recruitments.ToList();
        }

        public List<Recruitment> GetAllByCompanyId(string companyId)
        {
            return _jobExchangeContext.Recruitments.Where(r => r.CompanyId == companyId).ToList();
        }

        public Recruitment? GetById(string id)
        {
            return _jobExchangeContext.Recruitments.FirstOrDefault(u => u.RecruitmentId == id);
        }

        public List<Recruitment> Search(string search)
        {
            var results = _jobExchangeContext.Recruitments.Where(
        recruitment => recruitment.RecruitmentTitle.Contains(search)
            || recruitment.Slug.Contains(search)
            || recruitment.Industry.IndustryName.Contains(search));
            //.OrderByDescending(recruitment => recruitment.CreatedAt).Take(10);
            return results.ToList();
        }

        public void Update(Recruitment recruitment)
        {
            _jobExchangeContext.Recruitments.Update(recruitment);
            _jobExchangeContext.SaveChanges();
        }

        //trả về danh sách các việc làm đáp ứng tất cả các điều kiện và cũng phải có ngày tạo trong 10 ngày qua:
        //public List<Recruitment> Search(string search)
        //{
        //    var results = _jobExchangeContext.Recruitments.Where(
        //        recruitment => recruitment.Name.Contains(search)
        //            && recruitment.Description.Contains(search)
        //            && recruitment.Category.Name.Contains(search)
        //            && recruitment.CreatedAt > DateTime.Now - TimeSpan.FromDays(10)
        //    ).OrderByDescending(recruitment => recruitment.CreatedAt).Take(10);

        //    return results;
        //}
        
        public IEnumerable<Recruitment> GetRecruitmentsByCompanyId(string companyId)
        {
            return _jobExchangeContext.Recruitments.Where(r => r.CompanyId == companyId).ToList();
        }

        public IEnumerable<Recruitment> GetRecruitmentsByName(string companyId, string name)
        {
            return _jobExchangeContext.Recruitments.Include(r => r.Company).Where(r => r.CompanyId == companyId &&  r.JobDescription.Contains(name)).ToList();
        }
    }
}
