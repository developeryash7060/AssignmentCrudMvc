using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssignmentCrudMvc.Models
{
    public class Salary
    {
        
        [Required]
        public int Amount { get; set; }
        public Employee Employee { get; set; }
        [Key]
        [ForeignKey("Employee")]
        
        public int Id { get; set; }
    }
}