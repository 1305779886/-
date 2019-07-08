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
    //实体类上下文
    public class DBContext:DbContext
    {
        //宿舍实体
        public DbSet<Dorm> Dorms { get; set; }

        //管理员角色实体
        public DbSet<Admin> Admins { get; set; }     

        //维修人员分组实体
        public DbSet<GroupTeam> GroupTeams { get; set; }
                
        //学生保修服务实体
        public DbSet<StudentRepair> StudentRepairs { get; set; }

        //失物招领实体
        public DbSet<Lost> Losts { get; set; }

        //信息反馈
        public DbSet<Information> Information { get; set; }

        //投诉
        public DbSet<Complaint> Complaints{ get; set; }

        //维修服务
        public DbSet<Entity.Demos.CaptainsRepair> CaptainsRepairs { get; set; }

        //失主信息登记
        public DbSet<Entity.Demos.Owner> Owners { get; set; }

        //测试实体的上下文

        //维修人员实体（测）
        public DbSet<Serviceman> Servicemen { get; set; }

        //学生实体（测）
        public DbSet<Students> Students { get; set; }
    }
}
