using JobExchange.Models;
using JobExchange.Repository.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using System.Linq;

namespace JobExchange.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly JobExchangeContext _jobExchangeContext;
        public CandidateRepository(JobExchangeContext jobExchangeContext)
        {
            _jobExchangeContext = jobExchangeContext;
        }
        public Candidate Create(Candidate candidate)
        {
            _jobExchangeContext.Candidates.Add(candidate);
            _jobExchangeContext.SaveChangesAsync();

            return candidate;
        }
        public Candidate? GetCandidate(string candidateId)
        {
            try
            {
                Candidate? candidate = _jobExchangeContext.Candidates.SingleOrDefault(c => c.CandidateId == candidateId);
                return candidate;
            } 
            catch(SqlNullValueException e)
            {
                return null;
            }
            
        }
        public Candidate UpdateInfoPersonal(Candidate candidate)
        {
            _jobExchangeContext.Candidates.Update(candidate);
            _jobExchangeContext.SaveChanges();

            return candidate;
        }
        public bool UpdateAvatar(string candidateId, string filename)
        {
            var existingCandidate = _jobExchangeContext.Candidates.Find(candidateId);

            if (existingCandidate != null && filename != null)
            {
                existingCandidate.Avatar = filename;

                _jobExchangeContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
