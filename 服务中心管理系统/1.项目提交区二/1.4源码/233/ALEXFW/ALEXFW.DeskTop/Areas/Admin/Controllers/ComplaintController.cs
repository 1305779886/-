using ALEXFW.Entity.Demos;
using ALEXFW.Entity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    /// <summary>
    /// 投诉信息控制器
    /// </summary>
    public class ComplaintController : EntityController<Complaint>
    {
        public ComplaintController(IEntityContextBuilder builder) : base(builder)
        {
        }
    }
}
