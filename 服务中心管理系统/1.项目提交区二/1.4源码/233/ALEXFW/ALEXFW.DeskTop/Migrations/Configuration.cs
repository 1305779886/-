namespace ALEXFW.DeskTop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ALEXFW.DataAccess.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ALEXFW.DataAccess.DBContext context)
        {
            context.Database.ExecuteSqlCommand("delete admins");  //管理员用户
            context.Database.ExecuteSqlCommand("delete students");//学生用户 
            context.Database.ExecuteSqlCommand("delete dorms");   //宿舍
            context.Database.ExecuteSqlCommand("delete groupTeams"); //维修队伍
            SeedMethod.Admin(context);
            SeedMethod.Employee(context);
            SeedMethod.Mangager(context);
            SeedMethod.Dorms(context);
            SeedMethod.GroupTeam(context);
            SeedMethod.Students(context);
        }        
    }
}
