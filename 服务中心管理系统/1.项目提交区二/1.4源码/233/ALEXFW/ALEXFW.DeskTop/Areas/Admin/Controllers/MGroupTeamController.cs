using System;
using System.Collections.Generic;
using System.Data.Entity;using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    /// <summary>
    /// 处理当前用户与维修队伍关联的控制器
    /// </summary>
    public class MGroupTeamController : EntityController<Entity.UserAndRole.GroupTeam>
    {
        public MGroupTeamController(IEntityContextBuilder builder) : base(builder)
        {
        }

        [EntityAuthorize]
        public ActionResult Index()
        {
            //店长管理用户才能访问

            //取当前的登录用户
            Entity.UserAndRole.Admin admin = User.GetUser<Entity.UserAndRole.Admin>();
            var groupTeam = admin.GroupTeam;
            return View(groupTeam);

        }
    }
}