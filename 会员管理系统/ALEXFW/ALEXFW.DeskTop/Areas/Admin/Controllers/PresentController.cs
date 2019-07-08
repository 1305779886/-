using ALEXFW.Entity.Demos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class PresentController : EntityController<Present>
    {
        public PresentController(IEntityContextBuilder builder) : base(builder)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<ActionResult> Update(Guid id)
        {
            //分类名称权限设置
            var Name = Request.Form["Name"].Trim();
            var NameDB = EntityBuilder.GetContext<Present>();
            if (Name == "0")
            {
                Response.StatusCode = 400;
                return new ContentResult
                {
                    Content = "分类名称不得为空"
                };
            }
            else if (NameDB.Query().Any(x => x.Name == Name))
            {
                Response.StatusCode = 400;
                return new ContentResult
                {
                    Content = "已存在礼品分类为" + Name + "的名称"
                };
            }

            //分类编号权限设置
            var SortCode = Request.Form["SortCode"].Trim();
            var SortCodeDB = EntityBuilder.GetContext<Present>();
            if (SortCode == "0")
            {
                Response.StatusCode = 400;
                return new ContentResult
                {
                    Content = "分类名称不得为空"
                };
            }
            else if (SortCodeDB.Query().Any(x => x.SortCode == SortCode))
            {
                Response.StatusCode = 400;
                return new ContentResult
                {
                    Content = "已存在礼品分类为" + SortCode + "的编号"
                };
            }

            //更新实体的父类的方法 ，不要修改
            return await Untils.GetUpdateAction((p, entity) => { return UpdateCore(entity); }, UpdateProperty, id);
        }
        }
}