using JobExchange.Models;

namespace JobExchange.Repository.RepositoryInterfaces
{
    public interface ICandidateRepository
    {
        public Candidate Create(Candidate candidate);
    }
}
