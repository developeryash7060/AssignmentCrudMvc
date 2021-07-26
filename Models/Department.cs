using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentCrudMvc.Models
{
    public class Department
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string DeptName { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}