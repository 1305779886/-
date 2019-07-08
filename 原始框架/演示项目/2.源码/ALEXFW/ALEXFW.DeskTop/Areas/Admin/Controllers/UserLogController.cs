using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALEXFW.Entity.UserAndRole;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class UserLogController : EntityController<UserLog>
    {
        public UserLogController(IEntityContextBuilder builder) : base(builder)
        {
        }
    }
}