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
    public class MAdminController : EntityController<Entity.UserAndRole.Admin>
    {
        public MAdminController(IEntityContextBuilder builder) : base(builder)
        {
        }

        //[EntityAuthorize]
        //[HttpPost]
        //public async Task<ActionResult> SearchAdmins()
        //{
        //    string searchTerms = Request.Form["searchTerms"];
        //    var memberContext = EntityBuilder.GetContext<Member>();
        //    var departmentContext = EntityBuilder.GetContext<Department>();
        //    var admin = (Session["LoginAdmin"] as Entity.UserAndRole.Admin);
        //    var department = await departmentContext.GetEntityAsync(admin.Department.Index);

        //    DeskTop.ViewModels.MemberListViewModel memberListViewModel = new Entity.ViewModels.MemberListViewModel();

        //    //根据搜索词找到的原始数据
        //    var searchItemsQuery = memberContext.Query().Where(m => (m.Username.Contains(searchTerms) || 
        //    m.PersonName.Contains(searchTerms)) && department.Index == m.Department.Index);
        //    var searchItems = searchItemsQuery.ToList();

        //    //定义member类型列表
        //    var AdminList = new List<Member>();

        //    foreach (var a in searchItems)
        //    {
        //        AdminList.Add(a);
        //    }
        //    memberListViewModel.MemberList = searchItems;
        //    return View("SearchMember", memberListViewModel);
        //}


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
                    x.Department.Index == admin.Department.Index &&
                    !x.Group.HasFlag(AdminGroup.管理员)).OrderBy(x => x.EmployeeCode);

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
            if (propertyMetadata.ClrName == "Department")
            {
                var admin = Session["LoginAdmin"] as Entity.UserAndRole.Admin;
                var departmentContext = EntityBuilder.GetContext<Department>();
                //查询出当前登录的店长的所属店铺
                var department = await departmentContext.GetEntityAsync(admin.Department.Index);
                //把当前店长的店铺对象赋值给正在保存的管理员工实体
                propertyMetadata.SetValue(entity, department);
            }
            else if (propertyMetadata.ClrName == "Group")
            {
                //把业务员对象赋值给正在保存的管理人员实体
                propertyMetadata.SetValue(entity, AdminGroup.业务员);
            }
            else
                await base.UpdateProperty(entity, propertyMetadata);
        }
    }
}
