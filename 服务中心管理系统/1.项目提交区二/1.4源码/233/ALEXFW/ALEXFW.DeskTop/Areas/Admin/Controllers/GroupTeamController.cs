using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    /// <summary>
    /// 维修队伍控制器
    /// </summary>
    public class GroupTeamController : EntityController<Entity.UserAndRole.GroupTeam>
    {
        public GroupTeamController(IEntityContextBuilder builder) : base(builder)
        {
        }
    }
}