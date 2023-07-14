using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobExchange.Models
{
    public partial class Industry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IndustryId { get; set; }
        public string? IndustryName { get; set; }

    }
}
