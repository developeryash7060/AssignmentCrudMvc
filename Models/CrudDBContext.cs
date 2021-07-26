using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AssignmentCrudMvc.Models
{
    public class CrudDBContext : DbContext
    {
        public CrudDBContext(): base("MyDbContext")
        {
            Database.SetInitializer<CrudDBContext>(new CreateDatabaseIfNotExists<CrudDBContext>());

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        
    }
}