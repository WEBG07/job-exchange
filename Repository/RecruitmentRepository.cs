using JobExchange.Models;
using JobExchange.Repository.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace JobExchange.Repository
{
    public class RecruitmentRepository : IRecruitmentRepository
    {
        private readonly JobExchangeContext _jobExchangeContext;
        public RecruitmentRepository(JobExchangeContext jobExchangeContext)
        {
            _jobExchangeContext = jobExchangeContext;
        }

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