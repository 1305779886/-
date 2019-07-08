using ALEXFW.Entity.Demos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class MDepartmentController : EntityController<CaptainsRepair>
    {
        // GET: Admin/MDepartment
        public MDepartmentController(IEntityContextBuilder builder) : base(builder)
        {

        }
        [EntityAuthorize]
        //public ActionResult Index()
        //{
            

        //    //取当前的登录用户
        //    Entity.UserAndRole.Admin admin = User.GetUser<Entity.UserAndRole.Admin>();
        //    var lists = group.Where(c => c.Teacher.Index == admin.Index);
        //    return View(group);
        //}
        protected override async Task<EntityViewModel<CaptainsRepair>> GetIndexModel(IQueryable<CaptainsRepair> queryable, int page, int size)
        {
            //取当前的登录用户
            Entity.UserAndRole.Admin admin = User.GetUser<Entity.UserAndRole.Admin>();

            var lists = queryable.Where(c => c.Admin.Index == admin.Index);
            return await Untils.GetIndexModel(lists, page, size);
        }

    }
}