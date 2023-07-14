using JobExchange.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobExchange.Models
{
    public partial class Candidate
    {
        [Key]
        public string CandidateId { get; set; } = null!;
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Phone { get; set; }
        public string? Avatar { get; set; }
        public string AccountId { get; set; } = null!;

        [ForeignKey("AccountId")]
        [ValidateNever]
        public JobExchangeUser JobExchangeUser { get; set; } = null!;
    }
}
