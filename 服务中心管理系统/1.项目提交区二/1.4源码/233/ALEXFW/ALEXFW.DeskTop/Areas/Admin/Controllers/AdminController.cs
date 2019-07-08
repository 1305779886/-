using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ALEXFW.Entity.UserAndRole;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class AdminController : EntityController<Entity.UserAndRole.Admin>
    {
        public AdminController(IEntityContextBuilder builder) : base(builder)
        {
        }

        /// <summary>
        /// 重写更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<ActionResult> Update(Guid id)
        {

            var employeeCode = Request.Form["EmployeeCode"].Trim();
            //条件约束
            //查询用户提交的表单中的队伍是否存在队长
            var deptId = Request.Form["GroupTeam"].Trim();
            //创建上下文
            var deptContext = EntityBuilder.GetContext<GroupTeam>();
            var adminContext = EntityBuilder.GetContext<Entity.UserAndRole.Admin>();

                   
            if (!string.IsNullOrEmpty(deptId))
            {
                //从表单中获得用户输入的队伍
                var groupTeam = await deptContext.GetEntityAsync(Guid.Parse(deptId));

                //从用户提交的表单中，获取用户当前输入的用户是否为队长
                var group = (AdminGroup)Enum.Parse(typeof(AdminGroup), Request.Form["Group"]);

                //判断当前队伍是否已经有队长
                if (group.HasFlag(AdminGroup.学生服务中心队长) && adminContext.Query()
                        .Any(x => x.GroupTeam.Index == groupTeam.Index && x.Group.HasFlag(AdminGroup.学生服务中心队长)))
                {
                    Response.StatusCode = 400;
                    return new ContentResult
                    {
                        Content = groupTeam.TeamName + "已经有一名队长"
                    };
                }
            }
            else
            {
                //只有管理员可以不关联店铺，队长和维修人员必须选择关联一个队伍
                //从用户提交的表单中，获取用户当前输入的角色
                var group = (AdminGroup)Enum.Parse(typeof(AdminGroup), Request.Form["Group"]);
                if (!group.HasFlag(AdminGroup.学生服务中心管理员))
                {
                    Response.StatusCode = 400;
                    return new ContentResult
                    {
                        Content = "除了管理员角色，队长或维修人员必须关联一个队伍"
                    };
                }
            }
            

            


            //更新实体的父类的方法 ，不要修改
            return await Untils.GetUpdateAction((p, entity) => { return UpdateCore(entity); }, UpdateProperty, id);
        }
        //public ActionResult index()
        //{ 
        //    var employeeCode = Request.Form["EmployeeCode"].Trim();
        //    var admin = Request.Form["Admin"].Trim();
        //    string ID = admin;
        //    DataTable at = 
        //    return View();
        //}
    }
}