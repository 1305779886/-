using ALEXFW.Entity.Demos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    /// <summary>
    /// 测试
    /// </summary>
    public class ServicemanController : EntityController<Serviceman>
    {
        public ServicemanController(IEntityContextBuilder builder) : base(builder)
        {
        }
    }
}