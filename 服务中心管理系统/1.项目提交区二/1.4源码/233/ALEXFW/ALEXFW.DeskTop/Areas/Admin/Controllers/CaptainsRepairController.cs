using ALEXFW.CommonUtility;
using ALEXFW.Entity.Demos;
using ALEXFW.Entity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Metadata;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    /// <summary>
    /// 维修服务控制器
    /// </summary>
    public class CaptainsRepairController : EntityController<CaptainsRepair>
    {
        public CaptainsRepairController(IEntityContextBuilder builder) : base(builder)
        {
        }
        [EntityAuthorize]
  

        public override async Task<ActionResult> Update(Guid id)
        {
            Entity.UserAndRole.Admin admin = User.GetUser<Entity.UserAndRole.Admin>();
            var student = Session["AdminLogin"] as Entity.Demos.StudentRepair;
            var captains = Session["AdminLogin"] as Entity.UserAndRole.Admin;
            var action = id == Guid.Empty ? "新增" : "修改";

            var captainsRepairContext = EntityBuilder.GetContext<CaptainsRepair>();
            var captainsRepair = await captainsRepairContext.GetEntityAsync(id);

            var studentRepairContext = EntityBuilder.GetContext<StudentRepair>();            
           // var studentRepair = studentRepairContext.Query().SingleOrDefault(t => t.CaptainID == captainsRepair.CaptainID);

            if (action == "新增")
            {
                 var studentRepair = studentRepairContext.Create();
                var captainID = Request.Form["CaptainID"].Trim();
               
               
                if (captainID==studentRepair.CaptainID)
                {
                    Response.StatusCode = 400;
                    return new ContentResult
                    {
                        Content =captainID+  "编号已重复，请输入不重复编号"
                    };
                }
                //var avatar = Request.Form["Avatar"].Trim();

                //  var studentRepairContext = EntityBuilder.GetContext<StudentRepair>();
                //
                //studentRepair.Avatar = avatar;

                //await studentRepairContext.AddAsync(studentRepair);
            }
            else if (action == "修改")
            {

                var processed = Request.Form["Processed"].Trim();
                var captainID = Request.Form["CaptainID"].Trim();
              
                var studentRepair = studentRepairContext.Query().SingleOrDefault(t => t.CaptainID == captainsRepair.CaptainID);
              
                if (captainID != captainsRepair.CaptainID)
                {
                    Response.StatusCode = 400;
                    return new ContentResult
                    {
                        Content = "不允许修改维修单号"
                    };
                }

                if ( processed == "true")
                {
                    captainsRepair.Processed = true;
                    if(studentRepair!=null)
                    studentRepair.Processed = true  ;
                    studentRepair.Hour = DateTime.Now;
                }
                
                else if(processed == "false")
                {
                    captainsRepair.Processed = false;
                    if(studentRepair!=null)
                   studentRepair.Processed   = false ;
                   
                }
              
              await captainsRepairContext.EditAsync(captainsRepair);
            }

            return await Untils.GetUpdateAction((p, entity) => { return UpdateCore(entity); }, UpdateProperty, id);
        }
   
    }
}