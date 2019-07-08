using ALEXFW.CommonUtility;
using ALEXFW.DataAccess;
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
    /// 学生保修服务控制器
    /// </summary>
    public class StudentRepairController : EntityController<StudentRepair>
    {
        static Guid guid;
        public StudentRepairController(IEntityContextBuilder builder) : base(builder)
        {
        }
        //public async Task<ActionResult> Index()
        //{
            //    if (User.Identity.IsAuthenticated)
            //    {
            //        using (var db = new DBContext())
            //        {
            //            var studentRepairs = db.StudentRepairs.ToList();
            //            return View("index", "admin");
            //            //return View("aaa", studentRepairs);
            //        }
            //    }
            //    else
            //    {
            //return View();
            //    }

        //}

       

        public override async Task<ActionResult> Update( Guid id)
        {
            guid = id;
            var student = Session["AdminLogin"] as Entity.UserAndRole.Admin;
            var action = id == Guid.Empty ? "新增" : "编辑";
            var dormContext = EntityBuilder.GetContext<Dorm>();
            var captainsRepairContext = EntityBuilder.GetContext<CaptainsRepair>();

            if (action == "新增")
            {
                var studentID = Request.Form["StudentID"].Trim();
                var name= Request.Form["Name"].Trim();
                var place = Request.Form["Place"].Trim();
                var tel = Request.Form["Tel"].Trim();
                var campus = Request.Form["Campus"].Trim();
                var department = Request.Form["Department"].Trim();
                var matters = Request.Form["Matters"].Trim();           
                var dormIndex = Request.Form["Dorm"].Trim();               
                var dormGuid = new Guid(dormIndex);            
                var dorm = await dormContext.GetEntityAsync(dormGuid);
          
                var captainsRepair = captainsRepairContext.Create();
               
             
                var captainID = Request.Form["CaptainID"].Trim();
                if (captainsRepairContext.Query().Any(x => x.CaptainID == captainID))
                {
                    Response.StatusCode = 400;
                    return new ContentResult
                    {
                        Content = "已存在编号为" + captainID + "的编号"
                    };
                }
                else
                {
                    if (captainID == captainsRepair.CaptainID)
                    {
                        Response.StatusCode = 400;
                        return new ContentResult
                        {
                            Content = captainID + "编号已重复，请输入不重复编号"
                        };
                    }
                }
                

                captainsRepair.Name = name;
                captainsRepair.StudentID = studentID;
                captainsRepair.CaptainID = captainID;
                captainsRepair.Place = place;
                captainsRepair.Campus = campus;          
                captainsRepair.Dorm = dorm;           
                captainsRepair.Department = department;
                captainsRepair.Matters = matters;
                captainsRepair.Tel = tel;           
                captainsRepair.Processed = false;

                await captainsRepairContext.AddAsync(captainsRepair);
            }

            else if (action == "编辑")
            {
                var retroaction = Request.Form["Retroaction"].Trim();
                var captainID = Request.Form["CaptainID"].Trim();
                var studentRepairContext = EntityBuilder.GetContext<StudentRepair>();
                var studentRepair = await studentRepairContext.GetEntityAsync(id);
                if (captainID!= studentRepair.CaptainID)
                {
                    Response.StatusCode = 400;
                    return new ContentResult
                    {
                        Content = "不允许修改维修单号"
                    };
                }
              
                var captainsRepair = captainsRepairContext.Query().SingleOrDefault(t => t.CaptainID.ToLower() == captainID.ToLower());
                captainsRepair.Retroaction = retroaction;
                captainsRepair.CaptainID = captainID;
                await captainsRepairContext.EditAsync(captainsRepair);
            }

            
            //更新实体的父类的方法 ，不要修改
           return await Untils.GetUpdateAction((p, entity) => { return UpdateCore(entity); }, UpdateProperty, id);
        }
        protected override async Task UpdateProperty(StudentRepair entity, IPropertyMetadata propertyMetadata)
        {
            if (propertyMetadata.CustomType == "SingleImage")
            {
                //var studentRepairContext = EntityBuilder.GetContext<StudentRepair>();
                //var studentRepair = await studentRepairContext.GetEntityAsync(guid);


                var oldImage = this.UpSingleImage(entity);
                if (oldImage != entity.Avatar)
                {
                    var captainsRepairContext = EntityBuilder.GetContext<CaptainsRepair>();
                    var captainsRepair = captainsRepairContext.Create();

                    //var captainsRepair = captainsRepairContext.Query().SingleOrDefault(t => t.CaptainID == entity.CaptainID);
                    captainsRepair.Avatar = oldImage;

                    propertyMetadata.SetValue(entity, oldImage);
                }

            }
            else
                await base.UpdateProperty(entity, propertyMetadata);
        }
    }
}