using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ALEXFW.CommonUtility;
using ALEXFW.DataAccess;
using ALEXFW.Entity.UserAndRole;

namespace ALEXFW.DeskTop.Migrations
{
    public class SeedMethod
    {
        /// <summary>
        /// 分组种子
        /// </summary>
        /// <param name="context"></param>
        public static void GroupTeam(DBContext context)
        {
            var d1 = new GroupTeam()
            {
                Index = Guid.NewGuid(),
                TeamID = "001",
                TeamName="维修一队",
                CreateDate = DateTime.Now
            };
            var d2 = new GroupTeam()
            {
                Index = Guid.NewGuid(),
                TeamID = "002",
                TeamName = "维修二队",
                CreateDate = DateTime.Now
            };
            var d3 = new GroupTeam()
            {
                Index = Guid.NewGuid(),
                TeamID = "003",
                TeamName = "维修三队",
                CreateDate = DateTime.Now
            };
            var d4 = new GroupTeam()
            {
                Index = Guid.NewGuid(),
                TeamID = "004",
                TeamName = "维修四队",
                CreateDate = DateTime.Now
            };
            context.GroupTeams.Add(d1);
            context.GroupTeams.Add(d2);
            context.GroupTeams.Add(d3);
            context.GroupTeams.Add(d4);
            context.SaveChanges();
        }

        /// <summary>
        /// 宿舍种子
        /// </summary>
        /// <param name="context"></param>
        public static void Dorms(DBContext context)
        {
            var d1 = new Dorm()
            {
                Index = Guid.NewGuid(),
                SortCode = "16栋103",
                CreateDate = DateTime.Now
            };
            var d2 = new Dorm()
            {
                Index = Guid.NewGuid(),
                SortCode = "2栋302",
                CreateDate = DateTime.Now
            };
            var d3 = new Dorm()
            {
                Index = Guid.NewGuid(),
                SortCode = "2栋303",
                CreateDate = DateTime.Now
            };
            var d4 = new Dorm()
            {
                Index = Guid.NewGuid(),
                SortCode = "16栋101",
                CreateDate = DateTime.Now
            };
            context.Dorms.Add(d1);
            context.Dorms.Add(d2);
            context.Dorms.Add(d3);
            context.Dorms.Add(d4);
            context.SaveChanges();
        }
        /// <summary>
        /// 添加一名管理员用户，权限是系统管理员
        /// </summary>
        /// <param name="context"></param>
        public static void Admin(DBContext context)
        {
            Admin admin = new Admin();
            admin.Index = Guid.NewGuid();
            admin.CreateDate = DateTime.Now;
            admin.Username = "admin";
            admin.SetPassword("admin");
            admin.Group = AdminGroup.学生服务中心管理员 | AdminGroup.学生服务中心队长 | AdminGroup.服务中心维修人员;
            admin.EmployeeCode = "1000";
            admin.IsLocked = false;
            context.Admins.Add(admin);
            context.SaveChanges();
        }

        /// <summary>
        /// 添加一名管理员用户，权限是店铺管理员
        /// </summary>
        /// <param name="context"></param>
        public static void Mangager(DBContext context)
        {
            Admin admin = new Admin();
            admin.Index = Guid.NewGuid();
            admin.CreateDate = DateTime.Now;
            admin.Username = "ceo";
            admin.SetPassword("123.abc");
            admin.GroupTeam = context.GroupTeams.SingleOrDefault(x => x.TeamName == "维修一队");
            admin.Group = AdminGroup.学生服务中心队长 | AdminGroup.服务中心维修人员;
            admin.EmployeeCode = "1001";
            admin.IsLocked = false;
            context.Admins.Add(admin);
            context.SaveChanges();
        }

        /// <summary>
        /// 添加一名管理员用户，权限是业务员
        /// </summary>
        /// <param name="context"></param>
        public static void Employee(DBContext context)
        {
            Admin admin = new Admin();
            admin.Index = Guid.NewGuid();
            admin.CreateDate = DateTime.Now;
            admin.Username = "employee";
            admin.SetPassword("123.abc");
            admin.GroupTeam = context.GroupTeams.SingleOrDefault(x => x.TeamName == "维修一队");
            admin.Group = AdminGroup.服务中心维修人员;
            admin.EmployeeCode = "1002";
            admin.IsLocked = false;
            context.Admins.Add(admin);
            context.SaveChanges();
        }

        public static void Students(DBContext context)
        {
            Admin admin = new Admin();
            admin.Index = Guid.NewGuid();
            admin.CreateDate = DateTime.Now;
            admin.Username = "AcrossEternal";
            admin.SetPassword("123456");
            admin.Group = AdminGroup.在校学生;
            admin.EmployeeCode = "1003";
            admin.IsLocked = false;
            context.Admins.Add(admin);
            context.SaveChanges();
        }

        //public static void Students(DBContext context)
        //{
        //    Students students = new Students();
        //    students.Index = Guid.NewGuid();
        //    students.Username = "Alex";
        //    students.CreateDate = DateTime.Now;
        //    students.LastLoginDateTime = DateTime.Now;
        //    students.PersonName = "余剑";
        //    students.SetPassword("123456");
        //    students.Avatar = "";
        //    context.Students.Add(students);
        //    context.SaveChanges();

        //    Students students1 = new Students();
        //    students1.Index = Guid.NewGuid();
        //    students1.Username = "AcrossEternal";
        //    students1.CreateDate = DateTime.Now;
        //    students1.LastLoginDateTime = DateTime.Now;
        //    students1.PersonName = "跨越永恒";
        //    students1.SetPassword("123456");
        //    students1.Avatar = "";
        //    context.Students.Add(students1);
        //    context.SaveChanges();
        //}
    }
}

