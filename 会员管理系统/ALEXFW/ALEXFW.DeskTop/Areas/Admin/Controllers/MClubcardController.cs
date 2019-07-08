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
    public class MClubcardController : EntityController<Entity.UserAndRole.Member>
    {
        public MClubcardController(IEntityContextBuilder builder) : base(builder)
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
            var memberContext = EntityBuilder.GetContext<Entity.UserAndRole.Member>();
            var admin = (Session["LoginAdmin"] as Entity.UserAndRole.Admin);



            //按登录用户所在店铺查询所有该店铺管理者用户                                      
            var lists = memberContext.Query()
                .Where(x =>
                    x.Department.Index == admin.Department.Index);

      

            // 利用框架的分页系统 
            var model = new EntityViewModel<Entity.UserAndRole.Member>(lists, page, size);
            model.Items =
                await
                    model.Queryable.OrderBy(x => x.Username)
                        .Skip((model.CurrentPage - 1) * size)
                        .Take(size)
                        .ToArrayAsync();

            ViewBag.NameOrCode = nameOrCode;

            ViewBag.PartialViewPath = "_AdminMember";

            return View("../../Views/MemberCard/List", model);
        }
    }
}

