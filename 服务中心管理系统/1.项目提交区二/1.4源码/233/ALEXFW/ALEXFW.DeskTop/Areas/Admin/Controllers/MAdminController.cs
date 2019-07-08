using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Metadata;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ALEXFW.Entity.UserAndRole;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    /// <summary>
    /// 处理队长和维修人员与维修队伍的关联
    /// </summary>
    public class MAdminController : EntityController<Entity.UserAndRole.Admin>
    {
        public MAdminController(IEntityContextBuilder builder) : base(builder)
        {
        }

        [EntityAuthorize]
        public override async Task<ActionResult> Index(int page = 1, int size = 20, string parentpath = null,
           Guid? parentid = null, bool search = false)
        {
            return await List(page, size, null);
        }

        [EntityAuthorize]
        public async Task<ActionResult> List(int page = 1, int size = 20, string nameOrCode = null)
        {
            var adminContext = EntityBuilder.GetContext<Entity.UserAndRole.Admin>();
            var admin = (Session["LoginAdmin"] as Entity.UserAndRole.Admin);

            //按登录用户所在店铺查询所有该店铺管理者用户
            var lists = adminContext.Query()
                .Where(x =>
                    x.GroupTeam.Index == admin.GroupTeam.Index &&
                    !x.Group.HasFlag(AdminGroup.学生服务中心管理员)).OrderBy(x => x.EmployeeCode);

            if (!string.IsNullOrEmpty(nameOrCode))
            {
                lists =
                    lists.Where(x => x.Username.Contains(nameOrCode) || x.EmployeeCode == nameOrCode)
                        .OrderBy(x => x.EmployeeCode);
            }

            // 利用框架的分页系统 
            var model = new EntityViewModel<Entity.UserAndRole.Admin>(lists, page, size);
            model.Items =
                await
                    model.Queryable.OrderBy(x => x.EmployeeCode)
                        .Skip((model.CurrentPage - 1) * size)
                        .Take(size)
                        .ToArrayAsync();

            ViewBag.NameOrCode = nameOrCode;

            ViewBag.PartialViewPath = "_adminTable";

            return View("../../Views/MAdmin/List", model);
        }

        //处理店铺和权限
        protected override async Task UpdateProperty(Entity.UserAndRole.Admin entity, IPropertyMetadata propertyMetadata)
        {
            if (propertyMetadata.ClrName == "TeamGroup")
            {
                var admin = Session["LoginAdmin"] as Entity.UserAndRole.Admin;
                var groupTeamContext = EntityBuilder.GetContext<GroupTeam>();
                //查询出当前登录的店长的所属店铺
                var groupTeam = await groupTeamContext.GetEntityAsync(admin.GroupTeam.Index);
                //把当前店长的店铺对象赋值给正在保存的管理员工实体
                propertyMetadata.SetValue(entity, groupTeam);
            }
            else if (propertyMetadata.ClrName == "Group")
            {
                //把业务员对象赋值给正在保存的管理人员实体
                propertyMetadata.SetValue(entity, AdminGroup.服务中心维修人员);
            }
            else
                await base.UpdateProperty(entity, propertyMetadata);
        }
    }
}