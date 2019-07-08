using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Metadata;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ALEXFW.CommonUtility;
using ALEXFW.DeskTop.ViewModels;
using ALEXFW.Entity.UserAndRole;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class MemberController : EntityController<Member>
    {
        public MemberController(IEntityContextBuilder builder) : base(builder)
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
            var memberContext = EntityBuilder.GetContext<Member>();
            var admin = (Session["LoginAdmin"] as Entity.UserAndRole.Admin);

            //按登录用户所在店铺查询所有该店铺管理者用户
            var lists = memberContext.Query()
                .Where(x =>
                    x.Department.Index == admin.Department.Index);

            //if (!string.IsNullOrEmpty(nameOrCode))
            //{
            //    lists =
            //        lists.Where(x => x.Username.Contains(nameOrCode) || x.EmployeeCode == nameOrCode)
            //            .OrderBy(x => x.EmployeeCode);
            //}

            // 利用框架的分页系统 
            var model = new EntityViewModel<Member>(lists, page, size);
            model.Items =
                await
                    model.Queryable.OrderBy(x => x.Username)
                        .Skip((model.CurrentPage - 1) * size)
                        .Take(size)
                        .ToArrayAsync();

            ViewBag.NameOrCode = nameOrCode;

            ViewBag.PartialViewPath = "_memberTable";

            return View("../../Views/Member/List", model);
        }

        //处理头像和店铺
        protected override async Task UpdateProperty(Member entity, IPropertyMetadata propertyMetadata)
        {
            //头像
            if (propertyMetadata.CustomType == "SingleImage")
            {
                var oldImage = this.UpSingleImage(entity);
                if (oldImage != entity.Avatar)
                    propertyMetadata.SetValue(entity, oldImage);
            }
            else
                await base.UpdateProperty(entity, propertyMetadata);


            if (propertyMetadata.ClrName == "Department")
            {
                var admin = Session["LoginAdmin"] as Entity.UserAndRole.Admin;
                var departmentContext = EntityBuilder.GetContext<Department>();
                var memberContext = EntityBuilder.GetContext<Member>();

                //查询出当前登录的店长的所属店铺
                var department = await departmentContext.GetEntityAsync(admin.Department.Index);

                //把当前店长的店铺对象赋值给正在保存的管理员实体
                propertyMetadata.SetValue(entity, department);
            }
            //else if (propertyMetadata.ClrName == "Group")
            //{
            //    //把业务员对象赋值给正在保存的管理人员实体
            //    propertyMetadata.SetValue(entity, AdminGroup.业务员);
            //}
            else
                await base.UpdateProperty(entity, propertyMetadata);
        }


        // [EntityAuthorize]
        //[HttpPost]
        //public async Task<ActionResult> SearchMember()
        //{

        //    string searchTerms = Request.Form["searchTerms"];
        //    var memberContext = EntityBuilder.GetContext<Member>();
        //    var departmentContext = EntityBuilder.GetContext<Department>();
        //    var admin = (Session["LoginAAdmin"] as Entity.UserAndRole.Admin);
        //    var department = await departmentContext.GetEntityAsync(admin.Department.Index);

        //    DeskTop.ViewModels.MemberViewModel www = new ViewModels.MemberViewModel();

        //    var searchItemsQuery = memberContext.Query().Where(m => (m.Username.Contains(searchTerms) || m.PersonName.Contains(searchTerms)) && department.Index == m.Department.Index);
        //    var searchItems = searchItemsQuery.ToList();

        //    var members = new List<Member>();

        //    foreach(var a in searchItems)
        //    {
        //        members.Add(a);
        //    }

        //   www.Members= searchItems;
        //    return View("SearchMember", www);       


        //var memberContext = EntityBuilder.GetContext<Member>();
        //var departmentContext = EntityBuilder.GetContext<Department>();
        //var admin = (Session["LoginAdmin"] as Entity.UserAndRole.Admin);
        //////var memberSession = (Session["member"] as Entity.UserAndRole.Member);
        //var department = await departmentContext.GetEntityAsync(admin.Department.Index);

        //var searchItem = memberContext.Query().Where(m => m.Username.Contains("a") && m.Department.Index == department.Index);
        //Session["searchItem"] = searchItem;

        //return View("_MemberCardTable");
        // }
    }
}