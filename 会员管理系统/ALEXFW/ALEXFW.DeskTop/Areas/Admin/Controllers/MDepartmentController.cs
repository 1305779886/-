using ALEXFW.Entity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class MDepartmentController : EntityController
    {
        /// <summary>
        /// 店长编辑自己店铺的信息
        /// 只需要编辑功能，不需要自动创建增删查改
        /// </summary>
        /// <param name="builder"></param>
        public MDepartmentController(IEntityContextBuilder builder) : base(builder)
        {
        }

        [EntityAuthorize]
        public ActionResult Index()
        {
            //店长管理用户才能访问

            //取当前的登录用户
            Entity.UserAndRole.Admin admin = User.GetUser<Entity.UserAndRole.Admin>();   
            var department = admin.Department;
            return View(department);
        }

        [HttpPost]
        public async Task<ActionResult> Index(Department model, HttpPostedFileBase Logo)
        {
            var context = EntityBuilder.GetContext<Department>();
            var savePath = "";
            if (Logo != null)
            {
                //上传图片到制定的目录 
                if (Logo.ContentLength > 0)
                {
                    //取后缀名
                    var extentsion = Path.GetExtension(Logo.FileName);
                    string filepath = HttpContext.Server.MapPath("~/WebUploadFile/Logos/" + model.Index + extentsion);
                    //保存文件到服务器
                    Logo.SaveAs(filepath);
                    savePath = "/WebUploadFile/Logos/" + model.Index + extentsion;
                    model.Logo = savePath;
                }
            }

            var department = await context.GetEntityAsync(model.Index);
            department.DepartmentName = model.DepartmentName;
            department.DSCN = model.DSCN;
            department.Tel = model.Tel;
            department.Adress = model.Adress;
            if (!string.IsNullOrEmpty(savePath) && department.Logo != savePath)
                department.Logo = model.Logo;

            await context.EditAsync(department);

            return new HttpStatusCodeResult(200);
        }
    }
}