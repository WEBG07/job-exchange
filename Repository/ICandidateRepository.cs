using JobExchange.Models;

namespace JobExchange.Repository
{
    public interface ICandidateRepository
    {
        public Candidate Create (Candidate candidate);
    }
}
