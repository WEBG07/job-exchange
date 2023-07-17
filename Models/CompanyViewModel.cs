using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public class CompanyViewModel
    {
        public Company Company { get; set; }
        public List<Recruitment> Recruitments { get; set; }
        public List<Company> RelatedCompanies { get; set; }
    }
}