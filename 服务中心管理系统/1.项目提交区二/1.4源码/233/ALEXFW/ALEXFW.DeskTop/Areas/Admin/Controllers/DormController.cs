using ALEXFW.Entity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    /// <summary>
    /// 宿舍控制器
    /// </summary>
    public class DormController : EntityController<Dorm>
    {
        public DormController(IEntityContextBuilder builder) : base(builder)
        {
        }
    }
}