using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssignmentCrudMvc.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DOJ { get; set; }
        [Required]
        public long Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        public Department Department { get; set; }

        [ForeignKey("Department")]
        [Required]
        public int DeptId { get; set; }

        public Salary Salary { get; set; }

    }
}