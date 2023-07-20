using JobExchange.Models;
using Microsoft.EntityFrameworkCore;

namespace JobExchange.Repository.RepositoryInterfaces
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly JobExchangeContext _jobExchangeContext;
        public CandidateRepository(JobExchangeContext jobExchangeContext)
        {
            _jobExchangeContext = jobExchangeContext;
        }
        public Candidate Create (Candidate candidate)
        {
            _jobExchangeContext.Candidates.Add(candidate);
            _jobExchangeContext.SaveChanges();

            return candidate;
        }
    }
}
