using JobExchange.Models;

namespace JobExchange.Repository.RepositoryInterfaces
{
    public interface IRecruitmentRepository
    {
        public Recruitment? GetById(string id);
        public Recruitment Create(Recruitment recruitment);
        public void Delete(Recruitment recruitment);
        public void Update(Recruitment recruitment);
        public List<Recruitment> GetAll();
        public List<Recruitment> GetAllByCompanyId(string companyId);
        public List<Recruitment> Search(string search);
        IEnumerable<Recruitment> GetRecruitmentsByCompanyId(string id, string companyId);
        IEnumerable<Recruitment> GetRecruitmentsByIndustryId(string id, int industryId);
        IEnumerable<Recruitment> GetRecruitmentsByName(string companyId,string name);
    }
}

