using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ALEXFW.CommonUtility;
using ALEXFW.DataAccess;
using ALEXFW.Entity.UserAndRole;

namespace ALEXFW.DeskTop.Controllers
{
    public class HomeController : EntityController
    {
        public HomeController(IEntityContextBuilder builder) : base(builder) { }

        public ActionResult Index()
        {
            using (var db = new DBContext())
            {
                var departments = db.Departments.ToList();
                return View(departments);
            }
        }
    }
}