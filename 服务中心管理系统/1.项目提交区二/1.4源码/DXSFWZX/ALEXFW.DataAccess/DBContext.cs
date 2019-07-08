using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALEXFW.Entity.UserAndRole;
using ALEXFW.Entity;
using ALEXFW.Entity.Demos;
using ALEXFW.DeskTop.Areas.Admin.Models;

namespace ALEXFW.DataAccess
{
    public class DBContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet< Member> Members { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products{ get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeGroup> EmployeeGroup { get; set; }

    }
    }

