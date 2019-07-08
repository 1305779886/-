using ALEXFW.Entity.Demos;
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
    /// 信息反馈控制器
    /// </summary>
    public class InformationController : EntityController<Information>
    {
        public InformationController(IEntityContextBuilder builder) : base(builder)
        {
        }

    }
}