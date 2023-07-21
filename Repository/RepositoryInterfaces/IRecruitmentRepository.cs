using JobExchange.Models;

namespace JobExchange.Repository.RepositoryInterfaces
{
    public interface IRecruitmentRepository
    {
        IEnumerable<Recruitment> GetRecruitmentsByCompanyId(string companyId);

        IEnumerable<Recruitment> GetRecruitmentsByName(string companyId,string name);
    }
}