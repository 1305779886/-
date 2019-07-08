using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALEXFW.Entity.UserAndRole;
using ALEXFW.Entity;
using ALEXFW.Entity.Demos;

namespace ALEXFW.DataAccess
{
    public class DBContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Entity.UserAndRole.Member> Members { get; set; }

        ////测试实体的上下文
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Employee> Employee { get; set; }
        //public DbSet<EmployeeGroup> EmployeeGroup { get; set; }
        // public DbSet<Mem>Mem { get; set; }

        public DbSet<Three> Threes { get; set; }
        public DbSet<Salesman> Salesmen { get; set; }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Present> Presents { get; set; }

        public DbSet<Gift> Gifts { get; set; }
        public DbSet<MemberCard> MemberCards { get; set; }

        public System.Data.Entity.DbSet<ALEXFW.Entity.Demos.Employee> Employees { get; set; }

    }
}
