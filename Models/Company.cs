﻿using JobExchange.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobExchange.Models
{
    public partial class Company
    {
        [Key]
        public string CompanyId { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? Introduce { get; set; }
        public string? Scale { get; set; }
        public string? Phone { get; set; }
        public string? Avatar { get; set; }
        public string? CoverImage { get; set; }
        public int IndustryId { get; set; }
        public virtual ICollection<Recruitment> Recruitments { get; set; }

        [ForeignKey("IndustryId")]
        [ValidateNever]
        public Industry Industry { get; set; } = null!;
        public string AccountId { get; set; } = null!;

        [ForeignKey("AccountId")]
        [ValidateNever]
        public JobExchangeUser JobExchangeUser { get; set; } = null!;
    }
}
