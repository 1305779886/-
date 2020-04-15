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
            context.Database.ExecuteSqlCommand("delete admins");  //����Ա�û�
            context.Database.ExecuteSqlCommand("delete students");//ѧ���û� 
            context.Database.ExecuteSqlCommand("delete dorms");   //����
            context.Database.ExecuteSqlCommand("delete groupTeams"); //ά�޶���
            SeedMethod.Admin(context);
            SeedMethod.Employee(context);
            SeedMethod.Mangager(context);
            SeedMethod.Dorms(context);
            SeedMethod.GroupTeam(context);
            SeedMethod.Students(context);
        }        
    }
}
