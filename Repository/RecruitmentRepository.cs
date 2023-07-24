
using JobExchange.DataModel;
using JobExchange.Models;
using JobExchange.Repository.RepositoryInterfaces;
using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            return _jobExchangeContext.Recruitments.Include(c => c.Industry).Include(c => c.Company).FirstOrDefault(u => u.RecruitmentId == id);
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
        
        public IEnumerable<Recruitment> GetRecruitmentsByCompanyId(string recruitmentId, string companyId)
        {
            return _jobExchangeContext.Recruitments.Include(c => c.Company).Where(r => r.CompanyId == companyId && r.RecruitmentId != recruitmentId).ToList();
            
        }
        public IEnumerable<object> GetRecruitmentsByCompanyId(string recruitmentId, string companyId, string candidateId)
        {
            //return _jobExchangeContext.Recruitments.Include(c => c.Company).Where(r => r.CompanyId == companyId && r.RecruitmentId != id).ToList();
            var recruitments = _jobExchangeContext.Recruitments
            .GroupJoin(
                _jobExchangeContext.SaveRecruitments,
                r => r.RecruitmentId,
                sr => sr.RecruitmentId,
                (r, srs) => new { Recruitment = r, SaveRecruitments = srs }
            )
            .SelectMany(
                rs => rs.SaveRecruitments.DefaultIfEmpty(),
                (rs, s) => new { Recruitment = rs.Recruitment, SaveRecruitment = s }
            )
            .Where(rss => rss.Recruitment.CompanyId == companyId
                     && (rss.SaveRecruitment == null || rss.SaveRecruitment.CandidateId == candidateId)
                     && rss.Recruitment.RecruitmentId != recruitmentId)
            .Select(rss => new { Recruitment = rss.Recruitment, SaveRecruitment = rss.SaveRecruitment })
            .ToList();

            return recruitments;
        }
        public IEnumerable<object> GetRecruitmentsByCompanyId(string recruitmentId, string companyId, string candidateId, int limit)
        {
            //return _jobExchangeContext.Recruitments.Include(c => c.Company).Where(r => r.CompanyId == companyId && r.RecruitmentId != id).ToList();
            var recruitments = _jobExchangeContext.Recruitments
            .GroupJoin(
                _jobExchangeContext.SaveRecruitments,
                r => r.RecruitmentId,
                sr => sr.RecruitmentId,
                (r, srs) => new { Recruitment = r, SaveRecruitments = srs }
            )
            .SelectMany(
                rs => rs.SaveRecruitments.DefaultIfEmpty(),
                (rs, s) => new { Recruitment = rs.Recruitment, SaveRecruitment = s }
            )
            .Where(rss => rss.Recruitment.CompanyId == companyId
                     && (rss.SaveRecruitment == null || rss.SaveRecruitment.CandidateId == candidateId)
                     && rss.Recruitment.RecruitmentId != recruitmentId)
            .Select(rss => new { Recruitment = rss.Recruitment, SaveRecruitment = rss.SaveRecruitment })
            .Take(limit)
            .ToList();

            return recruitments;
        }
        public IEnumerable<Recruitment> GetRecruitmentsByIndustryId(string id, int industryId)
        {
            return _jobExchangeContext.Recruitments.Include(c => c.Company).Where(r => r.IndustryId == industryId && r.RecruitmentId != id).ToList();
        }

        public IEnumerable<Recruitment> GetRecruitmentsByName(string companyId, string name)
        {
            return _jobExchangeContext.Recruitments.Include(c => c.Company).Where(r => r.CompanyId == companyId &&  r.RecruitmentTitle.Contains(name)).ToList();
        }
        public IEnumerable<Recruitment> GetRecruitments(string filter = null, string value1 = null, string value2 = null)
        {
            var recruitments = _jobExchangeContext.Recruitments.Include(r => r.Industry).Include(r => r.Company);
            if (!string.IsNullOrEmpty(filter))
            {
                if (filter.Equals("districts"))
                {
                    return recruitments.Where(r => r.District.Contains(value1)).ToList();
                }
                if (filter.Equals("salaries"))
                {
                    int intValue1 = int.Parse(value1) * 1000000;
                    int intValue2 = int.Parse(value2) * 1000000;
                    return recruitments.Where(r => r.Salary >= intValue1 && r.Salary <= intValue2).ToList();
                }
                if (filter.Equals("experiences"))
                {
                    int intValue1 = int.Parse(value1);
                    int intValue2 = int.Parse(value2);
                    return recruitments.Where(r => r.Experience > intValue1 && r.Experience <= intValue2).ToList();
                }
                if (filter.Equals("industryes"))
                {
                    int intValue1 = int.Parse(value1);
                    return recruitments.Where(r => r.IndustryId == intValue1).ToList();
                }
            }

            recruitments.ToList();
            return recruitments;


        }
    }
}
