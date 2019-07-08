using System;
using ALEXFW.Entity.Demos;
using ALEXFW.Entity.UserAndRole;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity.Metadata;
using ALEXFW.CommonUtility;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    /// <summary>
    /// 这个我也不知道是哪个控制器   这个是失物招领的控制器
    /// </summary>
    public class LostController : EntityController<Lost>
    {
        public LostController(IEntityContextBuilder builder) : base(builder)
        {
        }


        [HttpPost]
        public async Task<ActionResult> Index(Lost model, HttpPostedFileBase image)
        {
            var context = EntityBuilder.GetContext<Lost>();
            var savePath = "";
            if (image != null)
            {
                //上传图片到制定的目录 
                if (image.ContentLength > 0)
                {
                    //取后缀名
                    var extentsion = Path.GetExtension(image.FileName);
                    string filepath = HttpContext.Server.MapPath("~/WebUploadFile/Logos/" + model.Index + extentsion);
                    //保存文件到服务器
                    image.SaveAs(filepath);
                    savePath = "/WebUploadFile/Logos/" + model.Index + extentsion;
                    model.image = savePath;
                }
            }

            var lost = await context.GetEntityAsync(model.Index);
            lost.image = model.image;
            lost.ItemsName = model.ItemsName;
            lost.Note = lost.Note;
            lost.Place = lost.Place;
            if (!string.IsNullOrEmpty(savePath) && lost.image != savePath)
                lost.image = model.image;

            await context.EditAsync(lost);

            return new HttpStatusCodeResult(200);
        }
    

    //处理头像和店铺
    protected override async Task UpdateProperty(Lost entity, IPropertyMetadata propertyMetadata)
        {
            //头像
            if (propertyMetadata.CustomType == "SingleImage")
            {
                var oldImage = this.UpSingleImage(entity);
                if (oldImage != entity.image)
                    propertyMetadata.SetValue(entity, oldImage);
            }
            else
                await base.UpdateProperty(entity, propertyMetadata);


            //if (propertyMetadata.ClrName == "Department")
            //{
            //    var admin = Session["LoginAdmin"] as Entity.UserAndRole.Admin;
            //    var departmentContext = EntityBuilder.GetContext<Department>();
            //    var memberContext = EntityBuilder.GetContext<Member>();

                //查询出当前登录的店长的所属店铺
                //var department = await departmentContext.GetEntityAsync(admin.Department.Index);

                //把当前店长的店铺对象赋值给正在保存的管理员实体
            //    propertyMetadata.SetValue(entity, department);
            //}
            //else if (propertyMetadata.ClrName == "Group")
            //{
            //    //把业务员对象赋值给正在保存的管理人员实体
            //    propertyMetadata.SetValue(entity, AdminGroup.业务员);
            ////}
            //else
            //    await base.UpdateProperty(entity, propertyMetadata);
        }
    }
}
  