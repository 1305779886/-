using System;
using System.Data.Entity;
using System.Data.Entity.Metadata;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ALEXFW.CommonUtility;
using ALEXFW.Entity.UserAndRole;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    /// <summary>
    /// 学生控制器（测）
    /// </summary>
    public class StudentsController : EntityController<Students>  
    {
        public StudentsController(IEntityContextBuilder builder) : base(builder)
        {
        }

        //处理头像上传到本站
        protected override async Task UpdateProperty(Students entity, IPropertyMetadata propertyMetadata)
        {
            if (propertyMetadata.CustomType == "SingleImage")
            {
                var oldImage = this.UpSingleImage(entity);
                if (oldImage != entity.Avatar)
                    propertyMetadata.SetValue(entity, oldImage);
            }
            else
                await base.UpdateProperty(entity, propertyMetadata);


          

        }

         public override async Task<ActionResult> Update(Guid id)
        {
            var StudentDB = EntityBuilder.GetContext<Students>();
            var username = Request.Form["UserName"].Trim();
            var StudentCreate = await StudentDB.GetEntityAsync(id);
            if (StudentCreate != null)
            {
                if (StudentCreate.Username != username)
                {
                    Response.StatusCode = 400;
                    return new ContentResult
                    {
                        Content = "不可修改学生用户名！"
                    };
                }
            }


            //更新实体的父类的方法 ，不要修改
            return await Untils.GetUpdateAction((p, entity) => { return UpdateCore(entity); }, UpdateProperty, id);

        }
    }
}