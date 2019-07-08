using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ALEXFW.Entity.UserAndRole;


namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class OwnerController : EntityController<Entity.Demos.Owner>
    {
        public OwnerController(IEntityContextBuilder builder) : base(builder)
        {
        }
        [EntityAuthorize]
        public override async Task<ActionResult> Update(Guid id)
        {
            Entity.UserAndRole.Admin admin = User.GetUser<Entity.UserAndRole.Admin>();
            var lostRee = Session["AdminLogin"] as Entity.Demos.Lost;
            var ownerRee = Session["AdminLogin"] as Entity.UserAndRole.Admin;

            var lostIndex = Request.Form["Lost"];
            var lostGuid = new Guid(lostIndex);

            var action = id == Guid.Empty ? "新增" : "修改";

            var ownerDB = EntityBuilder.GetContext<Entity.Demos.Owner>();
            var owner = await ownerDB.GetEntityAsync(id);

            var lostDB = EntityBuilder.GetContext<Entity.Demos.Lost>();
            var lost = await lostDB.GetEntityAsync(lostGuid);

            if (action == "新增")
            {
                
                var sqlchoose = Request.Form["SQLChoose"].Trim();

                if (sqlchoose == "false")
                {

                }
                else
                {
                    lost.Choose = true;
                }
                await lostDB.EditAsync(lost);
            }

            

            return await Untils.GetUpdateAction((p, entity) => { return UpdateCore(entity); }, UpdateProperty, id);
        }
    }
}